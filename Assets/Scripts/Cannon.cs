using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : Freezable
{
		public GameObject cannonball;
		public GameObject cannonballSpawnOffset;
		public float cannonballSpeed;
		
		[Tooltip("If specified, the child cannon will always fire after this cannon (after waiting for the firing delay).  This is good for creating patterns of shots.  Note that this will have weird behavior if this cannon is able to fire before the child cannon's cannonball is destroyed, so try to avoid that possibility using firing delays if you can.")]
		public GameObject childCannon = null;
		
		public float firingDelay = 0f;
		
		// private
		
		private GameObject m_activeCannonball = null;
		private Cannon m_childCannon = null;
		
		private bool m_fire = false;
		private float m_timeWaited = 0.0f;
		
		// child only attributes
		private bool m_hasParent = false;
		
    // Start is called before the first frame update
    void Start()
    {
        if(childCannon != null){
					m_childCannon = childCannon.GetComponent<Cannon>();
					m_childCannon.setHasParent(true);
				}
    }

    // Update is called once per frame
    void Update()
    {
				// no active cannonball + not frozen
				if(!this.isActive() && !isFrozen()){
					// if there's no active bullet and we haven't started firing
					if(!this.m_fire){
						// if we're unparented, just start firing
						// otherwise we wait for parent to tell us to start firing
						// indicate to fire bullet after firing delay
						this.m_fire = !this.m_hasParent;
					} 
					// no active bullet, have started firing
					else {
						// increase time waited
						m_timeWaited += Time.deltaTime;
						
						// if more than firing delay, fire cannon
						if(m_timeWaited > firingDelay){
							fire();
						}
					}
				}
		}
		
		public void fire(){
			// spawn bullet
			GameObject inst = Instantiate(cannonball, cannonballSpawnOffset.transform);
			
			Cannonball c = inst.GetComponent<Cannonball>();
			
			c.speed = cannonballSpeed;
			c.setParent(this);
			
			this.setActiveCannonball(inst);
			
			// tell child to begin firing
			if(this.hasChildCannon()) this.m_childCannon.beginFiring();
			
			// reset time waited
			m_timeWaited = 0;
			
			// reset m_fire
			m_fire = false;
		}
		
		public void beginFiring(){
			this.m_fire = true;
		}
		
		public bool hasActiveCannonball()
		{
			return this.m_activeCannonball != null;
		}

		// considering a cannon active if there is still a cannonball somewhere along its hierarchy.
		public bool isActive()
		{
			return this.hasActiveCannonball() || (this.hasChildCannon() ? this.m_childCannon.isActive() : false);
		}

		public void setActiveCannonball(GameObject cannonball){
			this.m_activeCannonball = cannonball;
		}
		
		public bool hasChildCannon(){
			return m_childCannon != null;
		}
		
		public void setHasParent(bool hasParent){
			this.m_hasParent = hasParent;
		}
}
