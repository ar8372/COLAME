using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;
using Random = UnityEngine.Random;

public class SPAWNINGpT : MonoBehaviour
{
    public int FLAG = 0;
    int STATEiNVOKE = 0;     ///////////////Experimental

    int InvokeState = 0;                       /////////////this was introduced to check invoke at the end

    int lastthingspawwned = 0;
    int lastborderspawwned = 2;
    //0 for nothing ,1 for redborder ,2 for greenborder ,3 for yellowborder ,4 for crystal pack RGB ,5 for crystal pack RBG,6 for crystal pack GRB,7 for crystal pack GBR ,8 for crystal pack BRG,9 for crystal pack BGR; 
    // lastborderspawwned=0,1 for redborder,2 for greenborder,3 for blueborder;

    public GameObject crystalred, crystalgreen, crystalblue, borderred,bordergreen,borderblue;
   // public GameObject bordercrystalPosLeft, bordercrystalPosMiddle, bordercrystalPosRight;

    int randomNOborder;

    bool initialspawn = true;
    public bool gameState = false;


    int flag=1;
    public float MaxrangeOfDist;
    public float MinrangeOfDist;
    public float MinimalrangeOfDist;

    public GameObject player;
    Vector3 spawnigptvector;

    bool validToSpawn =true;

    public GameObject bridgePrefab;

    GameObject spawnedBridgeObject;


    // Start is called before the first frame update
    void Start()
    {
       // Debug.Log("hi there");
       // spawnigptvector = spawnpt.transform.position;
        spawnigptvector = new Vector3(0,0,19);
        //InvokeRepeating(spawnBridge(), 2f, 2f);

        PointsManager.instance.LocationOfSpawningBridge = spawnigptvector;
       
       


    }

    // Update is called once per frame
    void Update()
    {
        
        ///////////////////////////////////////////////////////////////////////////////////////////////////
        if (PointsManager.instance.gamestate==0&&FLAG==0)
        {
            STATEiNVOKE = 1;

        }
        if (STATEiNVOKE==1)
        {
            FLAG = 1;   ////////////this will prevent re invoking on any further mouse click
            
            InvokeRepeating("spawnBridge", 1f, 1f);
            STATEiNVOKE = 2;

            InvokeState = 1;
            Debug.Log("reeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeee");

        }
        if ((player.transform.position - spawnigptvector).magnitude < MinrangeOfDist && STATEiNVOKE == 3)
        {
            

            InvokeRepeating("spawnBridge", 1f, 1f);
            STATEiNVOKE = 2;

            InvokeState = 1;


        }



        if ((player.transform.position - spawnigptvector).magnitude > MaxrangeOfDist &&(STATEiNVOKE==2||STATEiNVOKE==4))
        {
            
           
            CancelInvoke("spawnBridge");
            STATEiNVOKE = 3;

            InvokeState = 0;
            
        }
        if ((player.transform.position - spawnigptvector).magnitude < MinimalrangeOfDist &&STATEiNVOKE==2)
        {
            CancelInvoke("spawnBridge");
            //InvokeRepeating("spawnBridge", 1f, .5f);   $
            InvokeRepeating("spawnBridge", .1f, .2f);
            STATEiNVOKE = 4;

            InvokeState = 1;
            
        }
        


        //else { CancelInvoke("spawnBridge");
        //    Console.WriteLine("error");
        //    Debug.Log("error");
        //}

       

        //////////////////////////////////////////EXPERIMENT///////////////////////////////////////
       // if (Input.GetMouseButtonDown(0))
       // {
       //     gameState = true;

       // }
       // if (gameState && initialspawn)
       // {
       //     InvokeState = 1;  /////////////////Invoking right now
       //     InvokeRepeating("spawnBridge", 1f, 1f);
       //     initialspawn = false;
       //     //transform.Translate(0, 0, forceToBall * Time.deltaTime);

       // }
       // Console.WriteLine("hi check");
       //// Debug.Log("hi there update");


       // if ((player.transform.position - spawnigptvector).magnitude > MaxrangeOfDist&&flag==1)
       // {
       //     validToSpawn = false;
       //     flag = 0;
       //     CancelInvoke("spawnBridge");
       //     InvokeState = 0;  ///////////////////not invoking right now
       //     Console.WriteLine("enter2");
       //     Debug.Log("enter2");
       // }
       // else if ((player.transform.position - spawnigptvector).magnitude < MinrangeOfDist && (player.transform.position - spawnigptvector).magnitude > MinimalrangeOfDist && flag == 0)
       // {
       //     validToSpawn = true;
       //     flag = 1;
       //     if (PointsManager.instance.level == 1 || PointsManager.instance.level == 3 || PointsManager.instance.level == 6 || PointsManager.instance.level == 9)
       //     {
       //         InvokeRepeating("spawnBridge", 1f, .5f);
       //     }
       //     else
       //     {
       //         InvokeRepeating("spawnBridge", 1f, 1f);
       //     }

       //     InvokeState = 1;   ////////////////////////invoking right now
       //     Console.WriteLine("enter1");
       //     Debug.Log("enter1");
       // }
       // else if ((player.transform.position - spawnigptvector).magnitude < MinimalrangeOfDist && flag == 1)
       // {
       //     validToSpawn = true;
       //     flag = 1;
       //     CancelInvoke("spawnBridge");
       //     if(PointsManager.instance.level==1|| PointsManager.instance.level == 3 || PointsManager.instance.level == 6 || PointsManager.instance.level == 9)
       //     {
       //         InvokeRepeating("spawnBridge", 1f, .5f);
       //     }
       //     else
       //     {
       //         InvokeRepeating("spawnBridge", 1f, 1f);
       //     }
            
       //     InvokeState = 1;   ////////////////////////invoking right now
       //     Console.WriteLine("enter1");
       //     Debug.Log("enter1");
       // }
         
        
        //else { CancelInvoke("spawnBridge");
        //    Console.WriteLine("error");
        //    Debug.Log("error");
        //}

        //////////////////////////////////////this part is about cancelling invoke at the end of game
        if (PointsManager.instance.gamestate == 10)
        {
            if (InvokeState == 0)
            {
                //////////////not invoking so ok
            }
            else if (InvokeState == 1)
            {
                ////////////////invoking right now so cancel it
                CancelInvoke("spawnBridge");
                InvokeState = 0;
            }
        }


    }
    
