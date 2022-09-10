using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;


public class GameManage : MonoBehaviour
{
    public PlayerMovement abc;
    Vector3 scaleChangeVector = new Vector3(0.01f, 0.01f, 0.01f);
    bool isScaleDown = true;
    bool speedRunTimeBool = true;

    public TMP_Text lifeCountText1;
    public TMP_Text timeCountText;
    public TMP_Text Text5;

    static int lifeCountTry1;
    static int lifeCountTry2;
    static int lifeCountTry3;
    static int lifeCountTry4;
    static int lifeCountTry5;
    static int lifeCountTryTotal;
    static int levelPlaying = 0;
    int timeCount = 20;

    static int audioNumber = 0;

    // Start is called before the first frame update
    void Start()
    {
        // PlayerMovement scriptini �rnekleyerek i�indeki component'lere ula�t�m
        abc = GetComponent<PlayerMovement>();

        if (audioNumber == 0)
        {
            SoundManage.PlayAudio("win");
        }
        else if (audioNumber == 1)
        {
            SoundManage.PlayAudio("dead");
        }



    }

    // Update is called once per frame
    void Update()
    {

        switch (levelPlaying) 
        {
            case 1:

                lifeCountText1.text = "DeathCount: " + lifeCountTry1;
                timeCountText.text = "Countdown: " + timeCount;

                if (timeCount == 0)
                {
                    audioNumber = 1;
                    lifeCountTry1++;
                    SceneManager.LoadScene("Level 1");
                }
                else if (timeCount != 0 && speedRunTimeBool)
                {
                    speedRunTimeBool = false;
                    timeCount--;
                    StartCoroutine(speedRunTime());
                }

                break;

            case 2:

                lifeCountText1.text = "DeathCount: " + lifeCountTry2;
                timeCountText.text = "Countdown: " + timeCount;

                if (timeCount == 0)
                {
                    audioNumber = 1;
                    lifeCountTry2++;
                    SceneManager.LoadScene("Level 2");
                }
                else if (timeCount != 0 && speedRunTimeBool)
                {
                    speedRunTimeBool = false;
                    timeCount--;
                    StartCoroutine(speedRunTime());
                }

                break;

            case 3:

                lifeCountText1.text = "DeathCount: " + lifeCountTry3;
                timeCountText.text = "Countdown: " + timeCount;

                if (timeCount == 0)
                {
                    audioNumber = 1;
                    lifeCountTry3++;
                    SceneManager.LoadScene("Level 3");
                }
                else if (timeCount != 0 && speedRunTimeBool)
                {
                    audioNumber = 1;
                    speedRunTimeBool = false;
                    timeCount--;
                    StartCoroutine(speedRunTime());
                }

                break;

            case 4:

                lifeCountText1.text = "DeathCount: " + lifeCountTry4;
                timeCountText.text = "Countdown: " + timeCount;

                if (timeCount == 0)
                {
                    audioNumber = 1;
                    lifeCountTry4++;
                    SceneManager.LoadScene("Level 4");
                }
                else if (timeCount != 0 && speedRunTimeBool)
                {
                    speedRunTimeBool = false;
                    timeCount--;
                    StartCoroutine(speedRunTime());
                }

                break;

            case 5:

                lifeCountText1.text = "DeathCount: " + lifeCountTry5;
                timeCountText.text = "Countdown: " + timeCount;

                if (lifeCountTry5 >= 3) Text5.text = "Ok, this map is broken. But try to use elevator, or something like that.";

                if (timeCount == 0)
                {
                    audioNumber = 1;
                    lifeCountTry5++;
                    SceneManager.LoadScene("Level 5");
                }
                else if (timeCount != 0 && speedRunTimeBool)
                {
                    speedRunTimeBool = false;
                    timeCount--;
                    StartCoroutine(speedRunTime());
                }

                break;

            case 6:
                lifeCountTryTotal = lifeCountTry1 + lifeCountTry2 + lifeCountTry3 + lifeCountTry4 + lifeCountTry5;
                lifeCountText1.text = "Total DeathCount: " + lifeCountTryTotal;

                if(lifeCountTryTotal == 0) 
                {
                    timeCountText.text = "You're fast as fucc boi... Big W";
                }
                else if(lifeCountTryTotal > 0 && lifeCountTryTotal < 3) 
                {
                    timeCountText.text = "Solid performance... but don't forget: 'Practice makes perfect'";
                }
                else if (lifeCountTryTotal >= 3 && lifeCountTryTotal < 7)
                {
                    timeCountText.text = "You have little bit of talent... ha?";
                }
                else if (lifeCountTryTotal >= 7 && lifeCountTryTotal < 11)
                {
                    timeCountText.text = "I'm pretty sure that this isn't your best... is it?";
                }
                else if (lifeCountTryTotal >= 11 && lifeCountTryTotal < 16)
                {
                    timeCountText.text = "Should I call you newbie or noobie?";
                }
                else if (lifeCountTryTotal >= 16 && lifeCountTryTotal < 21)
                {
                    timeCountText.text = "3 year old tester kid did better than you, LOL";
                }
                else if (lifeCountTryTotal >= 16 && lifeCountTryTotal < 21)
                {
                    timeCountText.text = "Pls delete... I won't tell this anyone. What a shame...";
                }

                break;

        }

    }



