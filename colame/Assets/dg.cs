using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dg : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(-.1f, 0, 0);
    }
    void OnTriggerExit(Collider other)
    {
        //Destroy(other.gameObject);
        other.gameObject.GetComponent<Renderer>().material.color = Color.red;
        Debug.Log("checkedddddddddddddddddddd");
        if (other.gameObject.tag == "c")
        {
            //Destroy(other.gameObject);
            other.gameObject.GetComponent<Renderer>().material.color = Color.red;
            Debug.Log("checkedddddddddddddddddddd");
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        other.gameObject.GetComponent<Renderer>().material.color = Color.yellow;
    }
}
