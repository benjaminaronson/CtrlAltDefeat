using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillZone : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
    


        if (collision.gameObject.CompareTag("Player") && collision.otherCollider.GetType() != typeof(EdgeCollider2D))
        {
            // kill player
            collision.gameObject.GetComponent<PlayerDeath>().die();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // kill player
            collision.gameObject.GetComponent<PlayerDeath>().die();
        }
    }
}
