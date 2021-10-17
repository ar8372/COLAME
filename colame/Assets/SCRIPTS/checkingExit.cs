using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkingExit : MonoBehaviour
{
    public GameObject Ball;
    
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
      
    }

  
    void OnTriggerExit(Collider other)
    {
        Console.WriteLine("exiting of trigger");
        if (PointsManager.instance.gamestate != 10)                  //this ensure that platform dont destroy after the ball is has stopped
        {
            if (other.gameObject.tag == "Player" || other.gameObject.tag == "PlayerBlue" || other.gameObject.tag == "PlayerGreen" || other.gameObject.tag == "PlayerRed")
            {
                //Destroy(gameObject)
                Destroy(gameObject, 2f);

            }
        }
        else
        {
            if (other.gameObject.tag == "Player" || other.gameObject.tag == "PlayerBlue" || other.gameObject.tag == "PlayerGreen" || other.gameObject.tag == "PlayerRed")
            {
                //Destroy(gameObject)
                Destroy(gameObject, 15f);

            }
        }
        
    }
}
