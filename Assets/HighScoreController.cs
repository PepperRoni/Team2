using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class HighScoreController : MonoBehaviour
{
    public TextMeshProUGUI levelName;
    public float highScore;

    private void Start()
    {
        int sceneCount = SceneManager.sceneCountInBuildSettings;
        string[] scenes = new string[sceneCount];

        for (int i = 1; i < sceneCount - 1; i++)
        {
            
            scenes[i] = System.IO.Path.GetFileNameWithoutExtension(SceneUtility.GetScenePathByBuildIndex(i));
            highScore = PlayerPrefs.GetFloat(scenes[i]);
            levelName.text = scenes[i] + ": " + highScore.ToString("0.00");
            Instantiate(levelName, transform);
            Debug.Log(scenes[i]);   
        }
    }
}
