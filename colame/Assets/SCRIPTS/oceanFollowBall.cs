using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class oceanFollowBall : MonoBehaviour
{
    public bool gamestate;

    public GameObject player;
    Vector3 pointingvector;
    Vector3 initialPosOfocean;
    Vector3 finalPosofocean;
    public float lerprat;
    // Start is called before the first frame update
    private void Awake()
    {
        pointingvector = player.transform.position - transform.position;
    }
    void Start()
    {
        gamestate = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (gamestate)
        {
            initialPosOfocean = transform.position;
            //finalPosofCamera = initialPosOfCamera + pointingvector; my error point
            finalPosofocean = player.transform.position - pointingvector;
            Vector3 update = Vector3.Lerp(finalPosofocean, initialPosOfocean, lerprat * Time.deltaTime);
            //transform.position = update;
            transform.position = new Vector3(update.x, transform.position.y, update.z);
        }

    }
}
