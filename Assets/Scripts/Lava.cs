using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lava : MonoBehaviour
{
    public AudioSource crash;
    
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
        if (collision.gameObject.GetComponent<PlayerDeath>() != null)
        {
            collision.gameObject.GetComponent<PlayerDeath>().die();
        }
        /*if (collision.gameObject.CompareTag("Start"))
        {
            crash.Play();
        }*/
    }
}
