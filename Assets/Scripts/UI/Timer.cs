using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class Timer : MonoBehaviour
{
    public TextMeshProUGUI timerDisplay;
    public TextMeshProUGUI highScoreDisplay;
    [SerializeField] GameObject highScoreGO;

    private float currentScore;
    private bool timerRunning;

    private void Start()
    {
        if (!PlayerPrefs.HasKey(SceneManager.GetActiveScene().name))
        {
            PlayerPrefs.SetFloat(SceneManager.GetActiveScene().name, 100000f);
            highScoreGO.SetActive(false);
        }
        else
        {
            highScoreGO.SetActive(true);
            highScoreDisplay.text = PlayerPrefs.GetFloat(SceneManager.GetActiveScene().name).ToString("0.00");
        }

        timerRunning = true;
    }

    void Update()
    {
        if(timerRunning)
        {
            currentScore += Time.deltaTime;
            DisplayTimer(currentScore);
        }
        
        //TODO: Switch this to when player dies instead
        if(Input.GetKeyDown(KeyCode.G))
        {
            StopTimer();
        }
    }

    void DisplayTimer(float time)
    {
        timerDisplay.text = string.Format("{0:0.00}", time);
    }

    public void StopTimer()
    {
        timerRunning = false;

        if (currentScore < PlayerPrefs.GetFloat(SceneManager.GetActiveScene().name))
        {        
            highScoreGO.SetActive(true);
            PlayerPrefs.SetFloat("HighScore", currentScore);
            highScoreDisplay.text = currentScore.ToString("0.00");
            PlayerPrefs.SetFloat(SceneManager.GetActiveScene().name, currentScore);        
        }
    }
}
