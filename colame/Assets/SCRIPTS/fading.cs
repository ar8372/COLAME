using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fading : MonoBehaviour
{
    int flag = 0;

    float exposureStart = 0.6f;
    float exposureEnd = 0.2f;
    public float currentExposure = 10f;
    float currentAlpha;
    float fadeTiming = 0.5f;

    //public float interval;
    //public float exposure;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (PointsManager.instance.score > 100&&(flag==0))
        {
            fadeDown();
            flag = 1;
        }
    }
    void fadeTheSky()
    {
        //for (int i = 0; i < 10; i++)
        //{
        //    yield return new WaitForSeconds(interval);
        //    exposure += 0.3f;
        //    RenderSettings.skybox.SetFloat("_Exposure", exposure);

        //}
    }

    

    private void fadeDown()
    {
        StartCoroutine(Fade(exposureStart, exposureEnd));
    }

    IEnumerator Fade(float startAlpha, float endAlpha)
    {
        float elapsedTime = 0.0f;
        while (elapsedTime < fadeTiming)
        {
            elapsedTime += Time.deltaTime;
            currentAlpha = Mathf.Lerp(startAlpha, endAlpha, Mathf.Clamp01(elapsedTime / fadeTiming));
            RenderSettings.skybox.SetFloat("_Exposure", currentExposure);
            yield return new WaitForEndOfFrame();
        }
    }
}
