using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotateCoinONIslandd : MonoBehaviour
{
    public float xRotate, yRotate, zRotate;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(xRotate*Time.deltaTime, yRotate*Time.deltaTime, zRotate*Time.deltaTime);
    }
}
