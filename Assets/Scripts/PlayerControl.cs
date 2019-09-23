using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerControl : MonoBehaviour
{
    public static int score;
    public Text scoreText;
    public static int minutes;
    public static float seconds;
    public Text timerText;
    public static int life = 100;
    public Text lifeText;
    public GameObject gameOverText;

    void Start()
    {
        UpdateTimer();
        timerText.text = "Time: ";
        scoreText.text = "Score: ";
        lifeText.text = "Life: ";
        gameOverText.SetActive(false);
    }

    void FixedUpdate()
    {
        seconds += Time.deltaTime;
        
        if (seconds > 59)
        {
            minutes++;
            seconds = 0;
        }
            UpdateTimer();
    }

    void UpdateTimer()
    {
        if (PlayerControl.life > 0)
        {
            timerText.text = "Time: " + Mathf.RoundToInt(minutes) + ":" + Mathf.RoundToInt(seconds);
        }
        else
        {
            timerText.text = "Time: ";
        }
    }

    void Update()
    {
        scoreText.text = "Score: " + score;
        lifeText.text = "Life: " +  life;

        if(life == 0)
        {
            gameOverText.SetActive(true);
        }
    }

}
