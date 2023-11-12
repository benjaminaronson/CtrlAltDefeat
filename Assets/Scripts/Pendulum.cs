using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pendulum : Freezable
{
    public int pendulumNumber = 0;
    public float pendulumLength = 5f;
    public float swingSpeed = 2f;
    private float angle;
    private Quaternion initialRotation;
    private float timePassed;
    private void Start()
    {
        initialRotation = transform.rotation;
    }
    private void Awake()
    {

    }
    private void Update()
    {
        if (isFrozen())
        {
            
        }
        if (!isFrozen()) {
            timePassed += Time.deltaTime;
            if (pendulumNumber == 1)
            {
                angle = Mathf.Cos(timePassed * swingSpeed);
            }
            // Calculate the angle based on time
            else if (pendulumNumber == 2)
            {
                angle = Mathf.Sin(timePassed * swingSpeed);
            }


            // Convert the angle to rotation
            Quaternion rotation = Quaternion.Euler(0f, 0f, angle * pendulumLength);

            // Apply the rotation to the GameObject
            transform.rotation = initialRotation * rotation;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //if (!isFrozen()) { 
            if (collision.gameObject.tag == "Player")
            {
                if (collision.otherCollider.GetType() == typeof(EdgeCollider2D))
                {
                    collision.gameObject.GetComponent<PlayerDeath>().die();
                }
            }
       // }
        
    }
    /*private void OnCollisionStay2D(Collision2D collision)
    {
        if (!isFrozen())
        {
            if (collision.gameObject.tag == "Player")
            {
                // fun player death logic
                collision.gameObject.GetComponent<PlayerDeath>().die();
                Debug.Log("Player died!");
            }
        }
    }*/
}
