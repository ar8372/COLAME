using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class instagram : MonoBehaviour
{
    public GameObject saj;
    // Start is called before the first frame update
    void Start()
    {
        Instantiate(saj, gameObject.transform.GetChild(0).transform.position, Quaternion.identity);
        Debug.Log(gameObject.transform.GetChild(0).transform.position + "this the location of chilld where cube is spawnned") ;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
