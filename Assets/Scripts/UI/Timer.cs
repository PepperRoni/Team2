using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Timer : MonoBehaviour
{
    public float timer;
    public TextMeshProUGUI timerDisplay;
    public float highScore;
    public TextMeshProUGUI highScoreDisplay;
    public float bestTime = 600;
    public bool timerRunning;


    private void Start()
    {
        timerRunning = true;
        highScoreDisplay.text = PlayerPrefs.GetFloat("HighScore", highScore).ToString();
    }

    void Update()
    {
        if(timerRunning)
        {
            timer += Time.deltaTime;
            DisplayTimer(timer);
        }
        
        if(Input.GetKeyDown(KeyCode.G))
        {
            StopTimer();
        }
    }

    void DisplayTimer(float time)
    {
        timerDisplay.text = string.Format("{0:0.0}", time);
    }

    public void StopTimer()
    {
        timerRunning = false;
        
        if (timer < highScore)
        {
            highScore = timer;
            PlayerPrefs.SetFloat("HighScore", Mathf.Round(timer));
            highScoreDisplay.text = highScore.ToString();
        }
    }
}
