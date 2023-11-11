using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HalfSaw : MonoBehaviour
{
		public float rotationSpeed = 2;
		
		public bool frozen = false;
		
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!frozen){
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
