using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyRedCrystal : MonoBehaviour
{
   

    public int massOfACrystal;
    public int differenceOfMass;

    // Start is called before the first frame update
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





        Debug.DrawRay(l.origin, l.direction * 5, Color.red);


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

    private void OnTriggerEnter(Collider other)
    {
        if (PointsManager.instance.gamestate == 10)
        {
            return;
        }
        
            if (other.gameObject.transform.tag == "PlayerRed")
            {
                PointsManager.instance.increaseDiamonds();
            // coin = Instantiate(coinPrefab, transform.position, Quaternion.identity);
            GameObject CRYSTAL8 = gameObject.transform.GetChild(7).gameObject;
            PointsManager.instance.Instantiatecoin(CRYSTAL8.transform.position);
            Destroy(gameObject);
               
            }
            else if (other.gameObject.transform.tag == "PlayerGreen" || other.gameObject.transform.tag == "PlayerBlue")
            {
                //////////////////destroying gameobject////////////
                if (PointsManager.instance.speed<180)
                {
                    Destroy(gameObject, 7f);
                    
                }
                else
                {
                    Destroy(gameObject, 5f);
                }

                PointsManager.instance.OnWrongCollision();
                Rigidbody rb = gameObject.GetComponent<Rigidbody>();
                BoxCollider bc = gameObject.GetComponent<BoxCollider>();
                bc.isTrigger = false;
                // rb.useGravity = true;
                bc.enabled = false;
                GameObject CRYSTAL1 = gameObject.transform.GetChild(0).gameObject;
                GameObject CRYSTAL2 = gameObject.transform.GetChild(1).gameObject;
                GameObject CRYSTAL3 = gameObject.transform.GetChild(2).gameObject;
                GameObject CRYSTAL4 = gameObject.transform.GetChild(3).gameObject;
                GameObject CRYSTAL5 = gameObject.transform.GetChild(4).gameObject;
                GameObject CRYSTAL6 = gameObject.transform.GetChild(5).gameObject;
                GameObject CRYSTAL7 = gameObject.transform.GetChild(6).gameObject;

                CRYSTAL1.GetComponent<CapsuleCollider>().enabled = true;
                CRYSTAL1.GetComponent<Rigidbody>().useGravity = true;
                CRYSTAL1.GetComponent<Rigidbody>().mass = massOfACrystal+(6* differenceOfMass);

                CRYSTAL2.GetComponent<CapsuleCollider>().enabled = true;
                CRYSTAL2.GetComponent<Rigidbody>().useGravity = true;
                CRYSTAL2.GetComponent<Rigidbody>().mass = massOfACrystal+(5* differenceOfMass);

                CRYSTAL3.GetComponent<CapsuleCollider>().enabled = true;
                CRYSTAL3.GetComponent<Rigidbody>().useGravity = true;
                CRYSTAL3.GetComponent<Rigidbody>().mass = massOfACrystal+(4* differenceOfMass);

                CRYSTAL4.GetComponent<CapsuleCollider>().enabled = true;
                CRYSTAL4.GetComponent<Rigidbody>().useGravity = true;
                CRYSTAL4.GetComponent<Rigidbody>().mass = massOfACrystal+(3* differenceOfMass);


                CRYSTAL5.GetComponent<CapsuleCollider>().enabled = true;
                CRYSTAL5.GetComponent<Rigidbody>().useGravity = true;
                CRYSTAL5.GetComponent<Rigidbody>().mass = massOfACrystal+(2* differenceOfMass);

                CRYSTAL6.GetComponent<CapsuleCollider>().enabled = true;
                CRYSTAL6.GetComponent<Rigidbody>().useGravity = true;
                CRYSTAL6.GetComponent<Rigidbody>().mass = massOfACrystal+ differenceOfMass;

                CRYSTAL7.GetComponent<CapsuleCollider>().enabled = true;
                CRYSTAL7.GetComponent<Rigidbody>().useGravity = true;
                CRYSTAL7.GetComponent<Rigidbody>().mass = massOfACrystal;




            }
        
            
    }



}
