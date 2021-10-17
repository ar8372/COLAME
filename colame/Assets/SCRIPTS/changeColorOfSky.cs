using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changeColorOfSky : MonoBehaviour
{
    int flag = 0;

    float exposureStart = 0.7f;
    float exposureEnd = 0f;
    public float currentExposure;
    public float currentAlpha;
    float fadeTiming = 5f;

    // Start is called before the first frame update
    void Start()
    {
       
        ////////////////Debug.Log(Time.deltaTime + "this is time");  important no matter how many times you call it will not reach there
        RenderSettings.skybox.SetFloat("_Exposure", currentExposure);
    }

    // Update is called once per frame
    void Update()
    {
        
        ///////////////////Debug.Log("hello this is the lerp "+Mathf.Lerp(1, 2, .2f));      important no matter how many times you call it will not reach there
        if (PointsManager.instance.level==1&&(flag==0))
        {
            exposureStart = .7f;
            exposureEnd = 0f;
            fadeDown();
            flag = 1;
        }
        if (PointsManager.instance.level == 2 && (flag == 1))
        {
            exposureStart = 0f;
            exposureEnd = 0.7f;
          
            fadeDown();
            flag = 0;
        }
        if (PointsManager.instance.level == 3 && (flag == 0))
        {
            exposureStart = .7f;
            exposureEnd = 0f;
            fadeDown();
            flag = 1;
        }
        if (PointsManager.instance.level == 4 && (flag == 1))
        {
            exposureStart = 0f;
            exposureEnd = 0.7f;
            
            fadeDown();
            flag = 0;
        }
        if (PointsManager.instance.level == 5 && (flag == 0))
        {
            exposureStart = .7f;
            exposureEnd = 0f;
            fadeDown();
            flag = 1;
        }
        if (PointsManager.instance.level == 6 && (flag == 1))
        {
            exposureStart = 0f;
            exposureEnd = 0.7f;
            fadeDown();
            flag = 0;
        }
        if (PointsManager.instance.level == 7 && (flag == 0))
        {
            exposureStart = .7f;
            exposureEnd = 0f;
            fadeDown();
            flag = 1;
        }
        if (PointsManager.instance.level == 8 && (flag == 1))
        {
            exposureStart = 0f;
            exposureEnd = 0.7f;
            fadeDown();
            flag = 0;
        }
        if (PointsManager.instance.level == 9 && (flag == 0))
        {
            exposureStart = .7f;
            exposureEnd = 0f;
            fadeDown();
            flag = 1;
        }
    }

    

    private void fadeDown()
    {
        StartCoroutine(Fade(exposureStart, exposureEnd));
    }

    IEnumerator Fade(float startAlpha, float endAlpha)
    {
        float elapsedTime = 0.0f;
        //while (elapsedTime < fadeTiming)
        //{
        //    elapsedTime += Time.deltaTime;
        //    currentAlpha = Mathf.Lerp(startAlpha, endAlpha, Mathf.Clamp01(elapsedTime / fadeTiming));
        //    RenderSettings.skybox.SetFloat("_Exposure", currentExposure);
        //    yield return new WaitForEndOfFrame();
        //}
        while (elapsedTime < fadeTiming)
        {
            elapsedTime += Time.deltaTime;            ////////////////////counts total time finished
            Debug.Log(elapsedTime+"  "+currentExposure);
            currentExposure = Mathf.Lerp(exposureStart,exposureEnd, Mathf.Clamp01(elapsedTime / fadeTiming));
            RenderSettings.skybox.SetFloat("_Exposure", currentExposure);
            Debug.Log("hi");
            yield return new WaitForEndOfFrame();
        }
    }
}
