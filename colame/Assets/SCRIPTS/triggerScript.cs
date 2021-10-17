using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class triggerScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    private void OnTriggerStay(Collider other)
    {
        if (UImanager.instance.lifeState == 5 || UImanager.instance.lifeState == 7)
        {
            if (other.gameObject.tag == "CrystalBlue" || other.gameObject.tag == "CrystalRed" || other.gameObject.tag == "CrystalGreen"|| other.gameObject.tag == "BorderGreen"|| other.gameObject.tag == "BorderRed"|| other.gameObject.tag == "BorderBlue")
            {
                Destroy(other.gameObject);
                Debug.Log("deeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeee");
            }
        }
    }

}
