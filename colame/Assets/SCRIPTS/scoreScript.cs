using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scoreScript : MonoBehaviour
{
    public int FlagGoONce = 0;

    public float Spacing;

    public GameObject TextObject;
    //public GameObject TextObjectInstantiated;

    //public GameObject instanceScorePos;
    Vector3 Pos;
    int SpeedStringLength;
    string SpeedString;
    int noOfDiamonds;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (PointsManager.instance.FINISHsTATES == 1 && FlagGoONce == 0)
        {
            FlagGoONce = 1;
            Pos = transform.position;



            noOfDiamonds = PointsManager.instance.scoreInt;             ////just a small twick in diamonds no
            SpeedString = noOfDiamonds.ToString();
            SpeedStringLength = SpeedString.Length;
            Debug.Log("string length =" + SpeedStringLength);
            for (int i = 0; i < SpeedStringLength; i++)
            {
                //TextObjectInstantiated = Instantiate(TextObject, Pos, Quaternion.identity);
                //method 1
                // TextObjectInstantiated.transform.parent = transform;
                //mehod 2
                GameObject TextObjectInstantiated = Instantiate(TextObject, Pos, Quaternion.identity, transform);
                float a = (4.0f / 5.0f) * Spacing;
                float b = ((3.0f / 5.0f) * Spacing);
                TextObjectInstantiated.transform.position += new Vector3(a * i, 0, -b * i);
                switch (SpeedString[i])
                {
                    case '0':
                        (TextObjectInstantiated.transform.GetChild(0).gameObject).SetActive(true);
                        break;
                    case '1':
                        (TextObjectInstantiated.transform.GetChild(1).gameObject).SetActive(true);
                        break;
                    case '2':
                        (TextObjectInstantiated.transform.GetChild(2).gameObject).SetActive(true);
                        break;
                    case '3':
                        (TextObjectInstantiated.transform.GetChild(3).gameObject).SetActive(true);
                        break;
                    case '4':
                        (TextObjectInstantiated.transform.GetChild(4).gameObject).SetActive(true);
                        break;
                    case '5':
                        (TextObjectInstantiated.transform.GetChild(5).gameObject).SetActive(true);
                        break;
                    case '6':
                        (TextObjectInstantiated.transform.GetChild(6).gameObject).SetActive(true);
                        break;
                    case '7':
                        (TextObjectInstantiated.transform.GetChild(7).gameObject).SetActive(true);
                        break;
                    case '8':
                        (TextObjectInstantiated.transform.GetChild(8).gameObject).SetActive(true);
                        break;
                    case '9':
                        (TextObjectInstantiated.transform.GetChild(9).gameObject).SetActive(true);
                        break;
                }

                //transform.position += transform.TransformDirection(Spacing,0,0);
                // Pos = transform.position;

            }
        }

    }
}

