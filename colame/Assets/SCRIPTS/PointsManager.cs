using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointsManager : MonoBehaviour
{
    public int DifferenceINLevelVal;

    public int findLevel;
    public int phaseNO = 0;
    //public static int ScreenWidth=Screen.width;
    //public static int ScreenHeight = Screen.height;


    public float GameIncA, GameIncB, GameDownA, GameDownB, PowerUpLevelChangeSoundA, PowerUpLevelChangeSoundB, GameOverDramaticSoundA, GameOverDramaticSoundB;


    public int freezetheBall = 0;

    //public Animation anim;                              ///////////////////////////increase speed of animation
    public GameObject LevelDisplay;
    public Text LevelNoTextDisplay;

    public int levelchangeDelay;
    int callAgain = 0;
    int diamondCount = 0;
    int repeatNO = 0;
    public int MainMenuShowOnce;
    public int DiskState = 1;

    bool StartClicked;
    ///////////////////////////////
    public float t;
    public Image rEDWARNING;

    public Image maskI;
    public float MaskLength;
    /////////////////////////////////////////////////////////////////
    public Text ScoreText;
    public Text DiamondText;

    
    ///////////////////////////////////////////////////////////////

    public int FINISHsTATES = 0;

    ////////////////////////////////////////////store location of spawning point////////////////
    public Vector3 LocationOfSpawningBridge;

    public float MinSpreadx, MaxSpreadx, MinSpready, MaxSpready, MinSpreadz, MaxSpreadz;

    /////////////////////////////////////////////////coin istantiated///////////////////////
    GameObject coinInstantiated;
    public GameObject coinPrefab;

    ////////////////////////////////////////////////checking variable change/////////////////////////
    float slot1, slot2;
    int SpeedIncreasingStatus = 0;

    /////////////////////////////////////////////////////////////////////////////////////////////////
    public int LevelI = 0, LevelF;
    public int level=0;

    public int StopBall = 0;/////////////////////to stop ball   Cutoff speed was causing problem as now speed - cutoff speed can be negative

    public float MinSpeed, MaxSpeed,JumpSpeed,rateToReachTopSpeed;

    public int gamestate = -1;
    public float score=0;
    public int scoreInt;
    public int HighScore = 0;     /////this has to be attached to some memory
    public int NoOfDiamonds;
    public int NOOfKeys;
    public int NoOfEggs;
    public float speed;
    public float x=0f;
    public int highestScore;
    public float rateToCallIncreasespeed;
    public float rateOfAngleChange;
    public int collision = 0;

    public static PointsManager instance;
    private void Awake()
    {
        freezetheBall = 0;

        if (instance == null)
        {
            instance = this;
        }
        slot1 = MaxSpeed;
        scoreInt = 0;
        NoOfDiamonds = 0;
        ScoreText.text = scoreInt.ToString();   //////////////////////////////increase score
        DiamondText.text = NoOfDiamonds.ToString();
    }
    public void increaseDiamonds()
    {
        ///lets add sound
        Invoke("PointsGettingsound", GameIncB);
        //PointsGettingsound();

        diamondCount = NoOfDiamonds;
        NoOfDiamonds += 10;
        if (repeatNO == 0)
        {
            repeatNO = 1;
            StartCoroutine("IncreaseDiamondsSTEPWise");
        }
    }

    private void PointsGettingsound()
    {
        ManageTheAudio.instance.Play("Game+", GameIncA);
    }

    IEnumerator IncreaseDiamondsSTEPWise()
    {
        yield return null;
        while (DiamondText.text!=NoOfDiamonds.ToString())
        {
            diamondCount += 1;
            //ScoreText.text = scoreInt.ToString();
            DiamondText.text = diamondCount.ToString();
            yield return new WaitForSeconds(.05f);
            //    ScoreText.text = scoreInt.ToString();
            //    DiamondText.text = NoOfDiamonds.ToString();
        }
        repeatNO = 0;
        StopCoroutine("IncreaseDiamondsSTEPWise");
    }
    //public void increaseDiamonds()
    //{
    //    if (repeatNO == 0)
    //    {
    //        repeatNO = 1;
    //        diamondCount = 10;
    //        InvokeRepeating("increaseNOOfDiamondsSlowly", .001f, .001f);
    //    }
    //    if (repeatNO == 1)
    //    {
    //        repeatNO = 2;
    //        callAgain = 1;
    //        //called twice
    //    }
    //    if (repeatNO == 2)
    //    {
    //        callAgain = 1;
    //    }
        
    //    //NoOfDiamonds += 10;
        
    //}
    //void increaseNOOfDiamondsSlowly()
    //{
    //    NoOfDiamonds += 1;
    //    ScoreText.text = scoreInt.ToString();
    //    DiamondText.text = NoOfDiamonds.ToString();
    //    diamondCount -= 1;
    //    if (diamondCount <= 0)
    //    {
    //        diamondCount = 10;
    //        repeatNO = 0;
    //        CancelInvoke("increaseNOOfDiamondsSlowly");
    //        if (callAgain == 1)
    //        {
    //            callAgain = 0;
    //            InvokeRepeating("increaseNOOfDiamondsSlowly", .001f, .001f);
    //        }
            
    //    }

    //}
    
    public void CheckStartClicked()
    {
        gamestate = 0;     ///////experiment
        StartClicked = true;
    }
    ////////////////////////////////////////////////coin istantiation/////////////////////////
    public void Instantiatecoin(Vector3 crystalpos)
    {
        StartCoroutine("hello", crystalpos);
        
       
        Debug.Log("COIN CREATED");
    }

    IEnumerator hello(Vector3 c)
    {
        int firstcoin = 0;
        yield return null;
        int l = 0;
        while (l < 10)
        {
            
            l = l + 1;
            //coinInstantiated = Instantiate(coinPrefab, c, Quaternion.identity);
            coinInstantiated = Instantiate(coinPrefab, new Vector3(c.x,c.y,c.z+.5f), Quaternion.Euler(new Vector3(Random.Range(MinSpreadx, MaxSpreadx), Random.Range(MinSpready, MaxSpready), Random.Range(MinSpreadz, MaxSpreadz)  )));

            if (firstcoin == 0)
            {
                ////add audio
                coinInstantiated.GetComponent<FLAY>().CrystalMarkedWithSound = 1;
               AudioSource a= coinInstantiated.GetComponent<AudioSource>();
                a.time = 1f;
                if (UImanager.instance.Tempmusic2 == 1)
                {
                    a.volume = 10f;
                }
                
                a.Play();
                firstcoin = 1;
            }

            //yield return new WaitForEndOfFrame();
            yield return new WaitForSeconds(.02f);
        }
    }

    /////////////////////////////////////////////////////////////////////////////////////////
    

    // Start is called before the first frame update
    void Start()
    {
        rateToCallIncreasespeed = .1f;

        //if (ScreenWidth == Screen.width || ScreenHeight == Screen.height)
        //{
        //    ScreenHeight = Screen.width - (640 * 2);
        //    ScreenWidth = Screen.height - (360 * 2);
        //    Screen.SetResolution(ScreenWidth, ScreenHeight, true);
        //}

        //$ Debug.Log(((5 / 8) * (Mathf.Pow(16.1f, 2.1f))) + 160.1);
    }
   
    // Update is called once per frame
    void Update()
    {
        if (gamestate == 20)    //////////////////aaaaaaaaaaaa
        {
            ///
        }
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //maskI.rectTransform.sizeDelta = new Vector2(maskI.rectTransform.sizeDelta.x, (1)*MaskLength);    BELOW METHOD IS BEAUTIFUL

        if (speed < MinSpeed)
        {
            float c = 225 - ((speed / MinSpeed) * 40);
            maskI.rectTransform.sizeDelta = new Vector2(maskI.rectTransform.sizeDelta.x, c);

        }
        if (speed >= MinSpeed && speed < 250)             ////////////////taking 250 instead of maxspeed   gives idea on absolute value  so good playing experience $ no change
        {
            float d = 185 - (((speed - MinSpeed) / (250 - MinSpeed)) * 185);
            maskI.rectTransform.sizeDelta = new Vector2(maskI.rectTransform.sizeDelta.x, d);
            Debug.Log("is masking called;;;;;;;;;;;;;;;;;;;;");

        }

        ////////////////////////////////////////////////////////////////////////////////checking variable change that is max speed////////////
        //slot2 = MaxSpeed;
        //if (slot2 != slot1)
        //{
        //    if ((SpeedIncreasingStatus == 0) && (slot2 > slot1)&&(gamestate!=0&&gamestate!=10))  ////////////// HERE KEPT GAMESTATES IN OR BUT WAS AN ERROR
        //    {
        //        /////not invoke and that is where problem lies
        //        x = Mathf.Pow(((8.0f / 5.0f) * (speed - MinSpeed)), .5f);
        //        InvokeRepeating("IncreaseSpeed", 1f, rateToCallIncreasespeed);

        //        gamestate = 4;       //////since it is alternate solution so adjust in above update where to cance the invoke (why write same code twice)

        //        SpeedIncreasingStatus = 1;
        //    }
        //}                                 this was when speed was changing $

        ////////////////////////////////////////////////////////////////////////////////Control max speed//////////////////////////////////////
        //if (level==1|| level == 3 || level == 6 || level == 9)
        //{
        //    MaxSpeed = 250;
        //    JumpSpeed = 60;
        //}
        //else
        //{
        //    //MaxSpeed = 200; ///////$
        //    MaxSpeed = 250;
        //    JumpSpeed = 60;///////$
        //}                             $

        ///////////////////////////////////////////////////////////////////////////////////////////////LEVELS////////////////////////////////////////////
        ///showing level change animation
        findLevel = scoreInt % 6000;
        if (findLevel <= 2000)
        {
            phaseNO = 1;
            
        }
        else if (findLevel <= 4000)
        {
            phaseNO = 2;
           
        }
        else
        {
            phaseNO = 3;
            //DisplayLevelChange();
        }
       // DisplayLevelChange();
 
        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        if (speed <= 0 && gamestate != 0 && gamestate != 20)          /////////////////this is for end to correct the speed if any left to make it 0  //////////aaaaaaaaa
        {
            speed = 0;
            StopBall = 1;

            //// lets assign high score here only
            if (highestScore < scoreInt)
            {
                highestScore = scoreInt;
            }
        }
        if (gamestate == 4 && speed >= MaxSpeed)            ///this line is used for both m1  and m2 actually whole update is used so cheer no change to do here in both cases
        {


            CancelInvoke("IncreaseSpeed");

            SpeedIncreasingStatus = 0;

            gamestate = 2;   /////////////very important point we called the same condition and thus loop is completed  basically there are total 4 cases on collision and those 4 cases only repeat  this line is not necessary for method 2
        }                                                                                                                                                         //////MOST IMPORTANTLY THERE SHOULD BE ONLY 2 CASES        
                                                                                                                                                                  /////1 WHEN SPEED IS LESS THAN 200 AND THUS INVOKE IS NOT CANCELLED YET
                                                                                                                                                                  /////2 WHEN SPEED IS MORE THAN 200 AND THUS INVOKE IS CANCELLED


        if (gamestate == 0 && StartClicked == true)
        {
            StartClicked = false;
            gamestate = 1;
            InvokeRepeating("IncreaseSpeed", 1f, rateToCallIncreasespeed);

            SpeedIncreasingStatus = 1;
        }
        if (gamestate == 0 && PlayerPrefs.GetInt("diskState") == 1)
        {
            gamestate = 1;
            InvokeRepeating("IncreaseSpeed", 1f, rateToCallIncreasespeed);

            SpeedIncreasingStatus = 1;
        }
        if (gamestate == 1 && speed >= MaxSpeed)
        {
            gamestate = 2;
            CancelInvoke("IncreaseSpeed");
            SpeedIncreasingStatus = 0;
        }
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        if (scoreInt < (6000 + DifferenceINLevelVal))
        {
            level = 0;
            LevelF = 0;
        }
        else if (scoreInt < (12000 + DifferenceINLevelVal))
        {
            level = 1;
            LevelF = 1;
        }
        else if (scoreInt < (18000 + DifferenceINLevelVal))
        {
            level = 2;
            LevelF = 2;
        }
        else if (scoreInt < (24000 + DifferenceINLevelVal))
        {
            level = 3;
            LevelF = 3;
        }
        else if (scoreInt < (30000 + DifferenceINLevelVal))
        {
            level = 4;
            LevelF = 4;
        }
        else if (scoreInt < (36000 + DifferenceINLevelVal))
        {
            level = 5;
            LevelF = 5;
        }
        else
        {
            level = 6;
            LevelF = 6;
        }
        /////////////////////////////////////
        if (LevelI != LevelF)
        {
            LevelI = LevelF;
            StartCoroutine("FlyParallely");
            StartCoroutine("FlySoundInvokeLate");
            Invoke("DeactivateLeveDisplayLate", 5f);
            //DeactivateLeveDisplayLate();
        }
    }

    private void DeactivateLeveDisplayLate()
    {
        LevelDisplay.SetActive(false);
    }

    private void DisplayLevelChange()
    {
        if (scoreInt % (6000+DifferenceINLevelVal) == levelchangeDelay && scoreInt > 1000)
        {
            //LevelDisplay.SetActive(true);
            //LevelNoTextDisplay.text = level.ToString();
            ////anim = LevelDisplay.GetComponent<Animation>();                       these codes are to increase speed of animation when player speed in high
            //LevelDisplay.GetComponent<Animator>().Play("Fly");
            //foreach (AnimationState state in anim)
            //{
            //    state.speed = 0.001F;
            //}
            StartCoroutine("FlyParallely");
            StartCoroutine("FlySoundInvokeLate");
            //Invoke("FlySoundInvokeLate", PowerUpLevelChangeSoundB);
            //FlySoundInvokeLate();

        }
        if (scoreInt % (6000+DifferenceINLevelVal) == (levelchangeDelay + 100))
        {
            LevelDisplay.SetActive(false);
            // LevelDisplay.GetComponent<Animator>().Play("LevelChangeAnimation");
        }
    }
    IEnumerator FlyParallely()
    {
        LevelDisplay.SetActive(true);
        LevelNoTextDisplay.text = level.ToString();
        //anim = LevelDisplay.GetComponent<Animation>();                       these codes are to increase speed of animation when player speed in high
        LevelDisplay.GetComponent<Animator>().Play("Fly");
        yield return null;
        StopCoroutine("FlyParallely");

    }
    IEnumerator FlySoundInvokeLate()
    {
        ManageTheAudio.instance.Play("PowerUpLevelChangeSound", PowerUpLevelChangeSoundA);
        yield return null;
        StopCoroutine("FlySoundInvokeLate");

    }
    //private void FlySoundInvokeLate()
    //{
    //    ManageTheAudio.instance.Play("PowerUpLevelChangeSound", PowerUpLevelChangeSoundA);
    //}

    private void FixedUpdate()
    {
        if (gamestate != 0 && gamestate != 10&gamestate!=20)      ////////////aaaaaaaaaa
        {

            score = score + Time.deltaTime*(speed/10);
            scoreInt = Mathf.FloorToInt(score);
            // Debug.Log(scoreInt+ "  " +speed);

            ScoreText.text = scoreInt.ToString();   //////////////////////////////increase score
        }
        
    }

    void IncreaseSpeed()
    {
        ////as many times speed changes pitch of sound also changes//
        UImanager.instance.CheckSpeedForRollingBall();
        ///

        x = x + rateToReachTopSpeed;
        speed = (        (5.0f / 8.0f) * (Mathf.Pow(x, 2))    ) + MinSpeed;
        //Debug.Log(((5.0f / 8.0f) * (Mathf.Pow(x, 2))) + MinSpeed);
    }

    IEnumerator bLINKred()
    {
        rEDWARNING.gameObject.SetActive(true);
        yield return new WaitForSeconds(t);
        rEDWARNING.gameObject.SetActive(false);
        yield return new WaitForSeconds(t);
        rEDWARNING.gameObject.SetActive(true);
        yield return new WaitForSeconds(t);
        rEDWARNING.gameObject.SetActive(false);
        StopCoroutine("bLINKred");

    }
   public void OnWrongCollision()
    {
        UImanager.instance.sound1.Play();
        Invoke("GameDownSoundLate", GameDownB);
        //GameDownSoundLate();

        rateToCallIncreasespeed = .04f;   ///this will ensure first time accelaration  is slow and next time it is fast

        ////////////////////////////////////////////////////METHOD 1///////////////////////////////////////////////////////////////////////
        //if (gamestate == 2)
        //{
        //    ////  speed is already 200  and invoke repeat is cancelled
        //    //gamestate = 3;        THIS IS WRONG SINCE IT WILL NEVER STOP IT CHECKS TO STOP ONLY AT GAMESTATE 1&4
        //    gamestate = 1;
        //    speed = speed - 10f;
        //    x = Mathf.Pow(((8.0f / 5.0f) * (speed - 160)), .5f);
        //    InvokeRepeating("IncreaseSpeed", .1f, rateToIncreasespeed);
        //}
        //else if (gamestate == 1)
        //{
        //    ////speed has not reached 200 and the invokerepeat is not cancelled yet
        //    CancelInvoke("IncreaseSpeed");

        //    speed = speed - 10f;
        //    if (speed <= 160)
        //    {
        //        ////gameover
        //        gamestate = 10;
        //    }
        //    if (speed > 160)
        //    {
        //        gamestate = 4;                 //////IF SPEED GETS200 THEN AGAIN WILL BE INVOKE CANCELED
        //        x = Mathf.Pow(((8.0f / 5.0f) * (speed - 160)), .5f);
        //        InvokeRepeating("IncreaseSpeed", .1f, rateToIncreasespeed);
        //    }

        //}
        //else if (gamestate == 4)
        //{
        //    ///// we are in second phase that is now it is sure that speed increasing invoke is still being called so first cancel that   NO HERE ALSO IT CAN SPEED GO BEYOND
        //    CancelInvoke("IncreaseSpeed");
        //    ////// now we will decrease the speed remember decreasing speed first and then canelling the invoke may cause problem in calculation
        //    speed = speed - 10f;


        //    /////now we will check what is the speed and according to that we will decide what to do
        //    if (speed <= 160)
        //    {
        //        ///then the player lost the game we will pause the game and bring the loop back to where it all started that is
        //        gamestate = 10;        ////back to where it started   actually dont put here 0 otherwise on mouse click will start back
        //    }
        //    else if (speed < 200)
        //    {
        //        gamestate = 4;
        //        ////we will invoke the speed increasing function here we will later on specify time for earch 170,180,...etc but for now keep this
        //        x = Mathf.Pow(((8.0f / 5.0f) * (speed - 160)), .5f);
        //        InvokeRepeating("IncreaseSpeed", .1f, rateToIncreasespeed);

        //    }
        //}


        /////////////////////////////////////////////////////METOD 2///////////////////////////////////////////////////////////////////////
        if (speed < MaxSpeed)
        {
            ///means invoke is not cancelled yet
            CancelInvoke("IncreaseSpeed");



            speed = speed - JumpSpeed;
            ///sound part
            UImanager.instance.CheckSpeedForRollingBall();
            ///

            if (speed <= MinSpeed)
            {
                ////gameover
                rEDWARNING.gameObject.SetActive(true);
                Debug.Log("game is over");       ///it is checked only when any collision happens so even if cutoff speed is more than minspeed or the starting speed it will not finish untill there is any collision
                gamestate = 10; ////back to where it started   actually dont put here 0 otherwise on mouse click will start back

                StartCoroutine("SpeedToZero");

                Invoke("StartTheDynamicGameoverSoundLate", GameOverDramaticSoundB);
                //StartTheDynamicGameoverSoundLate();

                /////also ensure the sound

                SpeedIncreasingStatus = 0;

            }
            else if (speed > MinSpeed)
            {
                ////game is on
                StartCoroutine("bLINKred");
                x = Mathf.Pow(((8.0f / 5.0f) * (speed - MinSpeed)), .5f);
                InvokeRepeating("IncreaseSpeed", 5f, rateToCallIncreasespeed);   //$5-1

                gamestate = 4;   //////since it is alternate solution so adjust in above update where to cance the invoke (why write same code twice)

                SpeedIncreasingStatus = 1;
            }

        }
        else if (speed >= MaxSpeed)
        {
            /////means invoke is cancelled and speed is 200 so
            StartCoroutine("bLINKred");
            speed = speed - JumpSpeed;

            ///sound part
            UImanager.instance.CheckSpeedForRollingBall();
            ///

            x = Mathf.Pow(((8.0f / 5.0f) * (speed - MinSpeed)), .5f);
            InvokeRepeating("IncreaseSpeed", 5f, rateToCallIncreasespeed);    //$5-1

            gamestate = 4;       //////since it is alternate solution so adjust in above update where to cance the invoke (why write same code twice)

            SpeedIncreasingStatus = 1;
        }

    }

    private void StartTheDynamicGameoverSoundLate()
    {
        ManageTheAudio.instance.Play("GameOverDramaticSound", GameOverDramaticSoundA);
    }

    private void GameDownSoundLate()
    {
        ManageTheAudio.instance.Play("Game-", GameDownA);
    }



    IEnumerator SpeedToZero()
    {
        yield return new WaitForSeconds(.1f);
        while (speed > 0)
        {
           
            //speed = speed - .5f;                              //// value of decreament in one call
            speed = speed - .6f;

            ///sound part
            UImanager.instance.CheckSpeedForRollingBall();
            ///
            Debug.Log("speed to 0 coroutine is called");
            yield return new WaitForSeconds(.001f);           //////// how often is value decreased per second
        }
        speed = 0;
        freezetheBall = 1;
        StopCoroutine("SpeedToZero");
        

    }

    

}
