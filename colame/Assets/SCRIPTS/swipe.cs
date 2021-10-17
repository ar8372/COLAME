using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class swipe : MonoBehaviour
{
    public int LeftSwipe = 0;
    public int RightSwipe = 0;

    Vector3 startpos;
    Vector3 endpos;

    float starttime;
    float endtime;

    Vector2 touchvector;
    float touchtime;

    public float mindistance;
    public float maxtime;

    public static swipe instance;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        //rb = player.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                startpos = touch.position;
                starttime = Time.time;

            }
            else if (touch.phase == TouchPhase.Ended)
            {
                endpos = touch.position;
                endtime = Time.time;
                touchvector = endpos - startpos;
                touchtime = endtime - starttime;
                if (((touchvector).magnitude) >= mindistance && touchtime < maxtime)
                {
                    swipetouch();
                }
            }



        }
    }

    private void swipetouch()
    {
        //print("it is swiping");
        if ((Mathf.Abs(touchvector.x)) > (Mathf.Abs(touchvector.y)))
        {
            //print("it is horizontal swiping");
            if (touchvector.x > 0)
            {
                print("it is right swipe");
                RightSwipe = 1;

            }
            if (touchvector.x < 0)
            {
                print("it is left swipe");
                LeftSwipe = 1;

            }

        }
        //if ((Mathf.Abs(touchvector.x)) < (Mathf.Abs(touchvector.y)))
        //{
        //    // print("it is vertical swiping");

        //    if (touchvector.x > 0)
        //    {
        //        print("it is up swipe");
        //        // jump();
        //        player.GetComponent<sam>().jump();
        //    }
        //    if (touchvector.x < 0)
        //    {
        //        print("it is down swipe");
        //    }

        //}
    }
}