   ////////////////////////////////////SEND LOCATION OF SPAWNING POINT//////////////////////////
   public void spawningPointLocation()
    {
        PointsManager.instance.LocationOfSpawningBridge = spawnigptvector;
        Debug.Log(spawnigptvector+"hello this is location of spawnning point");
    }
    void spawnBridge()
    {
        ///////////////////
        int Phase = PointsManager.instance.scoreInt % 6000;
        //////////////////
        
        spawnedBridgeObject = Instantiate(bridgePrefab, spawnigptvector, Quaternion.identity);
        GameObject ChildGameObject1 = spawnedBridgeObject.transform.GetChild(2).gameObject;
        spawnigptvector = ChildGameObject1.transform.position;
        spawningPointLocation();           ///////////////////////////this was to get access to location of spawning point for to bring the island



        GameObject Zborder = spawnedBridgeObject.transform.GetChild(5).gameObject;
        GameObject Zcrystalleft = spawnedBridgeObject.transform.GetChild(6).gameObject;
        GameObject Zcrystalmiddle = spawnedBridgeObject.transform.GetChild(7).gameObject;
        GameObject Zcrystalright = spawnedBridgeObject.transform.GetChild(8).gameObject;
        GameObject ZBleft = spawnedBridgeObject.transform.GetChild(9).gameObject;
        GameObject ZBmiddle = spawnedBridgeObject.transform.GetChild(10).gameObject;
        GameObject ZBright = spawnedBridgeObject.transform.GetChild(11).gameObject;

        

        /////////////////////////////////BORDER POSITION FILLING

        randomNOborder = Random.Range(0, 20);
        if (randomNOborder < 3 && (lastthingspawwned!=1&& lastthingspawwned != 2&& lastthingspawwned != 3)) //takes care of two consecutive borders
        {
            ////////////////////////////////////////////////////border spawning

           
            // lastborderspawwned takes care of any two same color border being spawwned consecutively
            int abk = Random.Range(0, 2);
            if (lastborderspawwned == 1)
            {
                if (abk == 0)
                {
                    GameObject b = Instantiate(bordergreen, Zborder.transform.position, Quaternion.identity);
                    lastthingspawwned = 2;
                    lastborderspawwned = 2;
                }
                if (abk == 1)
                {
                    GameObject c = Instantiate(borderblue, Zborder.transform.position, Quaternion.identity);
                    lastthingspawwned = 3;
                    lastborderspawwned = 3;
                }
            }
           else if (lastborderspawwned == 2)
            {
                if (abk == 0)
                {
                    GameObject c = Instantiate(borderblue, Zborder.transform.position, Quaternion.identity);
                    lastthingspawwned = 3;
                    lastborderspawwned = 3;
                }
                if (abk == 1)
                {
                    GameObject a = Instantiate(borderred, Zborder.transform.position, Quaternion.identity);
                    lastthingspawwned = 1;
                    lastborderspawwned = 1;
                }
            }
           else if (lastborderspawwned == 3)
            {
                if (abk == 0)
                {
                    GameObject b = Instantiate(bordergreen, Zborder.transform.position, Quaternion.identity);
                    lastthingspawwned = 2;
                    lastborderspawwned = 2;
                }
                if (abk == 1)
                {
                    GameObject a = Instantiate(borderred, Zborder.transform.position, Quaternion.identity);
                    lastthingspawwned = 1;
                    lastborderspawwned = 1;
                }
            }
        }
        
        else if (randomNOborder < 20)
        {    
            //////////////////////////////////////////////////////////////////////////////////CRYSTAL SPAWNING
            //0 for nothing ,1 for redborder ,2 for greenborder ,3 for yellowborder ,4 for crystal pack RGB ,5 for crystal pack RBG,6 for crystal pack GRB,7 for crystal pack GBR ,8 for crystal pack BRG,9 for crystal pack BGR; 
            int randomNOcrystal1 = Random.Range(0, 6001);
            // to be worked out for other level?? float randomRotationCrystal = Random.Range(0, 5f);
            ////?????????????????????????????????????????????????????????????????????????????????????????????????????10//////////////5//////////////
            if (randomNOcrystal1 < Phase+3000)                // randomNOcrystal was creating problem since used inside other fn also so put 1 in front
            {
                GameObject[] crystal1 = { crystalred, crystalgreen, crystalblue };       // randomNOcrystal was creating problem since used inside other fn also so put 1 in front
                //crystal spawning new technique generating random

                //int NoOfCrystals;
                //if (PointsManager.instance.level==2|| PointsManager.instance.level == 3 || PointsManager.instance.level == 5 || PointsManager.instance.level == 6 || PointsManager.instance.level == 8 || PointsManager.instance.level == 9)
                //{
                //    NoOfCrystals = Random.Range(0, 3);  ///////////////////////////this will make sure that only one crystal is instantiated in given levels
                //}
                //else
                //{
                //    NoOfCrystals = Random.Range(0, 2);
                //}       $


                int NoOfCrystals;
                if (PointsManager.instance.level == 1 || PointsManager.instance.level == 3 || PointsManager.instance.level >= 6)
                {
                    NoOfCrystals = Random.Range(0, 3);  ///////////////////////////this will make sure that only one crystal is instantiated in given levels
                }
                else
                {
                    NoOfCrystals = Random.Range(0, 2);
                }




                if (NoOfCrystals == 0)
                {
                    //no crystal instantiated
                    if (Phase >= 4000)    ////$ made to make more dense 
                    {
                        //one crystal instantiated
                        int CrystalColor = Random.Range(0, 3);
                        if (CrystalColor == 0)
                        {
                            //red crystal instantiated
                            int PosOfCrystal = Random.Range(0, 3);
                            if (PosOfCrystal == 0)
                            {
                                //left side crystal is created
                                GameObject a = Instantiate(crystal1[0], ZBleft.transform.position, Quaternion.identity);
                                //GameObject b = Instantiate(crystal[0], Zcrystalmiddle.transform.position, Quaternion.identity);
                                //GameObject c = Instantiate(crystal[1], Zcrystalright.transform.position, Quaternion.identity);
                                lastthingspawwned = 8;
                                a.transform.Rotate(0, Random.Range(0, 360), 0);
                                // b.transform.Rotate(0, Random.Range(0, 360), 0);
                                // c.transform.Rotate(0, Random.Range(0, 360), 0);
                            }
                            else if (PosOfCrystal == 1)
                            {
                                //middle side crystal is created
                                //GameObject a = Instantiate(crystal[0], Zcrystalleft.transform.position, Quaternion.identity);
                                GameObject b = Instantiate(crystal1[0], ZBmiddle.transform.position, Quaternion.identity);
                                //GameObject c = Instantiate(crystal[1], Zcrystalright.transform.position, Quaternion.identity);
                                lastthingspawwned = 8;
                                //a.transform.Rotate(0, Random.Range(0, 360), 0);
                                b.transform.Rotate(0, Random.Range(0, 360), 0);
                                //c.transform.Rotate(0, Random.Range(0, 360), 0);
                            }
                            else if (PosOfCrystal == 2)
                            {
                                //right side crystal is created
                                //GameObject a = Instantiate(crystal[0], Zcrystalleft.transform.position, Quaternion.identity);
                                //GameObject b = Instantiate(crystal[0], Zcrystalmiddle.transform.position, Quaternion.identity);
                                GameObject c = Instantiate(crystal1[1], ZBright.transform.position, Quaternion.identity);
                                lastthingspawwned = 8;
                                // a.transform.Rotate(0, Random.Range(0, 360), 0);
                                // b.transform.Rotate(0, Random.Range(0, 360), 0);
                                c.transform.Rotate(0, Random.Range(0, 360), 0);
                            }
                        }
                        else if (CrystalColor == 1)
                        {
                            //green crystal instantiated
                            int PosOfCrystal = Random.Range(0, 3);
                            if (PosOfCrystal == 0)
                            {
                                //left side crystal is created
                                GameObject a = Instantiate(crystal1[1], ZBleft.transform.position, Quaternion.identity);
                                //GameObject b = Instantiate(crystal[0], Zcrystalmiddle.transform.position, Quaternion.identity);
                                //GameObject c = Instantiate(crystal[1], Zcrystalright.transform.position, Quaternion.identity);
                                lastthingspawwned = 8;
                                a.transform.Rotate(0, Random.Range(0, 360), 0);
                                // b.transform.Rotate(0, Random.Range(0, 360), 0);
                                // c.transform.Rotate(0, Random.Range(0, 360), 0);
                            }
                            else if (PosOfCrystal == 1)
                            {
                                //middle side crystal is created
                                //GameObject a = Instantiate(crystal[2], Zcrystalleft.transform.position, Quaternion.identity);
                                GameObject b = Instantiate(crystal1[1], ZBmiddle.transform.position, Quaternion.identity);
                                //GameObject c = Instantiate(crystal[1], Zcrystalright.transform.position, Quaternion.identity);
                                lastthingspawwned = 8;
                                // a.transform.Rotate(0, Random.Range(0, 360), 0);
                                b.transform.Rotate(0, Random.Range(0, 360), 0);
                                // c.transform.Rotate(0, Random.Range(0, 360), 0);
                            }
                            else if (PosOfCrystal == 2)
                            {
                                //right side crystal is created
                                //GameObject a = Instantiate(crystal[2], Zcrystalleft.transform.position, Quaternion.identity);
                                // GameObject b = Instantiate(crystal[0], Zcrystalmiddle.transform.position, Quaternion.identity);
                                GameObject c = Instantiate(crystal1[1], ZBright.transform.position, Quaternion.identity);
                                lastthingspawwned = 8;
                                //a.transform.Rotate(0, Random.Range(0, 360), 0);
                                //b.transform.Rotate(0, Random.Range(0, 360), 0);
                                c.transform.Rotate(0, Random.Range(0, 360), 0);
                            }
                        }
                        else if (CrystalColor == 2)
                        {
                            //blue crystal instantiated
                            int PosOfCrystal = Random.Range(0, 3);
                            if (PosOfCrystal == 0)
                            {
                                //left side crystal is created
                                GameObject a = Instantiate(crystal1[2], ZBleft.transform.position, Quaternion.identity);
                                //GameObject b = Instantiate(crystal[0], Zcrystalmiddle.transform.position, Quaternion.identity);
                                // GameObject c = Instantiate(crystal[1], Zcrystalright.transform.position, Quaternion.identity);
                                lastthingspawwned = 8;
                                a.transform.Rotate(0, Random.Range(0, 360), 0);
                                // b.transform.Rotate(0, Random.Range(0, 360), 0);
                                //c.transform.Rotate(0, Random.Range(0, 360), 0);
                            }
                            else if (PosOfCrystal == 1)
                            {
                                //middle side crystal is created
                                // GameObject a = Instantiate(crystal[2], Zcrystalleft.transform.position, Quaternion.identity);
                                GameObject b = Instantiate(crystal1[2], ZBmiddle.transform.position, Quaternion.identity);
                                // GameObject c = Instantiate(crystal[1], Zcrystalright.transform.position, Quaternion.identity);
                                lastthingspawwned = 8;
                                // a.transform.Rotate(0, Random.Range(0, 360), 0);
                                b.transform.Rotate(0, Random.Range(0, 360), 0);
                                // c.transform.Rotate(0, Random.Range(0, 360), 0);
                            }
                            else if (PosOfCrystal == 2)
                            {
                                //right side crystal is created
                                //GameObject a = Instantiate(crystal[2], Zcrystalleft.transform.position, Quaternion.identity);
                                //GameObject b = Instantiate(crystal[0], Zcrystalmiddle.transform.position, Quaternion.identity);
                                GameObject c = Instantiate(crystal1[2], ZBright.transform.position, Quaternion.identity);
                                lastthingspawwned = 8;
                                // a.transform.Rotate(0, Random.Range(0, 360), 0);
                                // b.transform.Rotate(0, Random.Range(0, 360), 0);
                                c.transform.Rotate(0, Random.Range(0, 360), 0);
                            }
                        }
                    }
                }
                else if (NoOfCrystals == 1)   //here approach different from that of when NoOfCrystals==2 there everything summed at first only here it is hierarchy but benefit of NoOfCrystals ==2 aproach we dont need to write multiple times random
                {
                    //one crystal instantiated
                    int CrystalColor = Random.Range(0, 3);
                    if (CrystalColor == 0)
                    {
                        //red crystal instantiated
                        int PosOfCrystal = Random.Range(0, 3);
                        if (PosOfCrystal == 0)
                        {
                            //left side crystal is created
                            GameObject a = Instantiate(crystal1[0], ZBleft.transform.position, Quaternion.identity);
                            //GameObject b = Instantiate(crystal[0], Zcrystalmiddle.transform.position, Quaternion.identity);
                            //GameObject c = Instantiate(crystal[1], Zcrystalright.transform.position, Quaternion.identity);
                            lastthingspawwned = 8;
                            a.transform.Rotate(0, Random.Range(0, 360), 0);
                            // b.transform.Rotate(0, Random.Range(0, 360), 0);
                            // c.transform.Rotate(0, Random.Range(0, 360), 0);
                        }
                        else if (PosOfCrystal == 1)
                        {
                            //middle side crystal is created
                            //GameObject a = Instantiate(crystal[0], Zcrystalleft.transform.position, Quaternion.identity);
                            GameObject b = Instantiate(crystal1[0], ZBmiddle.transform.position, Quaternion.identity);
                            //GameObject c = Instantiate(crystal[1], Zcrystalright.transform.position, Quaternion.identity);
                            lastthingspawwned = 8;
                            //a.transform.Rotate(0, Random.Range(0, 360), 0);
                            b.transform.Rotate(0, Random.Range(0, 360), 0);
                            //c.transform.Rotate(0, Random.Range(0, 360), 0);
                        }
                        else if (PosOfCrystal == 2)
                        {
                            //right side crystal is created
                            //GameObject a = Instantiate(crystal[0], Zcrystalleft.transform.position, Quaternion.identity);
                            //GameObject b = Instantiate(crystal[0], Zcrystalmiddle.transform.position, Quaternion.identity);
                            GameObject c = Instantiate(crystal1[1], ZBright.transform.position, Quaternion.identity);
                            lastthingspawwned = 8;
                            // a.transform.Rotate(0, Random.Range(0, 360), 0);
                            // b.transform.Rotate(0, Random.Range(0, 360), 0);
                            c.transform.Rotate(0, Random.Range(0, 360), 0);
                        }
                    }
                    else if (CrystalColor == 1)
                    {
                        //green crystal instantiated
                        int PosOfCrystal = Random.Range(0, 3);
                        if (PosOfCrystal == 0)
                        {
                            //left side crystal is created
                            GameObject a = Instantiate(crystal1[1], ZBleft.transform.position, Quaternion.identity);
                            //GameObject b = Instantiate(crystal[0], Zcrystalmiddle.transform.position, Quaternion.identity);
                            //GameObject c = Instantiate(crystal[1], Zcrystalright.transform.position, Quaternion.identity);
                            lastthingspawwned = 8;
                            a.transform.Rotate(0, Random.Range(0, 360), 0);
                            // b.transform.Rotate(0, Random.Range(0, 360), 0);
                            // c.transform.Rotate(0, Random.Range(0, 360), 0);
                        }
                        else if (PosOfCrystal == 1)
                        {
                            //middle side crystal is created
                            //GameObject a = Instantiate(crystal[2], Zcrystalleft.transform.position, Quaternion.identity);
                            GameObject b = Instantiate(crystal1[1], ZBmiddle.transform.position, Quaternion.identity);
                            //GameObject c = Instantiate(crystal[1], Zcrystalright.transform.position, Quaternion.identity);
                            lastthingspawwned = 8;
                            // a.transform.Rotate(0, Random.Range(0, 360), 0);
                            b.transform.Rotate(0, Random.Range(0, 360), 0);
                            // c.transform.Rotate(0, Random.Range(0, 360), 0);
                        }
                        else if (PosOfCrystal == 2)
                        {
                            //right side crystal is created
                            //GameObject a = Instantiate(crystal[2], Zcrystalleft.transform.position, Quaternion.identity);
                            // GameObject b = Instantiate(crystal[0], Zcrystalmiddle.transform.position, Quaternion.identity);
                            GameObject c = Instantiate(crystal1[1], ZBright.transform.position, Quaternion.identity);
                            lastthingspawwned = 8;
                            //a.transform.Rotate(0, Random.Range(0, 360), 0);
                            //b.transform.Rotate(0, Random.Range(0, 360), 0);
                            c.transform.Rotate(0, Random.Range(0, 360), 0);
                        }
                    }
                    else if (CrystalColor == 2)
                    {
                        //blue crystal instantiated
                        int PosOfCrystal = Random.Range(0, 3);
                        if (PosOfCrystal == 0)
                        {
                            //left side crystal is created
                            GameObject a = Instantiate(crystal1[2], ZBleft.transform.position, Quaternion.identity);
                            //GameObject b = Instantiate(crystal[0], Zcrystalmiddle.transform.position, Quaternion.identity);
                            // GameObject c = Instantiate(crystal[1], Zcrystalright.transform.position, Quaternion.identity);
                            lastthingspawwned = 8;
                            a.transform.Rotate(0, Random.Range(0, 360), 0);
                            // b.transform.Rotate(0, Random.Range(0, 360), 0);
                            //c.transform.Rotate(0, Random.Range(0, 360), 0);
                        }
                        else if (PosOfCrystal == 1)
                        {
                            //middle side crystal is created
                            // GameObject a = Instantiate(crystal[2], Zcrystalleft.transform.position, Quaternion.identity);
                            GameObject b = Instantiate(crystal1[2], ZBmiddle.transform.position, Quaternion.identity);
                            // GameObject c = Instantiate(crystal[1], Zcrystalright.transform.position, Quaternion.identity);
                            lastthingspawwned = 8;
                            // a.transform.Rotate(0, Random.Range(0, 360), 0);
                            b.transform.Rotate(0, Random.Range(0, 360), 0);
                            // c.transform.Rotate(0, Random.Range(0, 360), 0);
                        }
                        else if (PosOfCrystal == 2)
                        {
                            //right side crystal is created
                            //GameObject a = Instantiate(crystal[2], Zcrystalleft.transform.position, Quaternion.identity);
                            //GameObject b = Instantiate(crystal[0], Zcrystalmiddle.transform.position, Quaternion.identity);
                            GameObject c = Instantiate(crystal1[2], ZBright.transform.position, Quaternion.identity);
                            lastthingspawwned = 8;
                            // a.transform.Rotate(0, Random.Range(0, 360), 0);
                            // b.transform.Rotate(0, Random.Range(0, 360), 0);
                            c.transform.Rotate(0, Random.Range(0, 360), 0);
                        }
                    }
                }
                else if (NoOfCrystals == 2)
                {
                    //two crystal instantiated
                    int orderSet = Random.Range(0, 27);
                    //orderSet 0=R-R,1=G-G,2=B-B,3=R-G,4=G-R,5=R-G,6=B-R,7=B-G,8=G-B,    , 9=-RR,10=-GG,11=-BB,12=-RG,13=-GR,14=-RB,15=-BR,16=-BG,17=-GB,    ,18=RR,19=GG,20=BB,21=RG,22=GR-,23=RB-,24=BR-,25=BG-,26=GB-
                    if (orderSet == 0)
                    {
                        GameObject a = Instantiate(crystal1[0], ZBleft.transform.position, Quaternion.identity);
                        //GameObject b = Instantiate(crystal[1], Zcrystalmiddle.transform.position, Quaternion.identity);
                        GameObject c = Instantiate(crystal1[0], ZBright.transform.position, Quaternion.identity);
                        lastthingspawwned = 4;
                        a.transform.Rotate(0, Random.Range(0, 360), 0);
                        // b.transform.Rotate(0, Random.Range(0, 360), 0);
                        c.transform.Rotate(0, Random.Range(0, 360), 0);
                    }
                    else if (orderSet == 1)
                    {
                        GameObject a = Instantiate(crystal1[1], ZBleft.transform.position, Quaternion.identity);
                        //GameObject b = Instantiate(crystal[1], Zcrystalmiddle.transform.position, Quaternion.identity);
                        GameObject c = Instantiate(crystal1[1], ZBright.transform.position, Quaternion.identity);
                        lastthingspawwned = 4;
                        a.transform.Rotate(0, Random.Range(0, 360), 0);
                        // b.transform.Rotate(0, Random.Range(0, 360), 0);
                        c.transform.Rotate(0, Random.Range(0, 360), 0);
                    }
                    else if (orderSet == 2)
                    {
                        GameObject a = Instantiate(crystal1[2], ZBleft.transform.position, Quaternion.identity);
                        //GameObject b = Instantiate(crystal[1], Zcrystalmiddle.transform.position, Quaternion.identity);
                        GameObject c = Instantiate(crystal1[2], ZBright.transform.position, Quaternion.identity);
                        lastthingspawwned = 4;
                        a.transform.Rotate(0, Random.Range(0, 360), 0);
                        //b.transform.Rotate(0, Random.Range(0, 360), 0);
                        c.transform.Rotate(0, Random.Range(0, 360), 0);
                    }
                    else if (orderSet == 3)
                    {
                        GameObject a = Instantiate(crystal1[0], ZBleft.transform.position, Quaternion.identity);
                        //GameObject b = Instantiate(crystal[1], Zcrystalmiddle.transform.position, Quaternion.identity);
                        GameObject c = Instantiate(crystal1[1], ZBright.transform.position, Quaternion.identity);
                        lastthingspawwned = 4;
                        a.transform.Rotate(0, Random.Range(0, 360), 0);
                        //b.transform.Rotate(0, Random.Range(0, 360), 0);
                        c.transform.Rotate(0, Random.Range(0, 360), 0);
                    }
                    else if (orderSet == 4)
                    {
                        GameObject a = Instantiate(crystal1[1], ZBleft.transform.position, Quaternion.identity);
                        //GameObject b = Instantiate(crystal[1], Zcrystalmiddle.transform.position, Quaternion.identity);
                        GameObject c = Instantiate(crystal1[0], ZBright.transform.position, Quaternion.identity);
                        lastthingspawwned = 4;
                        a.transform.Rotate(0, Random.Range(0, 360), 0);
                        //b.transform.Rotate(0, Random.Range(0, 360), 0);
                        c.transform.Rotate(0, Random.Range(0, 360), 0);
                    }
                    else if (orderSet == 5)
                    {
                        GameObject a = Instantiate(crystal1[0], ZBleft.transform.position, Quaternion.identity);
                        //GameObject b = Instantiate(crystal[1], Zcrystalmiddle.transform.position, Quaternion.identity);
                        GameObject c = Instantiate(crystal1[2], ZBright.transform.position, Quaternion.identity);
                        lastthingspawwned = 4;
                        a.transform.Rotate(0, Random.Range(0, 360), 0);
                        //b.transform.Rotate(0, Random.Range(0, 360), 0);
                        c.transform.Rotate(0, Random.Range(0, 360), 0);
                    }
                    else if (orderSet == 6)
                    {
                        GameObject a = Instantiate(crystal1[2], ZBleft.transform.position, Quaternion.identity);
                        //GameObject b = Instantiate(crystal[1], Zcrystalmiddle.transform.position, Quaternion.identity);
                        GameObject c = Instantiate(crystal1[0], ZBright.transform.position, Quaternion.identity);
                        lastthingspawwned = 4;
                        a.transform.Rotate(0, Random.Range(0, 360), 0);
                        //b.transform.Rotate(0, Random.Range(0, 360), 0);
                        c.transform.Rotate(0, Random.Range(0, 360), 0);
                    }
                    else if (orderSet == 7)
                    {
                        GameObject a = Instantiate(crystal1[2], ZBleft.transform.position, Quaternion.identity);
                        //GameObject b = Instantiate(crystal[1], Zcrystalmiddle.transform.position, Quaternion.identity);
                        GameObject c = Instantiate(crystal1[1], ZBright.transform.position, Quaternion.identity);
                        lastthingspawwned = 4;
                        a.transform.Rotate(0, Random.Range(0, 360), 0);
                        // b.transform.Rotate(0, Random.Range(0, 360), 0);
                        c.transform.Rotate(0, Random.Range(0, 360), 0);
                    }
                    else if (orderSet == 8)
                    {
                        if (lastthingspawwned == 11 || lastthingspawwned == 15 || lastthingspawwned == 16)
                        {
                            SpecialCaseSpawnningOfCrystal(ZBleft, ZBmiddle, ZBright, crystal1);

                        }
                        else
                        {
                            //GameObject a = Instantiate(crystal1[0], Zcrystalleft.transform.position, Quaternion.identity);
                            GameObject b = Instantiate(crystal1[1], ZBmiddle.transform.position, Quaternion.identity);
                            GameObject c = Instantiate(crystal1[2], ZBright.transform.position, Quaternion.identity);
                            // lastthingspawwned = 4;
                            lastthingspawwned = 21;
                            //a.transform.Rotate(0, Random.Range(0, 360), 0);
                            b.transform.Rotate(0, Random.Range(0, 360), 0);
                            c.transform.Rotate(0, Random.Range(0, 360), 0);
                        }
                       
                    }
                    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                    else if (orderSet == 9)
                    {
                        if (lastthingspawwned == 12 || lastthingspawwned == 13 || lastthingspawwned == 14 || lastthingspawwned == 15 || lastthingspawwned == 16)
                        {
                            SpecialCaseSpawnningOfCrystal(ZBleft, ZBmiddle, ZBright, crystal1);

                        }
                        else
                        {
                            //GameObject a = Instantiate(crystal[0], Zcrystalleft.transform.position, Quaternion.identity);
                            GameObject b = Instantiate(crystal1[0], ZBmiddle.transform.position, Quaternion.identity);
                            GameObject c = Instantiate(crystal1[0], ZBright.transform.position, Quaternion.identity);
                            lastthingspawwned = 24;
                            // a.transform.Rotate(0, Random.Range(0, 360), 0);
                            b.transform.Rotate(0, Random.Range(0, 360), 0);
                            c.transform.Rotate(0, Random.Range(0, 360), 0);
                        }
                       
                    }
                    else if (orderSet == 10)
                    {
                        if (lastthingspawwned == 11 || lastthingspawwned == 13 || lastthingspawwned == 14 || lastthingspawwned == 15 || lastthingspawwned == 16 )
                        {
                            SpecialCaseSpawnningOfCrystal(ZBleft, ZBmiddle, ZBright, crystal1);

                        }
                        else
                        {
                            //GameObject a = Instantiate(crystal[0], Zcrystalleft.transform.position, Quaternion.identity);
                            GameObject b = Instantiate(crystal1[1], ZBmiddle.transform.position, Quaternion.identity);
                            GameObject c = Instantiate(crystal1[1], ZBright.transform.position, Quaternion.identity);
                            lastthingspawwned = 25;
                            //a.transform.Rotate(0, Random.Range(0, 360), 0);
                            b.transform.Rotate(0, Random.Range(0, 360), 0);
                            c.transform.Rotate(0, Random.Range(0, 360), 0);
                        }

                       
                    }
                    else if (orderSet == 11)
                    {
                        if (lastthingspawwned == 11 || lastthingspawwned == 12  || lastthingspawwned == 14 || lastthingspawwned == 15 || lastthingspawwned == 16)
                        {
                            SpecialCaseSpawnningOfCrystal(ZBleft, ZBmiddle, ZBright, crystal1);

                        }
                        else
                        {
                            //GameObject a = Instantiate(crystal[0], Zcrystalleft.transform.position, Quaternion.identity);
                            GameObject b = Instantiate(crystal1[2], ZBmiddle.transform.position, Quaternion.identity);
                            GameObject c = Instantiate(crystal1[2], ZBright.transform.position, Quaternion.identity);
                            lastthingspawwned = 26;
                            //a.transform.Rotate(0, Random.Range(0, 360), 0);
                            b.transform.Rotate(0, Random.Range(0, 360), 0);
                            c.transform.Rotate(0, Random.Range(0, 360), 0);
                        }
                       
                    }
                    else if (orderSet == 12)
                    {
                        if (  lastthingspawwned == 13 || lastthingspawwned == 14 || lastthingspawwned == 15)
                        {
                            SpecialCaseSpawnningOfCrystal(ZBleft, ZBmiddle, ZBright, crystal1);

                        }
                        else
                        {
                            //GameObject a = Instantiate(crystal[0], Zcrystalleft.transform.position, Quaternion.identity);
                            GameObject b = Instantiate(crystal1[0], ZBmiddle.transform.position, Quaternion.identity);
                            GameObject c = Instantiate(crystal1[1], ZBright.transform.position, Quaternion.identity);
                            lastthingspawwned = 23;
                            //a.transform.Rotate(0, Random.Range(0, 360), 0);
                            b.transform.Rotate(0, Random.Range(0, 360), 0);
                            c.transform.Rotate(0, Random.Range(0, 360), 0);
                        }
                        
                    }
                    else if (orderSet == 13)
                    {
                        if ( lastthingspawwned == 13 || lastthingspawwned == 14 || lastthingspawwned == 15)
                        {
                            SpecialCaseSpawnningOfCrystal(ZBleft, ZBmiddle, ZBright, crystal1);

                        }
                        else
                        {
                            //GameObject a = Instantiate(crystal[0], Zcrystalleft.transform.position, Quaternion.identity);
                            GameObject b = Instantiate(crystal1[1], ZBmiddle.transform.position, Quaternion.identity);
                            GameObject c = Instantiate(crystal1[0], ZBright.transform.position, Quaternion.identity);
                            lastthingspawwned = 23;
                            //a.transform.Rotate(0, Random.Range(0, 360), 0);
                            b.transform.Rotate(0, Random.Range(0, 360), 0);
                            c.transform.Rotate(0, Random.Range(0, 360), 0);
                        }
                       
                    }
                    else if (orderSet == 14)
                    {
                        if ( lastthingspawwned == 12 ||  lastthingspawwned == 14  || lastthingspawwned == 16)
                        {
                            SpecialCaseSpawnningOfCrystal(ZBleft, ZBmiddle, ZBright, crystal1);

                        }
                        else
                        {
                            // GameObject a = Instantiate(crystal[0], Zcrystalleft.transform.position, Quaternion.identity);
                            GameObject b = Instantiate(crystal1[0], ZBmiddle.transform.position, Quaternion.identity);
                            GameObject c = Instantiate(crystal1[2], ZBright.transform.position, Quaternion.identity);
                            lastthingspawwned = 22;
                            //a.transform.Rotate(0, Random.Range(0, 360), 0);
                            b.transform.Rotate(0, Random.Range(0, 360), 0);
                            c.transform.Rotate(0, Random.Range(0, 360), 0);
                        }
                       
                    }
                    else if (orderSet == 15)
                    {
                        if ( lastthingspawwned == 12 ||  lastthingspawwned == 14 ||  lastthingspawwned == 16 )
                        {
                            SpecialCaseSpawnningOfCrystal(ZBleft, ZBmiddle, ZBright, crystal1);

                        }
                        else
                        {
                            //GameObject a = Instantiate(crystal[0], Zcrystalleft.transform.position, Quaternion.identity);
                            GameObject b = Instantiate(crystal1[2], ZBmiddle.transform.position, Quaternion.identity);
                            GameObject c = Instantiate(crystal1[0], ZBright.transform.position, Quaternion.identity);
                            lastthingspawwned = 22;
                            //a.transform.Rotate(0, Random.Range(0, 360), 0);
                            b.transform.Rotate(0, Random.Range(0, 360), 0);
                            c.transform.Rotate(0, Random.Range(0, 360), 0);
                        }
                       
                    }
                    else if (orderSet == 16)
                    {
                        if (lastthingspawwned == 11|| lastthingspawwned == 15 || lastthingspawwned == 16 )
                        {
                            SpecialCaseSpawnningOfCrystal(ZBleft, ZBmiddle, ZBright, crystal1);

                        }
                        else
                        {
                            //GameObject a = Instantiate(crystal[0], Zcrystalleft.transform.position, Quaternion.identity);
                            GameObject b = Instantiate(crystal1[2], ZBmiddle.transform.position, Quaternion.identity);
                            GameObject c = Instantiate(crystal1[1], ZBright.transform.position, Quaternion.identity);
                            lastthingspawwned = 21;
                            // a.transform.Rotate(0, Random.Range(0, 360), 0);
                            b.transform.Rotate(0, Random.Range(0, 360), 0);
                            c.transform.Rotate(0, Random.Range(0, 360), 0);
                        }
                       
                    }
                    else if (orderSet == 17)
                    {
                        if (lastthingspawwned == 11 || lastthingspawwned == 15 || lastthingspawwned == 16)
                        {
                            SpecialCaseSpawnningOfCrystal(ZBleft, ZBmiddle, ZBright, crystal1);

                        }
                        else
                        {
                            //GameObject a = Instantiate(crystal[0], Zcrystalleft.transform.position, Quaternion.identity);
                            GameObject b = Instantiate(crystal1[1], ZBmiddle.transform.position, Quaternion.identity);
                            GameObject c = Instantiate(crystal1[2], ZBright.transform.position, Quaternion.identity);
                            lastthingspawwned = 21;
                            //a.transform.Rotate(0, Random.Range(0, 360), 0);
                            b.transform.Rotate(0, Random.Range(0, 360), 0);
                            c.transform.Rotate(0, Random.Range(0, 360), 0);
                        }
                       
                    }

                    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                    else if (orderSet == 18)
                    {
                        if ( lastthingspawwned == 22 || lastthingspawwned == 23 || lastthingspawwned == 24 || lastthingspawwned == 25 || lastthingspawwned == 26)
                        {
                            SpecialCaseSpawnningOfCrystal(ZBleft, ZBmiddle, ZBright, crystal1);

                        }
                        else
                        {
                            GameObject a = Instantiate(crystal1[0], ZBleft.transform.position, Quaternion.identity);
                            GameObject b = Instantiate(crystal1[0], ZBmiddle.transform.position, Quaternion.identity);
                            //GameObject c = Instantiate(crystal[2], Zcrystalright.transform.position, Quaternion.identity);
                            lastthingspawwned = 14;
                            a.transform.Rotate(0, Random.Range(0, 360), 0);
                            b.transform.Rotate(0, Random.Range(0, 360), 0);
                            //c.transform.Rotate(0, Random.Range(0, 360), 0);
                        }

                    }
                    else if (orderSet == 19)
                    {
                        if (lastthingspawwned == 21 ||  lastthingspawwned == 23 || lastthingspawwned == 24 || lastthingspawwned == 25 || lastthingspawwned == 26)
                        {
                            SpecialCaseSpawnningOfCrystal(ZBleft, ZBmiddle, ZBright, crystal1);

                        }
                        else
                        {
                            GameObject a = Instantiate(crystal1[1], ZBleft.transform.position, Quaternion.identity);
                            GameObject b = Instantiate(crystal1[1], ZBmiddle.transform.position, Quaternion.identity);
                            // GameObject c = Instantiate(crystal[2], Zcrystalright.transform.position, Quaternion.identity);
                            lastthingspawwned = 15;
                            a.transform.Rotate(0, Random.Range(0, 360), 0);
                            b.transform.Rotate(0, Random.Range(0, 360), 0);
                            //c.transform.Rotate(0, Random.Range(0, 360), 0);
                        }

                    }
                    else if (orderSet == 20)
                    {
                        if ( lastthingspawwned == 21 || lastthingspawwned == 22 ||  lastthingspawwned == 24 || lastthingspawwned == 25 || lastthingspawwned == 26)
                        {
                            SpecialCaseSpawnningOfCrystal(ZBleft, ZBmiddle, ZBright, crystal1);

                        }
                        else
                        {
                            GameObject a = Instantiate(crystal1[2], ZBleft.transform.position, Quaternion.identity);
                            GameObject b = Instantiate(crystal1[2], ZBmiddle.transform.position, Quaternion.identity);
                            //GameObject c = Instantiate(crystal[2], Zcrystalright.transform.position, Quaternion.identity);
                            lastthingspawwned = 16;
                            a.transform.Rotate(0, Random.Range(0, 360), 0);
                            b.transform.Rotate(0, Random.Range(0, 360), 0);
                            //c.transform.Rotate(0, Random.Range(0, 360), 0);
                        }

                    }
                    else if (orderSet == 21)
                    {
                        if (lastthingspawwned == 13 || lastthingspawwned == 14 || lastthingspawwned == 15)
                        {
                            SpecialCaseSpawnningOfCrystal(ZBleft, ZBmiddle, ZBright, crystal1);

                        }
                        else
                        {
                            GameObject a = Instantiate(crystal1[0], ZBleft.transform.position, Quaternion.identity);
                            GameObject b = Instantiate(crystal1[1], ZBmiddle.transform.position, Quaternion.identity);
                            //GameObject c = Instantiate(crystal[2], Zcrystalright.transform.position, Quaternion.identity);
                            lastthingspawwned = 13;
                            a.transform.Rotate(0, Random.Range(0, 360), 0);
                            b.transform.Rotate(0, Random.Range(0, 360), 0);
                            // c.transform.Rotate(0, Random.Range(0, 360), 0);
                        }

                    }
                    else if (orderSet == 22)
                    {
                        if (lastthingspawwned == 13 || lastthingspawwned == 14 || lastthingspawwned == 15)
                        {
                            SpecialCaseSpawnningOfCrystal(ZBleft, ZBmiddle, ZBright, crystal1);

                        }
                        else
                        {
                            GameObject a = Instantiate(crystal1[1], ZBleft.transform.position, Quaternion.identity);
                            GameObject b = Instantiate(crystal1[0], ZBmiddle.transform.position, Quaternion.identity);
                            //GameObject c = Instantiate(crystal[2], Zcrystalright.transform.position, Quaternion.identity);
                            lastthingspawwned = 13;
                            a.transform.Rotate(0, Random.Range(0, 360), 0);
                            b.transform.Rotate(0, Random.Range(0, 360), 0);
                            //c.transform.Rotate(0, Random.Range(0, 360), 0);
                        }


                    }
                    else if (orderSet == 23)
                    {
                        if (lastthingspawwned == 12 || lastthingspawwned == 14 || lastthingspawwned == 16)
                        {
                            SpecialCaseSpawnningOfCrystal(ZBleft, ZBmiddle, ZBright, crystal1);

                        }
                        else
                        {
                            GameObject a = Instantiate(crystal1[0], ZBleft.transform.position, Quaternion.identity);
                            GameObject b = Instantiate(crystal1[2], ZBmiddle.transform.position, Quaternion.identity);
                            //GameObject c = Instantiate(crystal[2], Zcrystalright.transform.position, Quaternion.identity);
                            lastthingspawwned = 12;
                            a.transform.Rotate(0, Random.Range(0, 360), 0);
                            b.transform.Rotate(0, Random.Range(0, 360), 0);
                            //c.transform.Rotate(0, Random.Range(0, 360), 0);
                        }

                    }
                    else if (orderSet == 24)
                    {
                        if (lastthingspawwned == 12 || lastthingspawwned == 14 || lastthingspawwned == 16)
                        {
                            SpecialCaseSpawnningOfCrystal(ZBleft, ZBmiddle, ZBright, crystal1);

                        }
                        else
                        {
                            GameObject a = Instantiate(crystal1[2], ZBleft.transform.position, Quaternion.identity);
                            GameObject b = Instantiate(crystal1[0], ZBmiddle.transform.position, Quaternion.identity);
                            //GameObject c = Instantiate(crystal[2], Zcrystalright.transform.position, Quaternion.identity);
                            lastthingspawwned = 12;
                            a.transform.Rotate(0, Random.Range(0, 360), 0);
                            b.transform.Rotate(0, Random.Range(0, 360), 0);
                            // c.transform.Rotate(0, Random.Range(0, 360), 0);
                        }

                    }
                    else if (orderSet == 25)
                    {
                        if (lastthingspawwned == 11 || lastthingspawwned == 15 || lastthingspawwned == 16)
                        {
                            SpecialCaseSpawnningOfCrystal(ZBleft, ZBmiddle, ZBright, crystal1);

                        }
                        else
                        {
                            GameObject a = Instantiate(crystal1[2], ZBleft.transform.position, Quaternion.identity);
                            GameObject b = Instantiate(crystal1[1], ZBmiddle.transform.position, Quaternion.identity);
                            //GameObject c = Instantiate(crystal[2], Zcrystalright.transform.position, Quaternion.identity);
                            lastthingspawwned = 11;
                            a.transform.Rotate(0, Random.Range(0, 360), 0);
                            b.transform.Rotate(0, Random.Range(0, 360), 0);
                            //c.transform.Rotate(0, Random.Range(0, 360), 0);
                        }

                    }
                    else if (orderSet == 26)
                    {
                        if (lastthingspawwned == 11 || lastthingspawwned == 15 || lastthingspawwned == 16)
                        {
                            SpecialCaseSpawnningOfCrystal(ZBleft, ZBmiddle, ZBright, crystal1);

                        }
                        else
                        {
                            GameObject a = Instantiate(crystal1[1], ZBleft.transform.position, Quaternion.identity);
                            GameObject b = Instantiate(crystal1[2], ZBmiddle.transform.position, Quaternion.identity);
                            //GameObject c = Instantiate(crystal[2], Zcrystalright.transform.position, Quaternion.identity);
                            lastthingspawwned = 11;
                            a.transform.Rotate(0, Random.Range(0, 360), 0);
                            b.transform.Rotate(0, Random.Range(0, 360), 0);
                            //c.transform.Rotate(0, Random.Range(0, 360), 0);
                        }

                    }

                }
            }

           
               
            
        }

        /////////////////////////////////////////CRYSTAL POSTION FILLING
         
        int randomNOcrystal = Random.Range(0, 6001);
        // to be worked out for other level?? float randomRotationCrystal = Random.Range(0, 5f);
        if (randomNOcrystal < Phase+3000)
        {
            GameObject[] crystal = { crystalred, crystalgreen, crystalblue };

            //crystal spawning old method helped only in creating a wall of crystals
            //int spawncrystalOrder = Random.Range(0, 6);
            //GameObject[] crystal = { crystalred, crystalgreen, crystalblue };
            //switch (spawncrystalOrder)
            //{
            //    case 0:
            //        {
            //            //int l = Random.Range(0, 2);
            //            GameObject a = Instantiate(crystal[0], Zcrystalleft.transform.position, Quaternion.identity);
            //            GameObject b = Instantiate(crystal[1], Zcrystalmiddle.transform.position, Quaternion.identity);
            //            GameObject c = Instantiate(crystal[2], Zcrystalright.transform.position, Quaternion.identity);
            //            lastthingspawwned = 4;
            //            a.transform.Rotate(0, Random.Range(0, 360), 0);
            //            b.transform.Rotate(0, Random.Range(0, 360), 0);
            //            c.transform.Rotate(0, Random.Range(0, 360), 0);
            //        }
            //        break;
            //    case 1:
            //        {
            //            GameObject a = Instantiate(crystal[1], Zcrystalleft.transform.position, Quaternion.identity);
            //            a.transform.Rotate(0, Random.Range(0, 360), 0);
            //            GameObject b = Instantiate(crystal[2], Zcrystalmiddle.transform.position, Quaternion.identity);
            //            b.transform.Rotate(0, Random.Range(0, 360), 0);
            //            GameObject c = Instantiate(crystal[0], Zcrystalright.transform.position, Quaternion.identity);
            //            c.transform.Rotate(0, Random.Range(0, 360), 0);
            //            lastthingspawwned = 7;



            //        }
            //        break;
            //    case 2:
            //        {
            //            GameObject a = Instantiate(crystal[2], Zcrystalleft.transform.position, Quaternion.identity);
            //            GameObject b = Instantiate(crystal[0], Zcrystalmiddle.transform.position, Quaternion.identity);
            //            GameObject c = Instantiate(crystal[1], Zcrystalright.transform.position, Quaternion.identity);
            //            lastthingspawwned = 8;
            //            a.transform.Rotate(0, Random.Range(0, 360), 0);
            //            b.transform.Rotate(0, Random.Range(0, 360), 0);
            //            c.transform.Rotate(0, Random.Range(0, 360), 0);
            //        }
            //        break;


            //    case 3:
            //        {
            //            GameObject a = Instantiate(crystal[1], Zcrystalleft.transform.position, Quaternion.identity);
            //            GameObject b = Instantiate(crystal[0], Zcrystalmiddle.transform.position, Quaternion.identity);
            //            GameObject c = Instantiate(crystal[2], Zcrystalright.transform.position, Quaternion.identity);
            //            lastthingspawwned = 6;
            //            a.transform.Rotate(0, Random.Range(0, 360), 0);
            //            b.transform.Rotate(0, Random.Range(0, 360), 0);
            //            c.transform.Rotate(0, Random.Range(0, 360), 0);
            //        }
            //        break;
            //    case 4:
            //        {
            //            GameObject a = Instantiate(crystal[2], Zcrystalleft.transform.position, Quaternion.identity);
            //            GameObject b = Instantiate(crystal[1], Zcrystalmiddle.transform.position, Quaternion.identity);
            //            GameObject c = Instantiate(crystal[0], Zcrystalright.transform.position, Quaternion.identity);
            //            lastthingspawwned = 9;
            //            a.transform.Rotate(0, Random.Range(0, 360), 0);
            //            b.transform.Rotate(0, Random.Range(0, 360), 0);
            //            c.transform.Rotate(0, Random.Range(0, 360), 0);
            //        }
            //        break;
            //    case 5:
            //        {
            //            GameObject a = Instantiate(crystal[0], Zcrystalleft.transform.position, Quaternion.identity);
            //            GameObject b = Instantiate(crystal[2], Zcrystalmiddle.transform.position, Quaternion.identity);
            //            GameObject c = Instantiate(crystal[1], Zcrystalright.transform.position, Quaternion.identity);
            //            lastthingspawwned = 5;
            //            a.transform.Rotate(0, Random.Range(0, 360), 0);
            //            b.transform.Rotate(0, Random.Range(0, 360), 0);
            //            c.transform.Rotate(0, Random.Range(0, 360), 0);
            //        }
            //        break;

            //}



            //crystal spawning new technique generating random
            //int NoOfCrystals;
            //if (PointsManager.instance.level == 2 || PointsManager.instance.level == 3 || PointsManager.instance.level == 5 || PointsManager.instance.level == 6 || PointsManager.instance.level == 8 || PointsManager.instance.level == 9)
            //{
            //    NoOfCrystals = Random.Range(0, 3);  ///////////////////////////this will make sure that only one crystal is instantiated in given levels
            //}
            //else
            //{
            //    NoOfCrystals = Random.Range(0, 2);
            //}                    $

              int NoOfCrystals;
            if (PointsManager.instance.level == 1 || PointsManager.instance.level == 3 || PointsManager.instance.level >= 6 )
            {
                NoOfCrystals = Random.Range(0, 3);  ///////////////////////////this will make sure that only one crystal is instantiated in given levels
            }
            else
            {
                NoOfCrystals = Random.Range(0, 2);
            }


            //this below is used everywhere for 1 crystal or 2 crystal with few twicks
            //GameObject a = Instantiate(crystal[2], Zcrystalleft.transform.position, Quaternion.identity);
            //GameObject b = Instantiate(crystal[0], Zcrystalmiddle.transform.position, Quaternion.identity);
            //GameObject c = Instantiate(crystal[1], Zcrystalright.transform.position, Quaternion.identity);
            //lastthingspawwned = 8;
            //a.transform.Rotate(0, Random.Range(0, 360), 0);
            //b.transform.Rotate(0, Random.Range(0, 360), 0);
            //c.transform.Rotate(0, Random.Range(0, 360), 0);
            if (NoOfCrystals == 0)
            {
                //no crystal instantiated
                if (Phase >= 4000)
                {
                    //one crystal instantiated       ///$ make more dense
                    int CrystalColor = Random.Range(0, 3);
                    if (CrystalColor == 0)
                    {
                        //red crystal instantiated
                        int PosOfCrystal = Random.Range(0, 3);
                        if (PosOfCrystal == 0)
                        {
                            //left side crystal is created
                            GameObject a = Instantiate(crystal[0], Zcrystalleft.transform.position, Quaternion.identity);
                            //GameObject b = Instantiate(crystal[0], Zcrystalmiddle.transform.position, Quaternion.identity);
                            //GameObject c = Instantiate(crystal[1], Zcrystalright.transform.position, Quaternion.identity);
                            lastthingspawwned = 8;
                            a.transform.Rotate(0, Random.Range(0, 360), 0);
                            // b.transform.Rotate(0, Random.Range(0, 360), 0);
                            // c.transform.Rotate(0, Random.Range(0, 360), 0);
                        }
                        else if (PosOfCrystal == 1)
                        {
                            //middle side crystal is created
                            //GameObject a = Instantiate(crystal[0], Zcrystalleft.transform.position, Quaternion.identity);
                            GameObject b = Instantiate(crystal[0], Zcrystalmiddle.transform.position, Quaternion.identity);
                            //GameObject c = Instantiate(crystal[1], Zcrystalright.transform.position, Quaternion.identity);
                            lastthingspawwned = 8;
                            //a.transform.Rotate(0, Random.Range(0, 360), 0);
                            b.transform.Rotate(0, Random.Range(0, 360), 0);
                            //c.transform.Rotate(0, Random.Range(0, 360), 0);
                        }
                        else if (PosOfCrystal == 2)
                        {
                            //right side crystal is created
                            //GameObject a = Instantiate(crystal[0], Zcrystalleft.transform.position, Quaternion.identity);
                            //GameObject b = Instantiate(crystal[0], Zcrystalmiddle.transform.position, Quaternion.identity);
                            GameObject c = Instantiate(crystal[1], Zcrystalright.transform.position, Quaternion.identity);
                            lastthingspawwned = 8;
                            // a.transform.Rotate(0, Random.Range(0, 360), 0);
                            // b.transform.Rotate(0, Random.Range(0, 360), 0);
                            c.transform.Rotate(0, Random.Range(0, 360), 0);
                        }
                    }
                    else if (CrystalColor == 1)
                    {
                        //green crystal instantiated
                        int PosOfCrystal = Random.Range(0, 3);
                        if (PosOfCrystal == 0)
                        {
                            //left side crystal is created
                            GameObject a = Instantiate(crystal[1], Zcrystalleft.transform.position, Quaternion.identity);
                            //GameObject b = Instantiate(crystal[0], Zcrystalmiddle.transform.position, Quaternion.identity);
                            //GameObject c = Instantiate(crystal[1], Zcrystalright.transform.position, Quaternion.identity);
                            lastthingspawwned = 8;
                            a.transform.Rotate(0, Random.Range(0, 360), 0);
                            // b.transform.Rotate(0, Random.Range(0, 360), 0);
                            // c.transform.Rotate(0, Random.Range(0, 360), 0);
                        }
                        else if (PosOfCrystal == 1)
                        {
                            //middle side crystal is created
                            //GameObject a = Instantiate(crystal[2], Zcrystalleft.transform.position, Quaternion.identity);
                            GameObject b = Instantiate(crystal[1], Zcrystalmiddle.transform.position, Quaternion.identity);
                            //GameObject c = Instantiate(crystal[1], Zcrystalright.transform.position, Quaternion.identity);
                            lastthingspawwned = 8;
                            // a.transform.Rotate(0, Random.Range(0, 360), 0);
                            b.transform.Rotate(0, Random.Range(0, 360), 0);
                            // c.transform.Rotate(0, Random.Range(0, 360), 0);
                        }
                        else if (PosOfCrystal == 2)
                        {
                            //right side crystal is created
                            //GameObject a = Instantiate(crystal[2], Zcrystalleft.transform.position, Quaternion.identity);
                            // GameObject b = Instantiate(crystal[0], Zcrystalmiddle.transform.position, Quaternion.identity);
                            GameObject c = Instantiate(crystal[1], Zcrystalright.transform.position, Quaternion.identity);
                            lastthingspawwned = 8;
                            //a.transform.Rotate(0, Random.Range(0, 360), 0);
                            //b.transform.Rotate(0, Random.Range(0, 360), 0);
                            c.transform.Rotate(0, Random.Range(0, 360), 0);
                        }
                    }
                    else if (CrystalColor == 2)
                    {
                        //blue crystal instantiated
                        int PosOfCrystal = Random.Range(0, 3);
                        if (PosOfCrystal == 0)
                        {
                            //left side crystal is created
                            GameObject a = Instantiate(crystal[2], Zcrystalleft.transform.position, Quaternion.identity);
                            //GameObject b = Instantiate(crystal[0], Zcrystalmiddle.transform.position, Quaternion.identity);
                            // GameObject c = Instantiate(crystal[1], Zcrystalright.transform.position, Quaternion.identity);
                            lastthingspawwned = 8;
                            a.transform.Rotate(0, Random.Range(0, 360), 0);
                            // b.transform.Rotate(0, Random.Range(0, 360), 0);
                            //c.transform.Rotate(0, Random.Range(0, 360), 0);
                        }
                        else if (PosOfCrystal == 1)
                        {
                            //middle side crystal is created
                            // GameObject a = Instantiate(crystal[2], Zcrystalleft.transform.position, Quaternion.identity);
                            GameObject b = Instantiate(crystal[2], Zcrystalmiddle.transform.position, Quaternion.identity);
                            // GameObject c = Instantiate(crystal[1], Zcrystalright.transform.position, Quaternion.identity);
                            lastthingspawwned = 8;
                            // a.transform.Rotate(0, Random.Range(0, 360), 0);
                            b.transform.Rotate(0, Random.Range(0, 360), 0);
                            // c.transform.Rotate(0, Random.Range(0, 360), 0);
                        }
                        else if (PosOfCrystal == 2)
                        {
                            //right side crystal is created
                            //GameObject a = Instantiate(crystal[2], Zcrystalleft.transform.position, Quaternion.identity);
                            //GameObject b = Instantiate(crystal[0], Zcrystalmiddle.transform.position, Quaternion.identity);
                            GameObject c = Instantiate(crystal[2], Zcrystalright.transform.position, Quaternion.identity);
                            lastthingspawwned = 8;
                            // a.transform.Rotate(0, Random.Range(0, 360), 0);
                            // b.transform.Rotate(0, Random.Range(0, 360), 0);
                            c.transform.Rotate(0, Random.Range(0, 360), 0);
                        }
                    }
                }
            }
            else if (NoOfCrystals == 1)   //here approach different from that of when NoOfCrystals==2 there everything summed at first only here it is hierarchy but benefit of NoOfCrystals ==2 aproach we dont need to write multiple times random
            {
                //one crystal instantiated
                int CrystalColor = Random.Range(0, 3);
                if (CrystalColor == 0)
                {
                    //red crystal instantiated
                    int PosOfCrystal = Random.Range(0, 3);
                    if (PosOfCrystal == 0)
                    {
                        //left side crystal is created
                        GameObject a = Instantiate(crystal[0], Zcrystalleft.transform.position, Quaternion.identity);
                        //GameObject b = Instantiate(crystal[0], Zcrystalmiddle.transform.position, Quaternion.identity);
                        //GameObject c = Instantiate(crystal[1], Zcrystalright.transform.position, Quaternion.identity);
                        lastthingspawwned = 8;
                        a.transform.Rotate(0, Random.Range(0, 360), 0);
                       // b.transform.Rotate(0, Random.Range(0, 360), 0);
                       // c.transform.Rotate(0, Random.Range(0, 360), 0);
                    }
                    else if (PosOfCrystal == 1)
                    {
                        //middle side crystal is created
                        //GameObject a = Instantiate(crystal[0], Zcrystalleft.transform.position, Quaternion.identity);
                        GameObject b = Instantiate(crystal[0], Zcrystalmiddle.transform.position, Quaternion.identity);
                        //GameObject c = Instantiate(crystal[1], Zcrystalright.transform.position, Quaternion.identity);
                        lastthingspawwned = 8;
                        //a.transform.Rotate(0, Random.Range(0, 360), 0);
                        b.transform.Rotate(0, Random.Range(0, 360), 0);
                        //c.transform.Rotate(0, Random.Range(0, 360), 0);
                    }
                    else if (PosOfCrystal == 2)
                    {
                        //right side crystal is created
                        //GameObject a = Instantiate(crystal[0], Zcrystalleft.transform.position, Quaternion.identity);
                        //GameObject b = Instantiate(crystal[0], Zcrystalmiddle.transform.position, Quaternion.identity);
                        GameObject c = Instantiate(crystal[1], Zcrystalright.transform.position, Quaternion.identity);
                        lastthingspawwned = 8;
                       // a.transform.Rotate(0, Random.Range(0, 360), 0);
                       // b.transform.Rotate(0, Random.Range(0, 360), 0);
                        c.transform.Rotate(0, Random.Range(0, 360), 0);
                    }
                }
                else if (CrystalColor == 1)
                {
                    //green crystal instantiated
                    int PosOfCrystal = Random.Range(0, 3);
                    if (PosOfCrystal == 0)
                    {
                        //left side crystal is created
                        GameObject a = Instantiate(crystal[1], Zcrystalleft.transform.position, Quaternion.identity);
                        //GameObject b = Instantiate(crystal[0], Zcrystalmiddle.transform.position, Quaternion.identity);
                        //GameObject c = Instantiate(crystal[1], Zcrystalright.transform.position, Quaternion.identity);
                        lastthingspawwned = 8;
                        a.transform.Rotate(0, Random.Range(0, 360), 0);
                       // b.transform.Rotate(0, Random.Range(0, 360), 0);
                       // c.transform.Rotate(0, Random.Range(0, 360), 0);
                    }
                    else if (PosOfCrystal == 1)
                    {
                        //middle side crystal is created
                        //GameObject a = Instantiate(crystal[2], Zcrystalleft.transform.position, Quaternion.identity);
                        GameObject b = Instantiate(crystal[1], Zcrystalmiddle.transform.position, Quaternion.identity);
                        //GameObject c = Instantiate(crystal[1], Zcrystalright.transform.position, Quaternion.identity);
                        lastthingspawwned = 8;
                       // a.transform.Rotate(0, Random.Range(0, 360), 0);
                        b.transform.Rotate(0, Random.Range(0, 360), 0);
                       // c.transform.Rotate(0, Random.Range(0, 360), 0);
                    }
                    else if (PosOfCrystal == 2)
                    {
                        //right side crystal is created
                        //GameObject a = Instantiate(crystal[2], Zcrystalleft.transform.position, Quaternion.identity);
                       // GameObject b = Instantiate(crystal[0], Zcrystalmiddle.transform.position, Quaternion.identity);
                        GameObject c = Instantiate(crystal[1], Zcrystalright.transform.position, Quaternion.identity);
                        lastthingspawwned = 8;
                        //a.transform.Rotate(0, Random.Range(0, 360), 0);
                        //b.transform.Rotate(0, Random.Range(0, 360), 0);
                        c.transform.Rotate(0, Random.Range(0, 360), 0);
                    }
                }
                else if (CrystalColor == 2)
                {
                    //blue crystal instantiated
                    int PosOfCrystal = Random.Range(0, 3);
                    if (PosOfCrystal == 0)
                    {
                        //left side crystal is created
                        GameObject a = Instantiate(crystal[2], Zcrystalleft.transform.position, Quaternion.identity);
                        //GameObject b = Instantiate(crystal[0], Zcrystalmiddle.transform.position, Quaternion.identity);
                       // GameObject c = Instantiate(crystal[1], Zcrystalright.transform.position, Quaternion.identity);
                        lastthingspawwned = 8;
                        a.transform.Rotate(0, Random.Range(0, 360), 0);
                       // b.transform.Rotate(0, Random.Range(0, 360), 0);
                        //c.transform.Rotate(0, Random.Range(0, 360), 0);
                    }
                    else if (PosOfCrystal == 1)
                    {
                        //middle side crystal is created
                       // GameObject a = Instantiate(crystal[2], Zcrystalleft.transform.position, Quaternion.identity);
                        GameObject b = Instantiate(crystal[2], Zcrystalmiddle.transform.position, Quaternion.identity);
                       // GameObject c = Instantiate(crystal[1], Zcrystalright.transform.position, Quaternion.identity);
                        lastthingspawwned = 8;
                       // a.transform.Rotate(0, Random.Range(0, 360), 0);
                        b.transform.Rotate(0, Random.Range(0, 360), 0);
                       // c.transform.Rotate(0, Random.Range(0, 360), 0);
                    }
                    else if (PosOfCrystal == 2)
                    {
                        //right side crystal is created
                        //GameObject a = Instantiate(crystal[2], Zcrystalleft.transform.position, Quaternion.identity);
                        //GameObject b = Instantiate(crystal[0], Zcrystalmiddle.transform.position, Quaternion.identity);
                        GameObject c = Instantiate(crystal[2], Zcrystalright.transform.position, Quaternion.identity);
                        lastthingspawwned = 8;
                       // a.transform.Rotate(0, Random.Range(0, 360), 0);
                       // b.transform.Rotate(0, Random.Range(0, 360), 0);
                        c.transform.Rotate(0, Random.Range(0, 360), 0);
                    }
                }
            }
            else if (NoOfCrystals == 2)
            {
                //two crystal instantiated
                int orderSet = Random.Range(0,27);
                //orderSet 0=R-R,1=G-G,2=B-B,3=R-G,4=G-R,5=R-G,6=B-R,7=B-G,8=G-B,    , 9=-RR,10=-GG,11=-BB,12=-RG,13=-GR,14=-RB,15=-BR,16=-BG,17=-GB,    ,18=RR,19=GG,20=BB,21=RG,22=GR-,23=RB-,24=BR-,25=BG-,26=GB-
                if (orderSet == 0)
                {
                    GameObject a = Instantiate(crystal[0], Zcrystalleft.transform.position, Quaternion.identity);
                    //GameObject b = Instantiate(crystal[1], Zcrystalmiddle.transform.position, Quaternion.identity);
                    GameObject c = Instantiate(crystal[0], Zcrystalright.transform.position, Quaternion.identity);
                    lastthingspawwned = 4;
                    a.transform.Rotate(0, Random.Range(0, 360), 0);
                   // b.transform.Rotate(0, Random.Range(0, 360), 0);
                    c.transform.Rotate(0, Random.Range(0, 360), 0);
                }
                else if (orderSet == 1)
                {
                    GameObject a = Instantiate(crystal[1], Zcrystalleft.transform.position, Quaternion.identity);
                    //GameObject b = Instantiate(crystal[1], Zcrystalmiddle.transform.position, Quaternion.identity);
                    GameObject c = Instantiate(crystal[1], Zcrystalright.transform.position, Quaternion.identity);
                    lastthingspawwned = 4;
                    a.transform.Rotate(0, Random.Range(0, 360), 0);
                   // b.transform.Rotate(0, Random.Range(0, 360), 0);
                    c.transform.Rotate(0, Random.Range(0, 360), 0);
                }
                else if (orderSet == 2)
                {
                    GameObject a = Instantiate(crystal[2], Zcrystalleft.transform.position, Quaternion.identity);
                    //GameObject b = Instantiate(crystal[1], Zcrystalmiddle.transform.position, Quaternion.identity);
                    GameObject c = Instantiate(crystal[2], Zcrystalright.transform.position, Quaternion.identity);
                    lastthingspawwned = 4;
                    a.transform.Rotate(0, Random.Range(0, 360), 0);
                    //b.transform.Rotate(0, Random.Range(0, 360), 0);
                    c.transform.Rotate(0, Random.Range(0, 360), 0);
                }
                else if (orderSet == 3)
                {
                    GameObject a = Instantiate(crystal[0], Zcrystalleft.transform.position, Quaternion.identity);
                    //GameObject b = Instantiate(crystal[1], Zcrystalmiddle.transform.position, Quaternion.identity);
                    GameObject c = Instantiate(crystal[1], Zcrystalright.transform.position, Quaternion.identity);
                    lastthingspawwned = 4;
                    a.transform.Rotate(0, Random.Range(0, 360), 0);
                    //b.transform.Rotate(0, Random.Range(0, 360), 0);
                    c.transform.Rotate(0, Random.Range(0, 360), 0);
                }
                else if (orderSet == 4)
                {
                    GameObject a = Instantiate(crystal[1], Zcrystalleft.transform.position, Quaternion.identity);
                    //GameObject b = Instantiate(crystal[1], Zcrystalmiddle.transform.position, Quaternion.identity);
                    GameObject c = Instantiate(crystal[0], Zcrystalright.transform.position, Quaternion.identity);
                    lastthingspawwned = 4;
                    a.transform.Rotate(0, Random.Range(0, 360), 0);
                    //b.transform.Rotate(0, Random.Range(0, 360), 0);
                    c.transform.Rotate(0, Random.Range(0, 360), 0);
                }
                else if (orderSet == 5)
                {
                    GameObject a = Instantiate(crystal[0], Zcrystalleft.transform.position, Quaternion.identity);
                    //GameObject b = Instantiate(crystal[1], Zcrystalmiddle.transform.position, Quaternion.identity);
                    GameObject c = Instantiate(crystal[2], Zcrystalright.transform.position, Quaternion.identity);
                    lastthingspawwned = 4;
                    a.transform.Rotate(0, Random.Range(0, 360), 0);
                    //b.transform.Rotate(0, Random.Range(0, 360), 0);
                    c.transform.Rotate(0, Random.Range(0, 360), 0);
                }
                else if (orderSet == 6)
                {
                    GameObject a = Instantiate(crystal[2], Zcrystalleft.transform.position, Quaternion.identity);
                    //GameObject b = Instantiate(crystal[1], Zcrystalmiddle.transform.position, Quaternion.identity);
                    GameObject c = Instantiate(crystal[0], Zcrystalright.transform.position, Quaternion.identity);
                    lastthingspawwned = 4;
                    a.transform.Rotate(0, Random.Range(0, 360), 0);
                    //b.transform.Rotate(0, Random.Range(0, 360), 0);
                    c.transform.Rotate(0, Random.Range(0, 360), 0);
                }
                else if (orderSet == 7)
                {
                    GameObject a = Instantiate(crystal[2], Zcrystalleft.transform.position, Quaternion.identity);
                    //GameObject b = Instantiate(crystal[1], Zcrystalmiddle.transform.position, Quaternion.identity);
                    GameObject c = Instantiate(crystal[1], Zcrystalright.transform.position, Quaternion.identity);
                    lastthingspawwned = 4;
                    a.transform.Rotate(0, Random.Range(0, 360), 0);
                   // b.transform.Rotate(0, Random.Range(0, 360), 0);
                    c.transform.Rotate(0, Random.Range(0, 360), 0);
                }
                else if (orderSet == 8)
                {
                    GameObject a = Instantiate(crystal[1], Zcrystalleft.transform.position, Quaternion.identity);
                    //GameObject b = Instantiate(crystal[1], Zcrystalmiddle.transform.position, Quaternion.identity);
                    GameObject c = Instantiate(crystal[2], Zcrystalright.transform.position, Quaternion.identity);
                    lastthingspawwned = 4;
                    a.transform.Rotate(0, Random.Range(0, 360), 0);
                   // b.transform.Rotate(0, Random.Range(0, 360), 0);
                    c.transform.Rotate(0, Random.Range(0, 360), 0);
                }
                ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                else if (orderSet == 9)
                {
                    if (lastthingspawwned == 12 || lastthingspawwned == 13 || lastthingspawwned == 14 || lastthingspawwned == 15 || lastthingspawwned == 16)
                    {
                        SpecialCaseSpawnningOfCrystal(Zcrystalleft, Zcrystalmiddle, Zcrystalright, crystal);

                    }
                    else
                    {
                        //GameObject a = Instantiate(crystal[0], Zcrystalleft.transform.position, Quaternion.identity);
                        GameObject b = Instantiate(crystal[0], Zcrystalmiddle.transform.position, Quaternion.identity);
                        GameObject c = Instantiate(crystal[0], Zcrystalright.transform.position, Quaternion.identity);
                        lastthingspawwned = 24;
                        // a.transform.Rotate(0, Random.Range(0, 360), 0);
                        b.transform.Rotate(0, Random.Range(0, 360), 0);
                        c.transform.Rotate(0, Random.Range(0, 360), 0);
                    }
                   
                }
                else if (orderSet == 10)
                {
                    if (lastthingspawwned == 11 || lastthingspawwned == 13 || lastthingspawwned == 14 || lastthingspawwned == 15 || lastthingspawwned == 16)
                    {
                        SpecialCaseSpawnningOfCrystal(Zcrystalleft, Zcrystalmiddle, Zcrystalright, crystal);

                    }
                    else
                    {
                        //GameObject a = Instantiate(crystal[0], Zcrystalleft.transform.position, Quaternion.identity);
                        GameObject b = Instantiate(crystal[1], Zcrystalmiddle.transform.position, Quaternion.identity);
                        GameObject c = Instantiate(crystal[1], Zcrystalright.transform.position, Quaternion.identity);
                        lastthingspawwned = 25;
                        //a.transform.Rotate(0, Random.Range(0, 360), 0);
                        b.transform.Rotate(0, Random.Range(0, 360), 0);
                        c.transform.Rotate(0, Random.Range(0, 360), 0);
                    }
                   
                }
                else if (orderSet == 11)
                {
                    if (lastthingspawwned == 11 || lastthingspawwned == 12 || lastthingspawwned == 14 || lastthingspawwned == 15 || lastthingspawwned == 16)
                    {
                        SpecialCaseSpawnningOfCrystal(Zcrystalleft, Zcrystalmiddle, Zcrystalright, crystal);

                    }
                    else
                    {
                        //GameObject a = Instantiate(crystal[0], Zcrystalleft.transform.position, Quaternion.identity);
                        GameObject b = Instantiate(crystal[2], Zcrystalmiddle.transform.position, Quaternion.identity);
                        GameObject c = Instantiate(crystal[2], Zcrystalright.transform.position, Quaternion.identity);
                        lastthingspawwned = 26;
                        //a.transform.Rotate(0, Random.Range(0, 360), 0);
                        b.transform.Rotate(0, Random.Range(0, 360), 0);
                        c.transform.Rotate(0, Random.Range(0, 360), 0);
                    }
                    
                }
                else if (orderSet == 12)
                {
                    if (lastthingspawwned == 13 || lastthingspawwned == 14 || lastthingspawwned == 15)
                    {
                        SpecialCaseSpawnningOfCrystal(Zcrystalleft, Zcrystalmiddle, Zcrystalright, crystal);

                    }
                    else
                    {
                        //GameObject a = Instantiate(crystal[0], Zcrystalleft.transform.position, Quaternion.identity);
                        GameObject b = Instantiate(crystal[0], Zcrystalmiddle.transform.position, Quaternion.identity);
                        GameObject c = Instantiate(crystal[1], Zcrystalright.transform.position, Quaternion.identity);
                        lastthingspawwned = 23;
                        //a.transform.Rotate(0, Random.Range(0, 360), 0);
                        b.transform.Rotate(0, Random.Range(0, 360), 0);
                        c.transform.Rotate(0, Random.Range(0, 360), 0);
                    }
                    
                }
                else if (orderSet == 13)
                {
                    if (lastthingspawwned == 13 || lastthingspawwned == 14 || lastthingspawwned == 15)
                    {
                        SpecialCaseSpawnningOfCrystal(Zcrystalleft, Zcrystalmiddle, Zcrystalright, crystal);

                    }
                    else
                    {
                        //GameObject a = Instantiate(crystal[0], Zcrystalleft.transform.position, Quaternion.identity);
                        GameObject b = Instantiate(crystal[1], Zcrystalmiddle.transform.position, Quaternion.identity);
                        GameObject c = Instantiate(crystal[0], Zcrystalright.transform.position, Quaternion.identity);
                        lastthingspawwned = 23;
                        //a.transform.Rotate(0, Random.Range(0, 360), 0);
                        b.transform.Rotate(0, Random.Range(0, 360), 0);
                        c.transform.Rotate(0, Random.Range(0, 360), 0);
                    }
                    
                }
                else if (orderSet == 14)
                {
                    if (lastthingspawwned == 12 || lastthingspawwned == 14 || lastthingspawwned == 16)
                    {
                        SpecialCaseSpawnningOfCrystal(Zcrystalleft, Zcrystalmiddle, Zcrystalright, crystal);

                    }
                    else
                    {
                        // GameObject a = Instantiate(crystal[0], Zcrystalleft.transform.position, Quaternion.identity);
                        GameObject b = Instantiate(crystal[0], Zcrystalmiddle.transform.position, Quaternion.identity);
                        GameObject c = Instantiate(crystal[2], Zcrystalright.transform.position, Quaternion.identity);
                        lastthingspawwned = 22;
                        //a.transform.Rotate(0, Random.Range(0, 360), 0);
                        b.transform.Rotate(0, Random.Range(0, 360), 0);
                        c.transform.Rotate(0, Random.Range(0, 360), 0);
                    }
                   
                }
                else if (orderSet == 15)
                {
                    if (lastthingspawwned == 12 ||  lastthingspawwned == 14  || lastthingspawwned == 16 )
                    {
                        SpecialCaseSpawnningOfCrystal(Zcrystalleft, Zcrystalmiddle, Zcrystalright, crystal);

                    }
                    else
                    {
                        //GameObject a = Instantiate(crystal[0], Zcrystalleft.transform.position, Quaternion.identity);
                        GameObject b = Instantiate(crystal[2], Zcrystalmiddle.transform.position, Quaternion.identity);
                        GameObject c = Instantiate(crystal[0], Zcrystalright.transform.position, Quaternion.identity);
                        lastthingspawwned = 22;
                        //a.transform.Rotate(0, Random.Range(0, 360), 0);
                        b.transform.Rotate(0, Random.Range(0, 360), 0);
                        c.transform.Rotate(0, Random.Range(0, 360), 0);
                    }
                    
                }
                else if (orderSet == 16)
                {
                    if (lastthingspawwned == 11 || lastthingspawwned == 15 || lastthingspawwned == 16)
                    {
                        SpecialCaseSpawnningOfCrystal(Zcrystalleft, Zcrystalmiddle, Zcrystalright, crystal);

                    }
                    else
                    {
                        //GameObject a = Instantiate(crystal[0], Zcrystalleft.transform.position, Quaternion.identity);
                        GameObject b = Instantiate(crystal[2], Zcrystalmiddle.transform.position, Quaternion.identity);
                        GameObject c = Instantiate(crystal[1], Zcrystalright.transform.position, Quaternion.identity);
                        lastthingspawwned = 21;
                        // a.transform.Rotate(0, Random.Range(0, 360), 0);
                        b.transform.Rotate(0, Random.Range(0, 360), 0);
                        c.transform.Rotate(0, Random.Range(0, 360), 0);
                    }
                    
                }
                else if (orderSet == 17)
                {
                    if (lastthingspawwned == 11 ||lastthingspawwned == 15 || lastthingspawwned == 16 )
                    {
                        SpecialCaseSpawnningOfCrystal(Zcrystalleft, Zcrystalmiddle, Zcrystalright, crystal);

                    }
                    else
                    {
                        //GameObject a = Instantiate(crystal[0], Zcrystalleft.transform.position, Quaternion.identity);
                        GameObject b = Instantiate(crystal[1], Zcrystalmiddle.transform.position, Quaternion.identity);
                        GameObject c = Instantiate(crystal[2], Zcrystalright.transform.position, Quaternion.identity);
                        lastthingspawwned = 21;
                        //a.transform.Rotate(0, Random.Range(0, 360), 0);
                        b.transform.Rotate(0, Random.Range(0, 360), 0);
                        c.transform.Rotate(0, Random.Range(0, 360), 0);
                    }
                    
                }

                /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                else if (orderSet == 18)
                {
                    if (lastthingspawwned == 22 || lastthingspawwned == 23 || lastthingspawwned == 24 || lastthingspawwned == 25 || lastthingspawwned == 26)
                    {
                        SpecialCaseSpawnningOfCrystal(Zcrystalleft, Zcrystalmiddle, Zcrystalright, crystal);

                    }
                    else
                    {
                        GameObject a = Instantiate(crystal[0], Zcrystalleft.transform.position, Quaternion.identity);
                        GameObject b = Instantiate(crystal[0], Zcrystalmiddle.transform.position, Quaternion.identity);
                        //GameObject c = Instantiate(crystal[2], Zcrystalright.transform.position, Quaternion.identity);
                        lastthingspawwned = 14;
                        a.transform.Rotate(0, Random.Range(0, 360), 0);
                        b.transform.Rotate(0, Random.Range(0, 360), 0);
                        //c.transform.Rotate(0, Random.Range(0, 360), 0);
                    }

                }
                else if (orderSet == 19)
                {
                    if (lastthingspawwned == 21 || lastthingspawwned == 23 || lastthingspawwned == 24 || lastthingspawwned == 25 || lastthingspawwned == 26)
                    {
                        SpecialCaseSpawnningOfCrystal(Zcrystalleft, Zcrystalmiddle, Zcrystalright, crystal);

                    }
                    else
                    {
                        GameObject a = Instantiate(crystal[1], Zcrystalleft.transform.position, Quaternion.identity);
                        GameObject b = Instantiate(crystal[1], Zcrystalmiddle.transform.position, Quaternion.identity);
                        // GameObject c = Instantiate(crystal[2], Zcrystalright.transform.position, Quaternion.identity);
                        lastthingspawwned = 15;
                        a.transform.Rotate(0, Random.Range(0, 360), 0);
                        b.transform.Rotate(0, Random.Range(0, 360), 0);
                        //c.transform.Rotate(0, Random.Range(0, 360), 0);
                    }

                }
                else if (orderSet == 20)
                {
                    if (lastthingspawwned == 21 || lastthingspawwned == 22 || lastthingspawwned == 24 || lastthingspawwned == 25 || lastthingspawwned == 26)
                    {
                        SpecialCaseSpawnningOfCrystal(Zcrystalleft, Zcrystalmiddle, Zcrystalright, crystal);

                    }
                    else
                    {
                        GameObject a = Instantiate(crystal[2], Zcrystalleft.transform.position, Quaternion.identity);
                        GameObject b = Instantiate(crystal[2], Zcrystalmiddle.transform.position, Quaternion.identity);
                        //GameObject c = Instantiate(crystal[2], Zcrystalright.transform.position, Quaternion.identity);
                        lastthingspawwned = 16;
                        a.transform.Rotate(0, Random.Range(0, 360), 0);
                        b.transform.Rotate(0, Random.Range(0, 360), 0);
                        //c.transform.Rotate(0, Random.Range(0, 360), 0);
                    }

                }
                else if (orderSet == 21)
                {
                    if (lastthingspawwned == 13 || lastthingspawwned == 14 || lastthingspawwned == 15)
                    {
                        SpecialCaseSpawnningOfCrystal(Zcrystalleft, Zcrystalmiddle, Zcrystalright, crystal);

                    }
                    else
                    {
                        GameObject a = Instantiate(crystal[0], Zcrystalleft.transform.position, Quaternion.identity);
                        GameObject b = Instantiate(crystal[1], Zcrystalmiddle.transform.position, Quaternion.identity);
                        //GameObject c = Instantiate(crystal[2], Zcrystalright.transform.position, Quaternion.identity);
                        lastthingspawwned = 13;
                        a.transform.Rotate(0, Random.Range(0, 360), 0);
                        b.transform.Rotate(0, Random.Range(0, 360), 0);
                        // c.transform.Rotate(0, Random.Range(0, 360), 0);
                    }

                }
                else if (orderSet == 22)
                {
                    if (lastthingspawwned == 13 || lastthingspawwned == 14 || lastthingspawwned == 15)
                    {
                        SpecialCaseSpawnningOfCrystal(Zcrystalleft, Zcrystalmiddle, Zcrystalright, crystal);

                    }
                    else
                    {
                        GameObject a = Instantiate(crystal[1], Zcrystalleft.transform.position, Quaternion.identity);
                        GameObject b = Instantiate(crystal[0], Zcrystalmiddle.transform.position, Quaternion.identity);
                        //GameObject c = Instantiate(crystal[2], Zcrystalright.transform.position, Quaternion.identity);
                        lastthingspawwned = 13;
                        a.transform.Rotate(0, Random.Range(0, 360), 0);
                        b.transform.Rotate(0, Random.Range(0, 360), 0);
                        //c.transform.Rotate(0, Random.Range(0, 360), 0);
                    }

                }
                else if (orderSet == 23)
                {
                    if (lastthingspawwned == 12 || lastthingspawwned == 14 || lastthingspawwned == 16)
                    {
                        SpecialCaseSpawnningOfCrystal(Zcrystalleft, Zcrystalmiddle, Zcrystalright, crystal);

                    }
                    else
                    {
                        GameObject a = Instantiate(crystal[0], Zcrystalleft.transform.position, Quaternion.identity);
                        GameObject b = Instantiate(crystal[2], Zcrystalmiddle.transform.position, Quaternion.identity);
                        //GameObject c = Instantiate(crystal[2], Zcrystalright.transform.position, Quaternion.identity);
                        lastthingspawwned = 12;
                        a.transform.Rotate(0, Random.Range(0, 360), 0);
                        b.transform.Rotate(0, Random.Range(0, 360), 0);
                        //c.transform.Rotate(0, Random.Range(0, 360), 0);
                    }

                }
                else if (orderSet == 24)
                {
                    if (lastthingspawwned == 12 || lastthingspawwned == 14 || lastthingspawwned == 16)
                    {
                        SpecialCaseSpawnningOfCrystal(Zcrystalleft, Zcrystalmiddle, Zcrystalright, crystal);

                    }
                    else
                    {
                        GameObject a = Instantiate(crystal[2], Zcrystalleft.transform.position, Quaternion.identity);
                        GameObject b = Instantiate(crystal[0], Zcrystalmiddle.transform.position, Quaternion.identity);
                        //GameObject c = Instantiate(crystal[2], Zcrystalright.transform.position, Quaternion.identity);
                        lastthingspawwned = 12;
                        a.transform.Rotate(0, Random.Range(0, 360), 0);
                        b.transform.Rotate(0, Random.Range(0, 360), 0);
                        // c.transform.Rotate(0, Random.Range(0, 360), 0);
                    }

                }
                else if (orderSet == 25)
                {
                    if (lastthingspawwned == 11 || lastthingspawwned == 15 || lastthingspawwned == 16)
                    {
                        SpecialCaseSpawnningOfCrystal(Zcrystalleft, Zcrystalmiddle, Zcrystalright, crystal);

                    }
                    else
                    {
                        GameObject a = Instantiate(crystal[2], Zcrystalleft.transform.position, Quaternion.identity);
                        GameObject b = Instantiate(crystal[1], Zcrystalmiddle.transform.position, Quaternion.identity);
                        //GameObject c = Instantiate(crystal[2], Zcrystalright.transform.position, Quaternion.identity);
                        lastthingspawwned = 11;
                        a.transform.Rotate(0, Random.Range(0, 360), 0);
                        b.transform.Rotate(0, Random.Range(0, 360), 0);
                        //c.transform.Rotate(0, Random.Range(0, 360), 0);
                    }

                }
                else if (orderSet == 26)
                {
                    if (lastthingspawwned == 11 || lastthingspawwned == 15 || lastthingspawwned == 16)
                    {
                        SpecialCaseSpawnningOfCrystal(Zcrystalleft, Zcrystalmiddle, Zcrystalright, crystal);

                    }
                    else
                    {
                        GameObject a = Instantiate(crystal[1], Zcrystalleft.transform.position, Quaternion.identity);
                        GameObject b = Instantiate(crystal[2], Zcrystalmiddle.transform.position, Quaternion.identity);
                        //GameObject c = Instantiate(crystal[2], Zcrystalright.transform.position, Quaternion.identity);
                        lastthingspawwned = 11;
                        a.transform.Rotate(0, Random.Range(0, 360), 0);
                        b.transform.Rotate(0, Random.Range(0, 360), 0);
                        //c.transform.Rotate(0, Random.Range(0, 360), 0);
                    }

                }
                
            }
        }
    }

