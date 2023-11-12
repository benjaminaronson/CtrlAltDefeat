using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Unity.VisualScripting;
using System.Runtime.CompilerServices;

public class CycleLaser : Freezable
{
    /*public Sprite laserOn;
    public Sprite laserStatic;
    public Sprite laserOff;
    Sprite[] lasers;
    public float speed;
    SpriteRenderer laser;*/
    public GameObject laser1;
    public GameObject laser2;
    
    GameObject[] lasers;
    public float speedMultiplier;
    public float offset;
    private int activeLaser;

    private float m_timePassed;

    // Start is called before the first frame update
    void Start()
    {
        lasers = new GameObject[2];
        lasers[0] = laser1;
        lasers[1] = laser2;
     
        activeLaser = 0;

    /*lasers = new Sprite[3];
    lasers[0] = laserOn;
    lasers[1] = laserStatic;
    lasers[2] = laserOff;
    laser = GetComponent<SpriteRenderer>();*/
    }


    // Update is called once per frame
    void Update()
    {
        if (!isFrozen())
        {
            m_timePassed += Time.deltaTime;
            int index = (int)(m_timePassed * speedMultiplier + offset) % 2;
            for (int i = 0; i < lasers.Length; i++) { 
                if (i == index)
                {
                    lasers[i].GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
                    activeLaser = i;
                }
                else
                {
                    lasers[i].GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0);
                }
            }
    
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (activeLaser > 0)
        {
            if (collision.gameObject.tag == "Player")
            {
                // fun player death logic
                collision.gameObject.GetComponent<PlayerDeath>().die();
                Debug.Log("Player died!");
            }
        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (activeLaser > 0)
        {
            if (collision.gameObject.tag == "Player")
            {
                // fun player death logic
                collision.gameObject.GetComponent<PlayerDeath>().die();
                Debug.Log("Player died!");
            }
        }
    }
}
