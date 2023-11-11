using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreezeDebugging : MonoBehaviour
{
		public GameObject freezeTest;
		
		Freezable freezer;
		
    // Start is called before the first frame update
    void Start()
    {
			freezer = freezeTest.GetComponent<Freezable>();
			//Debug.Log(freezer);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("space")){
					freezer.setFrozen(!freezer.isFrozen());
				}
    }
}
