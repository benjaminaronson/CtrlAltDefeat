using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Unity.VisualScripting;

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
    public GameObject laser3;
    GameObject[] lasers;
    public float speedMultiplier;
    public float offset;

    // Start is called before the first frame update
    void Start()
    {
        lasers = new GameObject[3];
        lasers[0] = laser1;
        lasers[1] = laser2;
        lasers[2] = laser3;

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
            float timesinceStart = Time.realtimeSinceStartup;
            int index = (int)(timesinceStart * speedMultiplier + offset) % 3;
            for (int i = 0; i < lasers.Length; i++) { 
                if (i == index)
                {
                    lasers[i].GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
                }
                else
                {
                    lasers[i].GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0);
                }
            }
    
    }
    }
}
