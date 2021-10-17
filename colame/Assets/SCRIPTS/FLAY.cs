using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FLAY : MonoBehaviour
{
    public float decreaseVolumeOfCoin;
    public int CrystalMarkedWithSound = 0;
    public float Time1 = 0;
    public float Time2;

    public float xRotate, yRotate, zRotate;
    Rigidbody RB;
    // Start is called before the first frame update
    void Start()
    {
        RB = GetComponent<Rigidbody>();
        Destroy(gameObject, 3f);
    }

    // Update is called once per frame
    void Update()
    {
        RB.AddForce(0, 3000f*Time.deltaTime, 6000f*Time.deltaTime);
        transform.Rotate(xRotate * Time.deltaTime, yRotate * Time.deltaTime, zRotate * Time.deltaTime);
        if (CrystalMarkedWithSound == 1&&UImanager.instance.Tempmusic2==1)
        {
            //Time1 += Time.deltaTime;
            //if(Time1==.2f)
            //{
            //    gameObject.GetComponent<AudioSource>().volume = .07f;
              
            //}
            //if (Time1 == .3f)
            //{
            //    gameObject.GetComponent<AudioSource>().volume = .06f;

            //}
            //if (Time1 == .4f)
            //{
            //    gameObject.GetComponent<AudioSource>().volume = .04f;

            //}
            //if (Time1 == .5f)
            //{
            //    gameObject.GetComponent<AudioSource>().volume = .01f;

            //}
            //if (Time1 >= Time2)
            //{
            //    gameObject.GetComponent<AudioSource>().Stop();
            //    CrystalMarkedWithSound = 0;
            //}

            ////coroutine gives better sound effect
            ///
            StartCoroutine("DecreaseSpeed");
            CrystalMarkedWithSound = 0;
        }
    }
    IEnumerator DecreaseSpeed()
    {
        //gameObject.GetComponent<AudioSource>().volume = .5f;


        while (gameObject.GetComponent<AudioSource>().volume > 0)
        {
            gameObject.GetComponent<AudioSource>().volume -= decreaseVolumeOfCoin * Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        gameObject.GetComponent<AudioSource>().Stop();
        
        StopCoroutine("DecreaseSpeed");
    }

}
