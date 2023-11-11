using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingSaw : MonoBehaviour
{
		public float rotationSpeed = 360 * 3;
		
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
			transform.Rotate(0, 0, rotationSpeed * Time.deltaTime);
    }
		
		private void OnCollisionEnter2D(Collision2D collision){
			if(collision.gameObject.tag == "Player"){
				// TODO: kill player and stuff
				Debug.Log("Player died!");
			}
		}
}
