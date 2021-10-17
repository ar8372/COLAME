using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rOTATE : MonoBehaviour
{
    float j;
    int i;

    public float CrystalRotationSpeed;
    // Start is called before the first frame update
    void Start()
    {
        i = Random.Range(0, 2);
        if (i == 0)
        {
            j = CrystalRotationSpeed;
        }
        else
        {
            j = -CrystalRotationSpeed;
        }
    }
    

    // Update is called once per frame
    void Update()
    {
        //if (PointsManager.instance.level == 4 || PointsManager.instance.level == 5 || PointsManager.instance.level == 6 || PointsManager.instance.level == 8 || PointsManager.instance.level == 9)
        //{

        //    transform.Rotate(0, j * Time.deltaTime, 0);
        //}        $
        if (PointsManager.instance.level == 2 || PointsManager.instance.level == 3 || PointsManager.instance.level >=5 )
        {

            transform.Rotate(0, j * Time.deltaTime, 0);
        }
    }
}