    private void SpecialCaseSpawnningOfCrystal(GameObject ZBleft, GameObject ZBmiddle, GameObject ZBright, GameObject[] crystal1)
    {
        //one crystal instantiated
        int CrystalColor = Random.Range(0, 3);
        if (CrystalColor == 0)
        {
            //red crystal instantiated
            int PosOfCrystal = Random.Range(0, 3);
            if (PosOfCrystal == 0)
            {
                //left side crystal is created
                GameObject a = Instantiate(crystal1[0], ZBleft.transform.position, Quaternion.identity);
                //GameObject b = Instantiate(crystal[0], Zcrystalmiddle.transform.position, Quaternion.identity);
                //GameObject c = Instantiate(crystal[1], Zcrystalright.transform.position, Quaternion.identity);
                lastthingspawwned = 8;
                a.transform.Rotate(0, Random.Range(0, 360), 0);
                // b.transform.Rotate(0, Random.Range(0, 360), 0);
                // c.transform.Rotate(0, Random.Range(0, 360), 0);
            }
            else if (PosOfCrystal == 1)
            {
                //middle side crystal is created
                //GameObject a = Instantiate(crystal[0], Zcrystalleft.transform.position, Quaternion.identity);
                GameObject b = Instantiate(crystal1[0], ZBmiddle.transform.position, Quaternion.identity);
                //GameObject c = Instantiate(crystal[1], Zcrystalright.transform.position, Quaternion.identity);
                lastthingspawwned = 8;
                //a.transform.Rotate(0, Random.Range(0, 360), 0);
                b.transform.Rotate(0, Random.Range(0, 360), 0);
                //c.transform.Rotate(0, Random.Range(0, 360), 0);
            }
            else if (PosOfCrystal == 2)
            {
                //right side crystal is created
                //GameObject a = Instantiate(crystal[0], Zcrystalleft.transform.position, Quaternion.identity);
                //GameObject b = Instantiate(crystal[0], Zcrystalmiddle.transform.position, Quaternion.identity);
                GameObject c = Instantiate(crystal1[1], ZBright.transform.position, Quaternion.identity);
                lastthingspawwned = 8;
                // a.transform.Rotate(0, Random.Range(0, 360), 0);
                // b.transform.Rotate(0, Random.Range(0, 360), 0);
                c.transform.Rotate(0, Random.Range(0, 360), 0);
            }
        }
        else if (CrystalColor == 1)
        {
            //green crystal instantiated
            int PosOfCrystal = Random.Range(0, 3);
            if (PosOfCrystal == 0)
            {
                //left side crystal is created
                GameObject a = Instantiate(crystal1[1], ZBleft.transform.position, Quaternion.identity);
                //GameObject b = Instantiate(crystal[0], Zcrystalmiddle.transform.position, Quaternion.identity);
                //GameObject c = Instantiate(crystal[1], Zcrystalright.transform.position, Quaternion.identity);
                lastthingspawwned = 8;
                a.transform.Rotate(0, Random.Range(0, 360), 0);
                // b.transform.Rotate(0, Random.Range(0, 360), 0);
                // c.transform.Rotate(0, Random.Range(0, 360), 0);
            }
            else if (PosOfCrystal == 1)
            {
                //middle side crystal is created
                //GameObject a = Instantiate(crystal[2], Zcrystalleft.transform.position, Quaternion.identity);
                GameObject b = Instantiate(crystal1[1], ZBmiddle.transform.position, Quaternion.identity);
                //GameObject c = Instantiate(crystal[1], Zcrystalright.transform.position, Quaternion.identity);
                lastthingspawwned = 8;
                // a.transform.Rotate(0, Random.Range(0, 360), 0);
                b.transform.Rotate(0, Random.Range(0, 360), 0);
                // c.transform.Rotate(0, Random.Range(0, 360), 0);
            }
            else if (PosOfCrystal == 2)
            {
                //right side crystal is created
                //GameObject a = Instantiate(crystal[2], Zcrystalleft.transform.position, Quaternion.identity);
                // GameObject b = Instantiate(crystal[0], Zcrystalmiddle.transform.position, Quaternion.identity);
                GameObject c = Instantiate(crystal1[1], ZBright.transform.position, Quaternion.identity);
                lastthingspawwned = 8;
                //a.transform.Rotate(0, Random.Range(0, 360), 0);
                //b.transform.Rotate(0, Random.Range(0, 360), 0);
                c.transform.Rotate(0, Random.Range(0, 360), 0);
            }
        }
        else if (CrystalColor == 2)
        {
            //blue crystal instantiated
            int PosOfCrystal = Random.Range(0, 3);
            if (PosOfCrystal == 0)
            {
                //left side crystal is created
                GameObject a = Instantiate(crystal1[2], ZBleft.transform.position, Quaternion.identity);
                //GameObject b = Instantiate(crystal[0], Zcrystalmiddle.transform.position, Quaternion.identity);
                // GameObject c = Instantiate(crystal[1], Zcrystalright.transform.position, Quaternion.identity);
                lastthingspawwned = 8;
                a.transform.Rotate(0, Random.Range(0, 360), 0);
                // b.transform.Rotate(0, Random.Range(0, 360), 0);
                //c.transform.Rotate(0, Random.Range(0, 360), 0);
            }
            else if (PosOfCrystal == 1)
            {
                //middle side crystal is created
                // GameObject a = Instantiate(crystal[2], Zcrystalleft.transform.position, Quaternion.identity);
                GameObject b = Instantiate(crystal1[2], ZBmiddle.transform.position, Quaternion.identity);
                // GameObject c = Instantiate(crystal[1], Zcrystalright.transform.position, Quaternion.identity);
                lastthingspawwned = 8;
                // a.transform.Rotate(0, Random.Range(0, 360), 0);
                b.transform.Rotate(0, Random.Range(0, 360), 0);
                // c.transform.Rotate(0, Random.Range(0, 360), 0);
            }
            else if (PosOfCrystal == 2)
            {
                //right side crystal is created
                //GameObject a = Instantiate(crystal[2], Zcrystalleft.transform.position, Quaternion.identity);
                //GameObject b = Instantiate(crystal[0], Zcrystalmiddle.transform.position, Quaternion.identity);
                GameObject c = Instantiate(crystal1[2], ZBright.transform.position, Quaternion.identity);
                lastthingspawwned = 8;
                // a.transform.Rotate(0, Random.Range(0, 360), 0);
                // b.transform.Rotate(0, Random.Range(0, 360), 0);
                c.transform.Rotate(0, Random.Range(0, 360), 0);
            }
        }
    }
}




