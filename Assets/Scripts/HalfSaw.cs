using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HalfSaw : Freezable
{
		public float rotationSpeed = 360;

    // Start is called before the first frame update
    void Start()
    {
				//player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if(!isFrozen()){
					transform.Rotate(0, 0, rotationSpeed * Time.deltaTime);
				}

    }
		
		private void OnCollisionEnter2D(Collision2D collision){
			// kill player if they land on edge collider
			if (collision.otherCollider.GetType() == typeof(EdgeCollider2D))
			{
					// check if other is player
					if(collision.gameObject.tag == "Player"){
							// fun player death logic
							collision.gameObject.GetComponent<PlayerDeath>().die();
							
					}
			}
		}
}
