using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateSaw : MonoBehaviour
{
    public static float rotationSpeed;
    // Start is called before the first frame update
    void Start()
    {
        rotationSpeed = 720;
    }
    public  void freeze()
    {
        rotationSpeed = 0;
    }
    public  void unfreeze()
    {
        rotationSpeed = 720;
    }
    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0, 0, rotationSpeed * Time.deltaTime));
    }
}
