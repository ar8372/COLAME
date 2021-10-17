using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotateKey : MonoBehaviour
{
    public float Yrotate;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, Yrotate*Time.deltaTime, 0,Space.World);
    }
}
