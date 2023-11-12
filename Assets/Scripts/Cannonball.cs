using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannonball : Freezable
{
		public float speed;
		
		private Cannon parent;
		
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // if not frozen, move in forward direction
				if(!isFrozen()){
					transform.Translate(Vector3.up * speed * Time.deltaTime);
				}
    }
		
		public void setParent(Cannon parent){
				this.parent = parent;
		}
		
		public void setDirection(float direction){
				transform.localEulerAngles = new Vector3(0, 0, direction);
		}
		
		public void OnCollisionStay2D(Collision2D collision){
			if (!isFrozen() && collision.gameObject.GetComponent<Cannonball>() == null)
			{
				// kill player
				if (collision.gameObject.tag == "Player")
				{
					collision.gameObject.GetComponent<PlayerDeath>().die();
				}

				// destroy
				Destruct();
			}
        }
		
		public void Destruct(){
			Destroy(gameObject);
			
			// set parent's active cannonball to null
			parent.setActiveCannonball(null);	
		}
}
