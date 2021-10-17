using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followPlayer : MonoBehaviour
{
    

    public GameObject player;
     Vector3 pointingvector;
    Vector3 initialPosOfCamera;
     Vector3 finalPosofCamera;
    public float lerprat;
    public float lerpratATEND;
    // Start is called before the first frame update
    private void Awake()
    {
        pointingvector = player.transform.position - transform.position;
    }
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if (PointsManager.instance.gamestate!=0&& PointsManager.instance.gamestate!=10)
        {
            initialPosOfCamera = transform.position;
            //finalPosofCamera = initialPosOfCamera + pointingvector; my error point
            finalPosofCamera = player.transform.position - pointingvector;
            Vector3 update = Vector3.Lerp(finalPosofCamera, initialPosOfCamera, lerprat * Time.deltaTime);
            transform.position = new Vector3(transform.position.x, update.y, update.z);
        }
        if (PointsManager.instance.gamestate == 10)
        {
            /// stop following ball this code will be written later for now just stop the moment it looses
            
            /////////////this are working ok

        }
    }
}
