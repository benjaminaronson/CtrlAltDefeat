using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HalfSaw : Freezable
{
		public float rotationSpeed = 2;
		
    // Start is called before the first frame update
    void Start()
    {
        
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
					// TODO: replace with real player logic
					Debug.Log("Played died!");
			}
		}
}
