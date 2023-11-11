using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingSawParent : MonoBehaviour
{
		public GameObject platform;
		
		public MovingSaw movingSaw;
	
    // Start is called before the first frame update
    void Start()
    {
        movingSaw = platform.GetComponent<MovingSaw>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
