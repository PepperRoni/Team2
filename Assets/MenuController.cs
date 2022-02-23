using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    [SerializeField] GameObject highScoreMenu;
    public void OnStartButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void OnMainMenuButton()
    {
        SceneManager.LoadScene(0);
    }
    public void OnHighScoreButton()
    {
        highScoreMenu.SetActive(true);
    }
    public void OnBackHighScore()
    {
        highScoreMenu.SetActive(false);
    }
}