//0 for nothing ,1 for redborder ,2 for greenborder ,3 for blueborder ,4 for crystal pack RGB ,5 for crystal pack RBG,6 for crystal pack GRB,7 for crystal pack GBR ,8 for crystal pack BRG,9 for crystal pack BGR,
//, 11 for AA_ missing red,, 12 for AA_ missing green,, 13 for AA_ missing redBlue,// 14 for AA_  red,, 15 for AA_  green,, 15 for AA_  Blue,///, 21 for _AA missing red,, 22 for _AA missing green,, 23 for _AA missing blue, 21 for _AA missing red,// 24 for _AA  red,, 25 for _AA  green,, 26 for _AA  blue,
/*
 we have to be very picky lets see>>>>>>>>>>>>>...         AA_     _AA
                                                            11      21                       -red unavailable
                                                            12      22                       -green unavailable
                                                            13      23                       -blue unavailable
                                                            14      24                       -only red
                                                            15      25                       -only blue
                                                            16      26                       -only green
                                                           
                       for example if spawning 11 then last thing spawned can't be 21,25,26 and this is very picy as for rest we will have each color crystal let say 11 and 22 then in first red unavailable but in second red is available                                     
 */


///////////Detail on levels
/////////////////NO OF CRYSTALS /////////MAX SPEED/////////ROTATION OF CRYSTAL ////// ROTATION OF BOARD
///leve  0         1                     200                  0                               0                
///level 1         1                      250                  0                              0      $
///level 2         1/2                    200                  0                              0
///level 3         1/2                    250                  0                              0      $
///level 4          1                     200                  1                              0
///level 5          1/2                   200                  1                              0
///level 6         1/2                    250                  1                              0      $
///level 7          1                     200                  0                              1
///level 8          1/2                    200                 1                              1
///level 9          1/2                     250                1                              1       $
///level 10
///

///////////Detail on levels
/////////////////NO OF CRYSTALS /////////MAX SPEED/////////ROTATION OF CRYSTAL ////// ROTATION OF BOARD
///leve  0         1                     200                  0                               0                  5000

///level 1         1/2                    200                  0                              0                  10000

///level 2          1                     200                  1                              0
///level 3          1/2                   200                  1                              0

///level 4          1                     200                  0                              1
///level 5          1                     200                  1                              1
//////level 6         1/2                    200                 1                             1

///level 10

