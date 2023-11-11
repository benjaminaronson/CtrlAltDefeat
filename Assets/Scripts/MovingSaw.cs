using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingSaw : SimpleMovingPlatform
{
		public float rotationSpeed = 360 * 3;
		
		// Start is called before the first frame update
    public override void Start()
    {
			base.Start();
    }
		
    // Update is called once per frame
    public override void Update()
    {
			base.Update();
			
			if(!isFrozen()) transform.Rotate(0, 0, rotationSpeed * Time.deltaTime);
    }
		
		private void OnCollisionEnter2D(Collision2D collision){
			if(collision.gameObject.tag == "Player" && !isFrozen()){
				// TODO: kill player and stuff
				Debug.Log("Player died!");
			}
		}
}
