using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateBorder : MonoBehaviour
{
    float j;
    int i;
    public float BorderRotationSpeed;
    // Start is called before the first frame update
    void Start()
    {
        i = Random.Range(0, 2);
        if (i == 0)
        {
            j = BorderRotationSpeed;
        }
        else
        {
            j = -BorderRotationSpeed;
        }
    }

    // Update is called once per frame
    void Update()
    {
        //if(PointsManager.instance.level==7|| PointsManager.instance.level == 8 || PointsManager.instance.level == 9)
        //{


        //    transform.Rotate(0, j * Time.deltaTime, 0);
        //}          $
        if (PointsManager.instance.level == 4 || PointsManager.instance.level >=5 )
        {


            transform.Rotate(0, j * Time.deltaTime, 0);
        }

    }
}
