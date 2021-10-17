using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    //sound
    public float BallLeftRight1, BallLeftRight2;

    public float speedfactor;
    

    public int BallPos = -1;

    public float waitTheCoroutine;

    int leftcoroutinecheck = 0;
    int rightcoroutinecheck = 0;

    public float rateOfDirectionChange;

    public int forceToBall;
    int fixingforce = 0;
    int fixingspeed = 0;

    public static int indexPlayer;
    public static int indexCrystal;

    public float speedOfBall;
    Rigidbody rb;
    public bool gameState=false;
    // Start is called before the first frame update
    void Start()
    {
        BallPos = -1;
        rb = gameObject.GetComponent<Rigidbody>();
    }


    
    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(transform.position.x, .34f, transform.position.z);

        //this is for mobile touch
        if (swipe.instance.LeftSwipe==1 && PointsManager.instance.gamestate != 10 && PointsManager.instance.gamestate != 0 && PointsManager.instance.gamestate != -1)
        {
            //BallPos = 0;
            fixingforce = 1;
            swipe.instance.LeftSwipe = 0;
        }
        if (swipe.instance.RightSwipe==1&& PointsManager.instance.gamestate != 10 && PointsManager.instance.gamestate != 0 && PointsManager.instance.gamestate != -1)
        {
            //BallPos = 0;
            fixingforce = 2;
            swipe.instance.RightSwipe = 0;
        }

        //this is for keyboard left and right arrow
        if (Input.GetKeyDown(KeyCode.LeftArrow)&&PointsManager.instance.gamestate!=10 && PointsManager.instance.gamestate != 0 &&PointsManager.instance.gamestate!=-1)
        {
            //BallPos = 0;
            fixingforce = 1;
        }
        if (Input.GetKeyDown(KeyCode.RightArrow) && PointsManager.instance.gamestate != 10 && PointsManager.instance.gamestate != 0 && PointsManager.instance.gamestate != -1)
        {
            //BallPos = 0;
            fixingforce = 2;
        }

        if (PointsManager.instance.gamestate==0)
        {
            gameState = true;
        }
        if (gameState)
        {
            // transform.Translate(0, 0, forceToBall*Time.deltaTime);

            fixingspeed = 1;
            
        }
       
    }

    public void UnfreezeTheBall()
    {
        rb.constraints = RigidbodyConstraints.None;
    }
    private void FixedUpdate()
    {
        if (PointsManager.instance.gamestate == 20)
        {
            
        }

        transform.Rotate(PointsManager.instance.speed * Time.deltaTime * speedfactor, 0, 0, Space.World);  //////////////////makes it look natural

        //////////////////////////////////////////////////////////////////////////////////////////////////
        if (PointsManager.instance.StopBall == 1&&PointsManager.instance.gamestate!=-1&& PointsManager.instance.gamestate != 0&PointsManager.instance.freezetheBall==1)
        {
            Debug.Log("55555555555555555555555555ssssssss");   ///this is different freeze rotation
            rb.constraints = RigidbodyConstraints.FreezeRotation;
            rb.constraints=  RigidbodyConstraints.FreezePosition;

           //  rb.constraints = RigidbodyConstraints.None;      this is when we want to unfreeze the rotation.

        }

        ////////////////////////checking speed decrease of ball
        if (PointsManager.instance.gamestate != 0 && PointsManager.instance.gamestate != 10)
        {
            changeSpeed();
            
        }

        if (BallPos == 1)
        {
            transform.position = new Vector3(-.7f, transform.position.y, transform.position.z);
        }
        if (BallPos == 2)
        {
            transform.position = new Vector3(0f, transform.position.y, transform.position.z);
        }
        if (BallPos == 3)
        {
            transform.position = new Vector3(.7f, transform.position.y, transform.position.z);
        }
        if (BallPos == -1)
        {
            transform.position = new Vector3(0f, transform.position.y, transform.position.z);
            //BallPos = 0;
        }

        if (fixingspeed==1)
        {
            
            moveballForward();
            fixingspeed = 0;
        }
        if (fixingforce == 1)
        {
            moveBallLeft();
            fixingforce = 0;
        }
        if (fixingforce == 2)
        {
            moveBallRight();
            fixingforce = 0;
        }
    }

    void changeSpeed()
    {
        speedOfBall = PointsManager.instance.speed;                        /////speed changer
        // rb.AddForce(0, 0, forceToBall * Time.deltaTime);
        rb.velocity = new Vector3(0, 0, speedOfBall * Time.deltaTime);
    }
    void moveBallLeft()
    {
        Debug.Log("left key is pressed");
        float a = transform.position.x;
        if (a == 0)
        {
            leftcoroutinecheck = 1;
            StartCoroutine("moveLeftCoroutine");
            
        }
        if (a ==.7f)
        {
            leftcoroutinecheck = 2;
            StartCoroutine("moveLeftCoroutine");
            
        }
        
    }
  
    void moveBallRight()
    {
        Debug.Log("right key is pressed");
        float b = transform.position.x;
        if (b == 0)
        {
           rightcoroutinecheck = 1;
            StartCoroutine("moveRightCoroutine");
            
        }
        if (b==-.7f)
        {
            rightcoroutinecheck = 2;
            StartCoroutine("moveRightCoroutine");
            
        }

    }
    IEnumerator moveRightCoroutine()
    {
        
        //ballSwipeSound();

       /// yield return new WaitForSeconds(waitTheCoroutine);  dont wait coroutine for fast response

        if (rightcoroutinecheck == 1)
        {
            Invoke("ballSwipeSound", BallLeftRight2);
            BallPos = 0;
            //object is at centre
            


            transform.position = new Vector3(.1f, transform.position.y, transform.position.z);
            yield return new WaitForSeconds(waitTheCoroutine);
            transform.position = new Vector3(.2f, transform.position.y, transform.position.z);
            yield return new WaitForSeconds(waitTheCoroutine);
            transform.position = new Vector3(.3f, transform.position.y, transform.position.z);
            yield return new WaitForSeconds(waitTheCoroutine);
            transform.position = new Vector3(.4f, transform.position.y, transform.position.z);
            yield return new WaitForSeconds(waitTheCoroutine);
            transform.position = new Vector3(.5f, transform.position.y, transform.position.z);
            yield return new WaitForSeconds(waitTheCoroutine);
            transform.position = new Vector3(.6f, transform.position.y, transform.position.z);
            yield return new WaitForSeconds(waitTheCoroutine);
            transform.position = new Vector3(.7f, transform.position.y, transform.position.z);
            yield return new WaitForSeconds(waitTheCoroutine);

            rightcoroutinecheck = 0;
            BallPos = 3;
            StopCoroutine("moveRightCoroutine");

        }
        if (rightcoroutinecheck == 2)
        {
            Invoke("ballSwipeSound", BallLeftRight2);


            BallPos = 0;
            //object is at left side
            transform.position = new Vector3(-.6f, transform.position.y, transform.position.z);
            yield return new WaitForSeconds(waitTheCoroutine);
            transform.position = new Vector3(-.5f, transform.position.y, transform.position.z);
            yield return new WaitForSeconds(waitTheCoroutine);
            transform.position = new Vector3(-.4f, transform.position.y, transform.position.z);
            yield return new WaitForSeconds(waitTheCoroutine);
            transform.position = new Vector3(-.3f, transform.position.y, transform.position.z);
            yield return new WaitForSeconds(waitTheCoroutine);
            transform.position = new Vector3(-.2f, transform.position.y, transform.position.z);
            yield return new WaitForSeconds(waitTheCoroutine);
            transform.position = new Vector3(-.1f, transform.position.y, transform.position.z);
            yield return new WaitForSeconds(waitTheCoroutine);
            transform.position = new Vector3(0, transform.position.y, transform.position.z);
            yield return new WaitForSeconds(waitTheCoroutine);




            rightcoroutinecheck = 0;
            BallPos = 2;
            StopCoroutine("moveRightcoroutine");
        }

    }

    private void ballSwipeSound()
    {
        ManageTheAudio.instance.Play("ballLeftRightSound", BallLeftRight1);
    }

    IEnumerator moveLeftCoroutine()
    {

        ///yield return new WaitForSeconds(waitTheCoroutine);   


        if (leftcoroutinecheck == 1)
        {
            Invoke("ballSwipeSound", BallLeftRight2);

            BallPos = 0;
            //object is at centre
            transform.position = new Vector3(-.1f, transform.position.y, transform.position.z);
            yield return new WaitForSeconds(waitTheCoroutine);
            transform.position = new Vector3(-.2f, transform.position.y, transform.position.z);
            yield return new WaitForSeconds(waitTheCoroutine);
            transform.position = new Vector3(-.3f, transform.position.y, transform.position.z);
            yield return new WaitForSeconds(waitTheCoroutine);
            transform.position = new Vector3(-.4f, transform.position.y, transform.position.z);
            yield return new WaitForSeconds(waitTheCoroutine);
            transform.position = new Vector3(-.5f, transform.position.y, transform.position.z);
            yield return new WaitForSeconds(waitTheCoroutine);
            transform.position = new Vector3(-.6f, transform.position.y, transform.position.z);
            yield return new WaitForSeconds(waitTheCoroutine);
            transform.position = new Vector3(-.7f, transform.position.y, transform.position.z);
            yield return new WaitForSeconds(waitTheCoroutine);
            leftcoroutinecheck = 0;
            BallPos = 1;
            StopCoroutine("moveLeftcoroutine");
        }
        if (leftcoroutinecheck == 2)
        {
            Invoke("ballSwipeSound", BallLeftRight2);

            BallPos = 0;
            //object is at right side
            transform.position = new Vector3(.6f, transform.position.y, transform.position.z);
            yield return new WaitForSeconds(waitTheCoroutine);
            transform.position = new Vector3(.5f, transform.position.y, transform.position.z);
            yield return new WaitForSeconds(waitTheCoroutine);
            transform.position = new Vector3(.4f, transform.position.y, transform.position.z);
            yield return new WaitForSeconds(waitTheCoroutine);
            transform.position = new Vector3(.3f, transform.position.y, transform.position.z);
            yield return new WaitForSeconds(waitTheCoroutine);
            transform.position = new Vector3(.2f, transform.position.y, transform.position.z);
            yield return new WaitForSeconds(waitTheCoroutine);
            transform.position = new Vector3(.1f, transform.position.y, transform.position.z);
            yield return new WaitForSeconds(waitTheCoroutine);
            transform.position = new Vector3(0, transform.position.y, transform.position.z);
            yield return new WaitForSeconds(waitTheCoroutine);
            leftcoroutinecheck = 0;
            BallPos = 2;
            StopCoroutine("moveLeftcoroutine");
        }

    }

    void moveballForward()
    {
        speedOfBall = PointsManager.instance.speed;                        /////speed changer
        // rb.AddForce(0, 0, forceToBall * Time.deltaTime);
        rb.velocity = new Vector3(0, 0, speedOfBall * Time.deltaTime);
    }

    private void OnTriggerExit(Collider other)
    {

        
        if (other.transform.gameObject.tag == "BorderRed")
        {
            
            gameObject.GetComponent<Renderer>().material = other.transform.gameObject.GetComponent<Renderer>().material;
            gameObject.tag = "PlayerRed";
            Destroy(other.transform.gameObject, 1f);
            indexPlayer = 1;
        }

        if (other.transform.gameObject.tag == "BorderGreen")
        {
           
            gameObject.GetComponent<Renderer>().material = other.transform.gameObject.GetComponent<Renderer>().material;
            gameObject.tag = "PlayerGreen";
            Destroy(other.transform.gameObject, 1f);
            indexPlayer = 2;
        }

        if (other.transform.gameObject.tag == "BorderBlue")
        {
            
            gameObject.GetComponent<Renderer>().material = GameObject.FindWithTag("BorderBlue").GetComponent<Renderer>().material;
            gameObject.tag = "PlayerBlue";
            Destroy(other.transform.gameObject, 1f);
            indexPlayer = 3;
        }



    }

    private void OnTriggerEnter(Collider other)
    {
        float c = ((8 * PointsManager.instance.speed) - 560) / 900;
        if (other.transform.gameObject.tag == "BorderRed")
        {
            ManageTheAudio.instance.Play("box", 0f);
            ManageTheAudio.instance.ListOfSounds[5].AUDIOsOURCE.pitch = c;
            Debug.Log("tagged");
           
        }

        if (other.transform.gameObject.tag == "BorderGreen")
        {
            ManageTheAudio.instance.Play("box", 0f);
            Debug.Log("tagged");
            ManageTheAudio.instance.ListOfSounds[5].AUDIOsOURCE.pitch = c;
        }

        if (other.transform.gameObject.tag == "BorderBlue")
        {
            ManageTheAudio.instance.Play("box", 0f);
            Debug.Log("tagged");
            ManageTheAudio.instance.ListOfSounds[5].AUDIOsOURCE.pitch = c;
        }
        /// ManageTheAudio.instance.Play("box", 0f);
        if (other.transform.gameObject.tag == "CrystalRed")
        {

            if (indexPlayer == 1)
            {
                //point
                //Debug.Log("pointc");
            }
            else
            {
                //loose
                //Debug.Log("loosec");
            }
        }

        if (other.transform.gameObject.tag == "CrystalGreen")
        {
            if (indexPlayer == 2)
            {
                //point
                //Debug.Log("pointc");
            }
            else
            {
                //loose
               // Debug.Log("loosec");
            }
        }

        if (other.transform.gameObject.tag == "CrystalBlue")
        {
            if (indexPlayer == 3)
            {
                //point
                //Debug.Log("pointc");
            }
            else
            {
                //loose
               // Debug.Log("loosec");
            }
        }

       
    }


}
