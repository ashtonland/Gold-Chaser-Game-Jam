using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class goldManager : MonoBehaviour
{
    public Transform behind;
    public bool isPlayer1;
    public static bool oneDead;
    public static bool deadInitia;
    public static bool twoPlayer;

    public int currGold;
    public static int highScore;

    public Text GoldDisplay;
    public Text highScoreDisplay;

    //p2 management
    public Text p2GoldDisplay;
    public Text p2highScoreDisplay;
    public int p2currGold;
    public static int p2highScore;
    public GameObject p2Text;
    public GameObject Player2;
    public GameObject player1;

    public Animator anim;
    public Animator cam;
    public GameObject coinEffect;

    public GameObject overscreen;
    public GameObject startscreen;

    void Start()
    {
        if (isPlayer1)
        {
            deadInitia = false;
            oneDead = false;
            overscreen.SetActive(false);
            currGold = 0;
            p2currGold = 0;
            startscreen.SetActive(true);
            Time.timeScale = 0.01f;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isPlayer1)
        {
            GoldDisplay.text = "Gold: " + currGold;

            if (currGold >= highScore)
            {
                highScore = currGold;
                if (highScore == 0)
                {
                    highScoreDisplay.text = "High Score: " + highScore;
                }
                else
                {
                    highScoreDisplay.text = "High Score: " + highScore + " (NEW)";
                }
            }
            else
            {
                highScoreDisplay.text = "High Score: " + highScore;
            }
        }
        else
        {
            p2GoldDisplay.text = "Gold: " + p2currGold;

            if (p2currGold >= p2highScore)
            {
                p2highScore = p2currGold;
                if (p2highScore == 0)
                {
                    p2highScoreDisplay.text = "High Score: " + p2highScore;
                }
                else
                {
                    p2highScoreDisplay.text = "High Score: " + p2highScore + " (NEW)";
                }
            }
            else
            {
                p2highScoreDisplay.text = "High Score: " + p2highScore;
            }
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "gold")
        {
            if (isPlayer1)
            {
                currGold += 10;
            }
            else
            {
                p2currGold += 10;
            }
            //anim.SetBool("Open", false);
            Instantiate(coinEffect, collision.transform.position, Quaternion.identity);
            Destroy(collision.gameObject);
            Time.timeScale = 1;
            StartCoroutine(camShake(0.5f));
        }

        if(collision.tag == "dead")
        {

            if (twoPlayer)
            {
                if (!oneDead && !deadInitia)
                {
                    oneDead = true;
                    gameObject.transform.position = new Vector3(behind.position.x, behind.position.y, 0);
                    StartCoroutine(deadCamShake(0.5f));
                }
                else
                {
                    overscreen.SetActive(true);
                    Time.timeScale = 0.05f;
                }
            }
            else
            {
                overscreen.SetActive(true);
                Time.timeScale = 0.05f;
            }
        }
    }
    IEnumerator camShake(float shakeTime)
    {
        cam.SetBool("Shake", true);
        yield return new WaitForSeconds(shakeTime);
        cam.SetBool("Shake", false);

        yield break;
    }

    IEnumerator deadCamShake(float shakeTime)
    {
        cam.SetBool("Shake", true);
        yield return new WaitForSeconds(shakeTime);
        cam.SetBool("Shake", false);
        deadInitia = true;
        Destroy(gameObject);
        yield break;
    }

    public void Restart()
    {
        SceneManager.LoadScene(0);
    }

    public void StartGame()
    {
        twoPlayer = false;
        startscreen.SetActive(false);
        Time.timeScale = 1;

        player1.SetActive(true);
        p2Text.SetActive(false);
        Player2.SetActive(false);
    }

    public void StartMultiplayer()
    {
        twoPlayer = true;
        startscreen.SetActive(false);
        Time.timeScale = 1;

        player1.SetActive(true);
        p2Text.SetActive(true);
        Player2.SetActive(true);
    }
}