    private void OnCollisionEnter2D(Collision2D collision)
    {

        switch (collision.gameObject.name) 
        {
            case "DeadgeT":
                audioNumber = 1;
                SceneManager.LoadScene("Tutorial");
                break;

            case "Deadge1":
                audioNumber = 1;
                SceneManager.LoadScene("Level 1");
                lifeCountTry1++;
                break;

            case "Deadge2":
                audioNumber = 1;
                SceneManager.LoadScene("Level 2");
                lifeCountTry2++;
                break;

            case "Deadge3":
                audioNumber = 1;
                SceneManager.LoadScene("Level 3");
                lifeCountTry3++;
                break;

            case "Deadge4":
                audioNumber = 1;
                SceneManager.LoadScene("Level 4");
                lifeCountTry4++;
                break;

            case "Deadge5":
                audioNumber = 1;
                SceneManager.LoadScene("Level 5");
                lifeCountTry5++;
                break;

            case "JumpDown":
                abc.jump--;
                abc.isGrounded = true;
                break;

            case "JumpUp":
                abc.jump++;
                abc.isGrounded = true;
                break;

            case "ScaleDown":
                if (transform.localScale.x > 0.019 && transform.localScale.y > 0.019 && transform.localScale.z > 0.019 && isScaleDown)
                {
                    StartCoroutine(timer());
                }
                abc.isGrounded = true;
                break;

            case "ScaleUp":
                transform.localScale = transform.localScale + scaleChangeVector;
                abc.isGrounded = true;
                break;

            case "SpeedDown":
                abc.moveSpeed--;
                abc.isGrounded = true;
                break;

            case "SpeedUp":
                abc.moveSpeed++;
                abc.isGrounded = true;
                break;

            case "SurfaceBrokenBox":
                abc.isGrounded = true;
                break;

            case "GameEnd1":
                audioNumber = 0;
                levelPlaying = 2;
                SceneManager.LoadScene("Level 2");
                break;

            case "GameEnd2":
                audioNumber = 0;
                levelPlaying = 3;
                SceneManager.LoadScene("Level 3");
                break;

            case "GameEnd3":
                audioNumber = 0;
                levelPlaying = 4;
                SceneManager.LoadScene("Level 4");
                break;

            case "GameEnd4":
                audioNumber = 0;
                levelPlaying = 5;
                SceneManager.LoadScene("Level 5");
                break;

            case "GameEnd5":
                audioNumber = 0;
                levelPlaying = 6;
                SceneManager.LoadScene("Final");
                break;

            case "GameEndTutorial":
                audioNumber = 0;
                levelPlaying = 1;
                SceneManager.LoadScene("Level 1");
                break;


        }

        
    }

    IEnumerator timer()
    {
        isScaleDown = false;
        transform.localScale = transform.localScale - scaleChangeVector;
        yield return new WaitForSeconds(0.1f);
        isScaleDown = true;
    }

    IEnumerator speedRunTime()
    {
        yield return new WaitForSeconds(1);
        speedRunTimeBool = true;
    }
    
    public void startGame() 
    {
        SceneManager.LoadScene("Tutorial");
    }


    public void restartGame()
    {
        levelPlaying = 1;
        lifeCountTry1 = 0;
        lifeCountTry2 = 0;
        lifeCountTry3 = 0;
        lifeCountTry4 = 0;
        lifeCountTry5 = 0;

        SceneManager.LoadScene("Level 1");
    }


}
