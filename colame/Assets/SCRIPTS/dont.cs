using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dont : MonoBehaviour
{
    
    public static dont instance;
    public int k = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void Awake()
    {
        if (instance = null)
        {
            instance = this;
        }
        DontDestroyOnLoad(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
