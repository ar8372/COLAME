using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyMe : MonoBehaviour
{
   // RaycastHit a;
    Ray l;
    // Start is called before the first frame update
    void Start()
    {
        // + new Vector3(0, -1, 0) this is not necessary as collision  is not checked with self.
        Vector3 pq = transform.position + new Vector3(0, -1, 0);
        Vector3 c = new Vector3(0, -1, 0);
        l = new Ray(pq, c);
    }

    // Update is called once per frame
    void Update()
    {





        Debug.DrawRay(l.origin, l.direction *5, Color.red);


        // Debug.DrawRay(pq, c*10, Color.red);


        //if (Physics.Raycast(pq,c*10,out a,Mathf.Infinity))
        //{
        //    Console.WriteLine("hiiting ");
        //    //if (a.transform.gameObject == null)
        //    //{

        //    //}
        //    // hitting on the bridge
        //}

        if (Physics.Raycast(l, Mathf.Infinity))
        {
            //Debug.Log("hi check");
           // Console.WriteLine("hiiting ");
            //if (a.transform.gameObject == null)
            //{

            //}
            // hitting on the bridge
        }
        else
        {
           // Debug.Log("hi chek");
            Destroy(gameObject);
            //Console.WriteLine("not hitting");
            // Destroy(gameObject);
        }
        //if(Physics.Raycast(l,out a, Mathf.Infinity))
        //{

        //}
    }



   

}
