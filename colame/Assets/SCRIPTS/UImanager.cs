using System.Collections;
using System.Collections.Generic;
using System.Runtime.ExceptionServices;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UImanager : MonoBehaviour
{
    public GameObject spawnObj;

    /// instead of image i use Gameobject RED and that also worked /////////////public Image RedWarning;
    public GameObject RED;
    int TempSwipeLeft, TempSwipeRight ,TempKey,TempKeyNoChange=0;

    public GameObject SwipeRight, SwipeLeft;
    
    public GameObject coinsPrefab;
    
    public int Tempmusic1, Tempmusic2;

    public float panel1, panel2, LeaderBoardSoundNLeaderBoardSoundA, LeaderBoardSoundNLeaderBoardSoundB,initialPitch,PitchChangeValue, WaitToReplaySound,WaitChangeValue;
    /// <summary>
    /// /sound
    /// </summary>
    public GameObject Player;
    public AudioSource[] mysound;
    public AudioSource sound1;
    public AudioSource sound2;

    public float setTheMaxPitch;
    /// 

    int demoScore, demoCoins, demohighScore;

    public float IncreasetotaltimeA, IncreasetotaltimeB, IncreasetotaltimeC, elapsedtimeA;
    public GameObject star1, star2, star3;
    int callUpdateOnce = 0;
    int ScoreC;
    int HighScoreC;
    int NoOfDiamondsC;
    public Text HighScoreTextMainMenu;
    public Text CoinsTextMainMenu;
    public Text HighScoreTextPauseMenu;
    public Text CoinsTextPauseMenu;
    public Text HighScoreTextGameOverMenu;
    public Text CointsGameoverMenu;
    public Text ScoreGameoverMenu;
    public Text NoOfKeysRequired;
    public Text TotalNoOfKeys;

    public Text LevelTextPause;

    public int TotalNOOfDiamondsSystem;
    //////////////////////////////////////////////////
   // public Text PausePanelDiamondText;
    /////////////////////////////////////////////////
    public float t1=0;
    public float t2;
    
    public GameObject MainMenuUp;
    public GameObject GameOverPanelshow;
    public GameObject LifePanel;

    public static UImanager instance;

    public GameObject PausePanel;
    int flagForPreventingRecallingofPlayerPrefs = 0;

    public int lifeState = 0;
    private void Awake()
    {
        TempKeyNoChange = 0;
        if (PlayerPrefs.HasKey("Key"))
        {

            TempKey = PlayerPrefs.GetInt("Key");
            
        }
        else
        {
            PlayerPrefs.SetInt("Key", 0);
            TempKey = 0;
        }
        //if (PlayerPrefs.HasKey("SwipeRight"))
        //{
        //    TempSwipeRight = PlayerPrefs.GetInt("SwipeRight");

        //}
        //else                                                                                      ///two prefs not needed
        //{
        //    TempSwipeRight = 0;
        //    // PlayerPrefs.SetInt("SwipeRight", 0);

        //}   just write this
        TempSwipeRight =0;
        if (PlayerPrefs.HasKey("SwipeLeft"))
        {
            Debug.Log("a called");
            TempSwipeLeft = 2;
            flagForPreventingRecallingofPlayerPrefs = 1;
        }
        else
        {
            Debug.Log("b called");
            TempSwipeLeft = 0;
            //PlayerPrefs.SetInt("SwipeLeft", 0);
            flagForPreventingRecallingofPlayerPrefs = 0;
        }
        ///////////////////////////////////////////////////////////////////////////////////////

        if (PlayerPrefs.HasKey("music1"))
        {
            Tempmusic1 = PlayerPrefs.GetInt("music1");
        }
        else
        {
            Tempmusic1 = 1;
            PlayerPrefs.SetInt("music1", 1);
        }
        if (PlayerPrefs.HasKey("music2"))
        {
            Tempmusic2 = PlayerPrefs.GetInt("music2");
        }
        else
        {
            Tempmusic2 = 1;
            PlayerPrefs.SetInt("music2", 1);
        }


        // PlayerPrefs.SetInt("ScoreComp", 0);    ////not required
        ScoreC = 0;
        //PlayerPrefs.SetInt("HighScoreComp", 0);       use this two to refresh value to 0
        //PlayerPrefs.SetInt("diamondsNOComp", 0);
        if (PlayerPrefs.HasKey("HighScoreComp"))
        {
            HighScoreC = PlayerPrefs.GetInt("HighScoreComp");
        }
        else
        {
            HighScoreC = 0;
            PlayerPrefs.SetInt("HighScoreComp", 0);
        }

        if (PlayerPrefs.HasKey("diamondsNOComp"))
        {
            NoOfDiamondsC = PlayerPrefs.GetInt("diamondsNOComp");
        }
        else
        {
            NoOfDiamondsC = 0;
            PlayerPrefs.SetInt("diamondsNOComp", 0);
        }
        if (PlayerPrefs.HasKey("ScoreNOComp"))
        {
            ScoreC = PlayerPrefs.GetInt("ScoreNOComp");
        }
        else
        {
            ScoreC = 0;
            PlayerPrefs.SetInt("ScoreNOComp", 0);
        }






        Debug.Log("awake called");

        if (instance == null)
        {
            instance = this;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        ////sounds///
        mysound = Player.GetComponents<AudioSource>();
        sound1 = mysound[0];
        sound2 = mysound[1];


        if (Tempmusic1 == 0)
        {
           ManageTheAudio.instance.ThemeVol0();
        }
        else
        {
           ManageTheAudio.instance.ThemeVol1();
        }

        if (Tempmusic2 == 0)
        {
            ManageTheAudio.instance.soundVo0();
            sound1.volume = 0;
            sound2.volume = 0;
            coinsPrefab.GetComponent<AudioSource>().volume = 0f;
             Player.GetComponents<AudioSource>();

        }
        else
        {
            ManageTheAudio.instance.soundVo1();
            sound1.volume = .8f;
            sound2.volume = 1f;
            coinsPrefab.GetComponent<AudioSource>().volume = 0.008f;
            
        }

        if (ManageTheAudio.instance.music1Status == 1)
        {

        }

       


        //////////
        // PlayerPrefs.SetInt("diskState",0) ;


        if (PlayerPrefs.GetInt("diskState")==0)
        {
            

            MainMenuUp.SetActive(true);
            HighScoreTextMainMenu.text = HighScoreC.ToString();
            CoinsTextMainMenu.text = NoOfDiamondsC.ToString();

            Debug.Log("ddddddddddddddddddddddddddddddddddddddddddddddddddddd");
            Debug.Log("ddddddddgggggggggggggggggggggggggggggggggggggggggg" + Tempmusic1);
            if (Tempmusic1 == 0)
            {
                GameObject musicOff = MainMenuUp.transform.GetChild(15).gameObject;
                musicOff.SetActive(true);
                GameObject musicOn = MainMenuUp.transform.GetChild(18).gameObject;
                musicOn.SetActive(false);
            }
            else
            {
                GameObject musicOff = MainMenuUp.transform.GetChild(15).gameObject;
                musicOff.SetActive(false);
                GameObject musicOn = MainMenuUp.transform.GetChild(18).gameObject;
                musicOn.SetActive(true);
            }

            if (Tempmusic2 == 0)
            {
                GameObject musicOff = MainMenuUp.transform.GetChild(16).gameObject;
                musicOff.SetActive(true);
                GameObject musicOn = MainMenuUp.transform.GetChild(19).gameObject;
                musicOn.SetActive(false);
            }
            else
            {
                GameObject musicOff = MainMenuUp.transform.GetChild(16).gameObject;
                musicOff.SetActive(false);
                GameObject musicOn = MainMenuUp.transform.GetChild(19).gameObject;
                musicOn.SetActive(true);
            }



        }
        else
        {
           GameOverPanelshow.gameObject.SetActive(true);    
            PointsManager.instance.gamestate = 0;

            ScoreGameoverMenu.text = ScoreC.ToString();
            HighScoreTextGameOverMenu.text = HighScoreC.ToString();
            CointsGameoverMenu.text = NoOfDiamondsC.ToString();          ///to set value in gameover panel while going up

            ///panel up sound
            //ManageTheAudio.instance.Play("panel", panel1);
            Invoke("panelUpSounInvokeLate", panel2);
            GameOverPanelshow.gameObject.GetComponent<Animator>().Play("moveGameOverUp");
            //show animation 

            ////sound
            sound2.Play();
            CheckSpeedForRollingBall();
            ///
        }
        PlayerPrefs.SetInt("diskScore", PointsManager.instance.scoreInt);
        //PlayerPrefs.SetInt("diskState", PointsManager.instance.DiskState);
    }
    public void PlayClickedEndgamePanel()
    {

        Resume1();       ///// this is to ensure that bridge stop destroying after gameover panel is displayed and someone intentionally left at that panel for long.

        //sound add
        ManageTheAudio.instance.Play("button", 0f);
        ///

        PlayerPrefs.SetInt("HighScoreComp", HighScoreC);
        PlayerPrefs.SetInt("diamondsNOComp", NoOfDiamondsC);
        PlayerPrefs.SetInt("ScoreNOComp", ScoreC);

        PlayerPrefs.SetInt("diskState",1);
        //public static void Save();
        ManageTheAudio.instance.Play("button", 0f);
        sound2.Stop();

        if (TempKeyNoChange == 1)
        {
            PlayerPrefs.SetInt("Key", TempKey);
        }

        if (TempSwipeLeft == 2 & flagForPreventingRecallingofPlayerPrefs == 0)
        {
            SwipeGuide();      ///ensures name is assignes only once
        }

        SceneManager.LoadScene(0);

        

        //GameOverPanelshow.gameObject.GetComponent<Animator>().Play("moveGameOverUp");
        ////need to load scene again


        //PointsManager.instance.gamestate = 0;
        //MainMenuUp.gameObject.SetActive(false);//////////expo
        Debug.Log(" scene  is loaded is this executed");
    }

    public void KeyIncrease()
    {
        TempKey += 1;
        TempKeyNoChange = 1;
    }
    public void KeyDecrease()
    {
        TempKey -= 1;
        TempKeyNoChange = 1;
    }
    public void PlayClicked()
    {

        ////////////////////////////////////////////////////////////////////////////////////
        //TempSwipeLeft=0;                  //this was set just to check in while making the game
       // TempSwipeRight = 0;
        ///////////////////////////////////////////////////////////////////////////////////

        ManageTheAudio.instance.Play("button", 0f);
        ////lets add sound
        //sound2.Play();
        Invoke("StartRollingFirstTime", .01f);

        //FindObjectOfType<ManageTheAudio>().Play("")
        Invoke("panelUpSounInvokeLate", panel2);
        //panelUpSounInvokeLate();
        MainMenuUp.gameObject.GetComponent<Animator>().Play("mainMenuUp");
    }

    private void panelUpSounInvokeLate()
    {
        ManageTheAudio.instance.Play("panel", panel1);
    }

    public void CheckSpeedForRollingBall()
    {
        sound2.pitch = PointsManager.instance.speed * setTheMaxPitch / 250;
    }
    void StartRollingFirstTime()
    {
        sound2.Play();
        sound2.pitch = 0;
        
    }
    public void PauseClick()
    {
        //sound
        ManageTheAudio.instance.Play("button", 0f);

        LevelTextPause.text = PointsManager.instance.level.ToString();
        int v;
        v = PointsManager.instance.scoreInt% (6000+PointsManager.instance.DifferenceINLevelVal) ;
        

        HighScoreTextPauseMenu.text = HighScoreC.ToString();
        CoinsTextPauseMenu.text = NoOfDiamondsC.ToString();    ////pause panel diamond
        //PointsManager.instance.gamestate = 20;          ///faith
        PausePanel.SetActive(true);
        star1.SetActive(false);
        star2.SetActive(false);
        star3.SetActive(false);
        if (v < 2000)
        {
            star1.SetActive(true);
            star2.SetActive(false);
            star3.SetActive(false);
            //case 1;
           
        }
        else if (v < 4000)
        {
            star1.SetActive(true);
            star2.SetActive(true);
            star3.SetActive(false);
            //case 2;
            
        }
        else if (v < (6000+PointsManager.instance.DifferenceINLevelVal))
        {
            star1.SetActive(true);
            star2.SetActive(true);
            star3.SetActive(true);
            //case 3;
            
        }

        sound2.Pause();

        PauseGame();

        
    }
    public void Resumeclicked()
    {
        ///sound
        ManageTheAudio.instance.Play("button", 0f);

        sound2.Play();
        PausePanel.SetActive(false);
       // Invoke("ResumeGame", 3f);
        ResumeGame();
    }
    void PauseGame()
    {
        Time.timeScale = 0;
       // Time.unscaledDeltaTime = 0;
    }
    void ResumeGame()
    {
        //StartCoroutine("hi");
        Resume1();
    }

   
    void Resume1()
    {
        Time.timeScale = 1;
        //Time.unscaledDeltaTime = 1;
    }
    // Update is called once per frame
    void Update()
    {
        /////////////////////////////////////////////all about what is pressed when lifeState is 1;
        
        //////////////////////////////////////////////////////////////////////

        ////swipe  right panel
        if (Player.transform.position.z >=1.5f&& TempSwipeRight==0&&TempSwipeLeft==0)
        {
            SwipeRight.gameObject.SetActive(true);
            SwipeRight.gameObject.GetComponent<Animator>().Play("swipeRight");
            TempSwipeRight = 1;
        }
        if (Player.transform.position.z >=6f&&TempSwipeRight==1&TempSwipeLeft==0)
        {
            
            SwipeRight.gameObject.SetActive(false);
            //SwipeRight.gameObject.GetComponent<Animation>().Play("swipeRight");
            TempSwipeRight = 2;
        }
        ////swipe left  panel
        if (Player.transform.position.z >= 8.5f&& TempSwipeLeft==0)
        {
            SwipeLeft.gameObject.SetActive(true);
            SwipeLeft.gameObject.GetComponent<Animator>().Play("swipeLeft");
            TempSwipeLeft = 1;
        }
        if (Player.transform.position.z >= 12.5f)
        {
            SwipeLeft.gameObject.SetActive(false);
            //SwipeRight.gameObject.GetComponent<Animation>().Play("swipeRight");
            TempSwipeLeft = 2;
        }



        if (PointsManager.instance.gamestate == 10)
        {
            ///float demoScore, demoCoins,demohighScore;    make it gloabally available withing the script
            demohighScore = HighScoreC;   ////it has to be kept outside
            

            
            

           // demoCoins = NoOfDiamondsC;

            if (PointsManager.instance.scoreInt >HighScoreC)
            {
                HighScoreC = PointsManager.instance.scoreInt;
                
            }
            if (callUpdateOnce == 0)
            {
                callUpdateOnce = 1;
                ScoreC = PointsManager.instance.scoreInt;
                demoScore = 0;
                demoCoins = NoOfDiamondsC;
                NoOfDiamondsC += PointsManager.instance.NoOfDiamonds;

                //CointsGameoverMenu.text = NoOfDiamondsC.ToString();
                //ScoreGameoverMenu.text = PointsManager.instance.scoreInt.ToString();
                // HighScoreTextGameOverMenu.text = HighScoreC.ToString();

                MainMenuUp.SetActive(false);

                Invoke("InvokeLifePanelLate", 3.8f);
                Invoke("whatToDoIfNOthingIsClicked",3.5f+6f);
                //InvokeLifePanelLate();

                //Invoke("GameoverPanelShowLate", 3.8f + 5.5f);

                //Invoke("GameoverPanelShowLate", 3.8f);
                //GameoverPanelShowLate();

                //StartCoroutine("IncreaseScoreDiamondHighScore");
            }




            //GameOverPanelshow.gameObject.SetActive(true);

            ////so that it doesn't pop up in 

        }
    }
    public void whatToDoIfNOthingIsClicked()
    {
        if (lifeState == 1)
        {
            Invoke("GameoverPanelShowLate", .3f);
        }
    }

    public void ElseButtonclicked()
    {
        if (lifeState == 1)
        {
            lifeState = 2;
        }
        else
        {
            lifeState = 3;
            LifePanel.GetComponent<Animator>().enabled = false;

            Invoke("GameoverPanelShowLate", .3f);
           
        }
    }
    public void AddButtonclicked()
    {
        ///sound
        ManageTheAudio.instance.Play("button", 0f);

        lifeState = 5;
        //LifePanel.GetComponent<Animator>().enabled = false;
        /////Add
        LifePanel.SetActive(false);
        //Invoke("StartRollingFirstTime", .01f);

        PointsManager.instance.StopBall = 0;
        PointsManager.instance.freezetheBall = 0;
        Player.GetComponent<playerMovement>().UnfreezeTheBall();           //@
        PointsManager.instance.CheckStartClicked();
        RED.SetActive(false);
        callUpdateOnce = 0;
        spawnObj.GetComponent<SPAWNINGpT>().FLAG = 0;

        PointsManager.instance.speed = 200f;                               //////////////this will make it feel that it started from where it was left
        CheckSpeedForRollingBall();
        PointsManager.instance.rateToCallIncreasespeed = .07f;
        //PointsManager.instance.gamestate = 4;


        //add show here
        Invoke("waitforSeconds", 5f);
        //lifeState = 9;
    }
    public void KeyClicked()
    {
        ///sound
        ManageTheAudio.instance.Play("button", 0f);

        lifeState = 6;
        if (TempKey > 0)
        {
            lifeState = 7;
            ///
            //Restart
            LifePanel.SetActive(false);
            //Invoke("StartRollingFirstTime", .01f);

            PointsManager.instance.StopBall = 0;
            PointsManager.instance.freezetheBall = 0;
            Player.GetComponent<playerMovement>().UnfreezeTheBall();            //@
            PointsManager.instance.CheckStartClicked();
            RED.SetActive(false);
            callUpdateOnce = 0;
            spawnObj.GetComponent<SPAWNINGpT>().FLAG = 0;

            PointsManager.instance.speed = 280f;                 //////////////this will make it feel that it started from where it was left
            CheckSpeedForRollingBall();
            PointsManager.instance.rateToCallIncreasespeed = .07f;
            // PointsManager.instance.gamestate = 4;






            KeyDecrease();
            Invoke("waitforSeconds", 5f);
            //waitforSeconds();

        }
    }

    private void waitforSeconds()
    {
        if (lifeState == 7)
        {
            lifeState = 8;
        }
        if (lifeState == 5)
        {
            lifeState = 9;
        }
        
    }

    private void InvokeLifePanelLate()
    {
        Debug.Log("life caaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaled;");
        LifePanel.SetActive(true);
        
        TotalNoOfKeys.text = TempKey.ToString();
        int c = 1;
        NoOfKeysRequired.text = c.ToString();
        LifePanel.GetComponent<Animator>().Play("BlinkLife");
        lifeState = 1;
    }

    private void GameoverPanelShowLate()
    {
        LifePanel.SetActive(false);

        GameOverPanelshow.gameObject.SetActive(true);
        ScoreGameoverMenu.text = demoScore.ToString();    ////o always at starting
        GameOverPanelshow.gameObject.GetComponent<Animator>().Play("GameoverPanelDown");
        Invoke("panelUpSounInvokeLate", panel2);

        if (demohighScore < HighScoreC)
        {
            Debug.Log("HIGHsCOREcALLED");
            HighScoreTextGameOverMenu.text = demohighScore.ToString();
            StartCoroutine("IncreaseHighScore");
        }
        else
        {

            HighScoreTextGameOverMenu.text = HighScoreC.ToString();
        }
        if (demoCoins < NoOfDiamondsC)
        {
            Debug.Log("COINcALLED");
            CointsGameoverMenu.text = demoCoins.ToString();
            StartCoroutine("IncreaseDiamond");
        }
        else
        {
            CointsGameoverMenu.text = NoOfDiamondsC.ToString();
        }
        if (demoScore < ScoreC)
        {
            Debug.Log("sCOREcALLED");
            StartCoroutine("IncreaseScore");
            //Invoke("ScoreIncreasingSound", LeaderBoardSoundNLeaderBoardSoundB);
            //ScoreIncreasingSound();
            StartCoroutine("AudioSoundMaker");
        }
        else
        {
            ScoreGameoverMenu.text = PointsManager.instance.scoreInt.ToString();   ///but here rarely come
        }
    }
    IEnumerator AudioSoundMaker()
    {
        yield return new WaitForSeconds(LeaderBoardSoundNLeaderBoardSoundB);
        int v = 0;
        while (v < 1000)
        {
            v += 1;
            ManageTheAudio.instance.Play("LeaderBoardSoundNLeaderBoardSound", LeaderBoardSoundNLeaderBoardSoundA);
            ManageTheAudio.instance.ListOfSounds[10].AUDIOsOURCE.pitch = initialPitch;
            initialPitch += PitchChangeValue;

            yield return new WaitForSeconds(WaitToReplaySound);

            WaitToReplaySound -= WaitChangeValue;

           // ManageTheAudio.instance.ListOfSounds[10].AUDIOsOURCE.Stop();
            //ManageTheAudio.instance.Stop("LeaderBoardSoundNLeaderBoardSound");

        }
    }

    private void ScoreIncreasingSound()
    {
        ManageTheAudio.instance.Play("LeaderBoardSoundNLeaderBoardSound", LeaderBoardSoundNLeaderBoardSoundA);
    }

    IEnumerator IncreaseScore()
    {
        

        //yield return null;
        yield return new WaitForSeconds(1.8f);

        elapsedtimeA = 0;
        IncreasetotaltimeA += (PointsManager.instance.score / 10000) ;

        while (elapsedtimeA < IncreasetotaltimeA)
        {
            elapsedtimeA += Time.deltaTime;
            float currentValA = Mathf.Lerp(demoScore, ScoreC, Mathf.Clamp01(elapsedtimeA / IncreasetotaltimeA));

            ScoreGameoverMenu.text = Mathf.RoundToInt(currentValA).ToString();

            /// Invoke("IncreaseLeaderboardScoreLateInvoke", LeaderBoardSoundNLeaderBoardSoundB);   ///Aproach x for leader board didn't work
            //IncreaseLeaderboardScoreLateInvoke();

            yield return new WaitForEndOfFrame();
        }
        StopCoroutine("AudioSoundMaker");
        ManageTheAudio.instance.Play("endBeep", .2f);

        PauseClick();  /// this is to ensure that bridge stop destroying after gameover panel is displayed and someone intentionally left at that panel for long.

        StopCoroutine("IncreaseScore");

    }

    private void IncreaseLeaderboardScoreLateInvoke()
    {
        ManageTheAudio.instance.Play("LeaderBoardSoundNLeaderBoardSound", LeaderBoardSoundNLeaderBoardSoundA);
    }

    IEnumerator IncreaseHighScore()
    {
        // yield return null;
        yield return new WaitForSeconds(1.8f);
        elapsedtimeA = 0;
        while (elapsedtimeA < IncreasetotaltimeB)
        {
            elapsedtimeA += Time.deltaTime;
            float currentValB = Mathf.Lerp(demohighScore,HighScoreC, Mathf.Clamp01(elapsedtimeA / IncreasetotaltimeB));

            HighScoreTextGameOverMenu.text = Mathf.RoundToInt(currentValB).ToString();


            /// Invoke("IncreaseLeaderboardScoreLateInvoke", LeaderBoardSoundNLeaderBoardSoundB);   ///Aproach x for leader board didn't work

            yield return new WaitForEndOfFrame();
        }

        StopCoroutine("IncreaseHighScore");

    }
    IEnumerator IncreaseDiamond()
    {
        //yield return null;
        yield return new WaitForSeconds(1.8f);
        elapsedtimeA = 0;
        while (elapsedtimeA < IncreasetotaltimeC)
        {
            elapsedtimeA += Time.deltaTime;
            float currentValC = Mathf.Lerp(demoCoins, NoOfDiamondsC, Mathf.Clamp01(elapsedtimeA / IncreasetotaltimeA));

            CointsGameoverMenu.text = Mathf.RoundToInt(currentValC).ToString();


           /// Invoke("IncreaseLeaderboardScoreLateInvoke", LeaderBoardSoundNLeaderBoardSoundB);   ///Aproach x for leader board didn't work

            yield return new WaitForEndOfFrame();
        }

        StopCoroutine("IncreaseDiamond");

    }
    public void quitGAme()
    {
        if (TempKeyNoChange == 1)
        {
            PlayerPrefs.SetInt("Key", TempKey);
        }

        if (TempSwipeLeft == 2 & flagForPreventingRecallingofPlayerPrefs == 0)
        {
            SwipeGuide();      ///ensures name is assignes only once
        }
        
        
        ///sound
        ManageTheAudio.instance.Play("button", 0f);

        PlayerPrefs.SetInt("diskState", 0);

        PlayerPrefs.SetInt("music1", Tempmusic1);
        PlayerPrefs.SetInt("music2", Tempmusic2);


        Application.Quit();
    }

    private void SwipeGuide()
    {
       
        PlayerPrefs.SetInt("SwipeLeft", TempSwipeLeft);
    }

    void OnApplicationQuit()                 //////////this helps see it in unity app that when we want to call quitGame this has to be done
    {
        if (TempKeyNoChange == 1)
        {
            PlayerPrefs.SetInt("Key", TempKey);
        }

        if (TempSwipeLeft == 2 & flagForPreventingRecallingofPlayerPrefs == 0)
        {
            SwipeGuide();      ///ensures name is assignes only once
        }

        /////////////////////////////////////////////////////////////////////////
        PlayerPrefs.SetInt("music1", Tempmusic1);
        PlayerPrefs.SetInt("music2", Tempmusic2);

        if (PointsManager.instance.scoreInt > HighScoreC)
        {
            HighScoreC = PointsManager.instance.scoreInt;

        }
        NoOfDiamondsC += PointsManager.instance.NoOfDiamonds;
        PlayerPrefs.SetInt("HighScoreComp", HighScoreC);
        PlayerPrefs.SetInt("diamondsNOComp", NoOfDiamondsC);

        PlayerPrefs.SetInt("diskState", 0);
        //Debug.Log("Application ending after " + Time.time + " seconds");
    }
    void OnApplicationPause()                 //////////this helps see it in unity app that when we want to call quitGame this has to be done
    {
        if (TempKeyNoChange == 1)
        {
            PlayerPrefs.SetInt("Key", TempKey);
        }

        if (TempSwipeLeft == 2 & flagForPreventingRecallingofPlayerPrefs == 0)
        {
            SwipeGuide();      ///ensures name is assignes only once
        }

        /////////////////////////////////////////////////////////////////////////
        PlayerPrefs.SetInt("music1", Tempmusic1);
        PlayerPrefs.SetInt("music2", Tempmusic2);

        if (PointsManager.instance.scoreInt > HighScoreC)
        {
            HighScoreC = PointsManager.instance.scoreInt;

        }
        NoOfDiamondsC += PointsManager.instance.NoOfDiamonds;
        PlayerPrefs.SetInt("HighScoreComp", HighScoreC);
        PlayerPrefs.SetInt("diamondsNOComp", NoOfDiamondsC);

        PlayerPrefs.SetInt("diskState", 0);
        //Debug.Log("Application ending after " + Time.time + " seconds");
    }

    public void GoToMainMenu()
    {
        Resume1();       ///// this is to ensure that bridge stop destroying after gameover panel is displayed and someone intentionally left at that panel for long.

        ManageTheAudio.instance.Play("button", 0f);

        PlayerPrefs.SetInt("HighScoreComp", HighScoreC);
        PlayerPrefs.SetInt("diamondsNOComp", NoOfDiamondsC);
        PlayerPrefs.SetInt("diskState",0);

        PlayerPrefs.SetInt("music1", Tempmusic1);
        PlayerPrefs.SetInt("music2", Tempmusic2);
        if (TempKeyNoChange == 1)
        {
            PlayerPrefs.SetInt("Key", TempKey);
        }

        if (TempSwipeLeft == 2 & flagForPreventingRecallingofPlayerPrefs == 0)
        {
            SwipeGuide();      ///ensures name is assignes only once
        }

        SceneManager.LoadScene(0);
        
    }




    public void ThemeVol0()
    {
        ///sound
        ManageTheAudio.instance.Play("button", 0f);


        Tempmusic1 = 0;
        ManageTheAudio.instance.ThemeVol0();
        GameObject musicOff = MainMenuUp.transform.GetChild(15).gameObject;
        musicOff.SetActive(true);
        GameObject musicOn = MainMenuUp.transform.GetChild(18).gameObject;
        musicOn.SetActive(false);
    }
    public void ThemeVol1()
    {
        ///sound
        ManageTheAudio.instance.Play("button", 0f);

        Tempmusic1 = 1;
        ManageTheAudio.instance.ThemeVol1();
        GameObject musicOff = MainMenuUp.transform.GetChild(15).gameObject;
        musicOff.SetActive(false);
        GameObject musicOn = MainMenuUp.transform.GetChild(18).gameObject;
        musicOn.SetActive(true);
    }

    public void soundVol0()
    {
        ///sound
        ManageTheAudio.instance.Play("button", 0f);


        Tempmusic2 = 0;
        ManageTheAudio.instance.soundVo0();
        GameObject musicOff = MainMenuUp.transform.GetChild(16).gameObject;
        musicOff.SetActive(true);
        GameObject musicOn = MainMenuUp.transform.GetChild(19).gameObject;
        musicOn.SetActive(false);

        coinsPrefab.GetComponent<AudioSource>().volume = 0f;

        sound1.volume = 0f;
        sound2.volume = 0f;
        
    }
    public void soundVol1()
    {
        ///sound
        ManageTheAudio.instance.Play("button", 0f);

        Tempmusic2 = 1;
        ManageTheAudio.instance.soundVo1();
        GameObject musicOff = MainMenuUp.transform.GetChild(16).gameObject;
        musicOff.SetActive(false);
        GameObject musicOn = MainMenuUp.transform.GetChild(19).gameObject;
        musicOn.SetActive(true);

        coinsPrefab.GetComponent<AudioSource>().volume = 0.008f;

        sound1.volume = .8f;
        sound2.volume = 1f;
    }

    

}
