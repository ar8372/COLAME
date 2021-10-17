using UnityEngine.Audio;
using System;
using UnityEngine;

public class ManageTheAudio : MonoBehaviour
{
    
    
    public SOUNDs[] ListOfSounds;

    public int music1Status = 1;
    public int music2Status = 1;

    public static ManageTheAudio instance;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);

        foreach(SOUNDs s in ListOfSounds)
        {
           s.AUDIOsOURCE= gameObject.AddComponent<AudioSource>();
            s.AUDIOsOURCE.clip = s.SongDropHere;
            s.AUDIOsOURCE.volume = s.volume;
            s.AUDIOsOURCE.pitch = s.pitch;
            s.AUDIOsOURCE.loop = s.LoopIt;
            //s.AUDIOsOURCE.playOnAwake = s.StatusOfPlayOnAwake;    //play on awake won't work
        }
    }
    // Start is called before the first frame update
    private void Start()
    {
        Play("Theme",0f);
    }
    public void Play(string NAME,float time)
    {
       SOUNDs s= Array.Find(ListOfSounds, SOUNDss => SOUNDss.name == NAME);    ///quite confusing clear now
        if (s == null)
        {
            Debug.LogWarning("name " + NAME + " is not found");
            return;
        }
            
        s.AUDIOsOURCE.Play();
        s.AUDIOsOURCE.time = time;

    }
    public void ThemeVol0()
    {
        Debug.Log("called to vol0");
        
        ListOfSounds[0].AUDIOsOURCE.volume = 0;
        
    }
    public void ThemeVol1()
    {
        Debug.Log("called to vol1");

        ListOfSounds[0].AUDIOsOURCE.volume = 0.07f;
        
    }

    public void soundVo0()
    {
        ListOfSounds[1].AUDIOsOURCE.volume = 0f;
        ListOfSounds[2].AUDIOsOURCE.volume = 0f;
        ListOfSounds[3].AUDIOsOURCE.volume = 0f;
        ListOfSounds[4].AUDIOsOURCE.volume = 0f;
        ListOfSounds[5].AUDIOsOURCE.volume = 0f;
        ListOfSounds[6].AUDIOsOURCE.volume = 0f;
        ListOfSounds[7].AUDIOsOURCE.volume = 0f;
        ListOfSounds[8].AUDIOsOURCE.volume = 0f;
        ListOfSounds[9].AUDIOsOURCE.volume = 0f;
        ListOfSounds[10].AUDIOsOURCE.volume = 0f;
        ListOfSounds[11].AUDIOsOURCE.volume = 0f;

    }
    public void soundVo1()
    {
        ListOfSounds[1].AUDIOsOURCE.volume = 0.3f;
        ListOfSounds[2].AUDIOsOURCE.volume = 0.648f;
        ListOfSounds[3].AUDIOsOURCE.volume = 0.2f;
        ListOfSounds[4].AUDIOsOURCE.volume = 0.3f;
        ListOfSounds[5].AUDIOsOURCE.volume = 1f;
        ListOfSounds[6].AUDIOsOURCE.volume = .3f;
        ListOfSounds[7].AUDIOsOURCE.volume = 0.15f;
        ListOfSounds[8].AUDIOsOURCE.volume = .5f;
        ListOfSounds[9].AUDIOsOURCE.volume = 1f;
        ListOfSounds[10].AUDIOsOURCE.volume = 0.5f;
        ListOfSounds[11].AUDIOsOURCE.volume = 0.7f;

    }


}
