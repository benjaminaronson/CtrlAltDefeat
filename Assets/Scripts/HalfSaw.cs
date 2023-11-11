using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HalfSaw : MonoBehaviour
{
		public float rotationSpeed = 2;
		public GameObject player;
		public bool frozen = false;
		
    // Start is called before the first frame update
    void Start()
    {
		player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
		
		private void OnCollisionEnter2D(Collision2D collision){
			// kill player if they land on edge collider
			if (collision.otherCollider.GetType() == typeof(EdgeCollider2D))
			{
			player.GetComponent<PlayerDeath>().die();
					
			}
		}
}
