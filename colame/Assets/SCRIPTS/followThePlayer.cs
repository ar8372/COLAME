using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followThePlayer : MonoBehaviour
{
    public GameObject sampleocean;

    public GameObject endpt;
    Vector3 endPt;

    GameObject prefabCreated1;
    GameObject prefabCreated2;
    // Start is called before the first frame update
    void Start()
    {
        endPt = endpt.transform.position;
       // endPt = new Vector3(0, 0, 70);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            prefabCreated1 = Instantiate(sampleocean, endPt, Quaternion.identity);
            GameObject child1= prefabCreated1.transform.GetChild(1).gameObject;

            endPt = child1.transform.position;

           

        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Destroy(gameObject);
        }
    }
}
