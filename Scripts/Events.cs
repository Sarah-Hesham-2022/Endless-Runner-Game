using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Events : MonoBehaviour
{
    public GameObject PausePanel;
    public static bool GameIsPaused;
   public void ReplayGame()
    {
        SceneManager.LoadScene("Level"); 
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void PauseGame()
    {
        FindObjectOfType<AudioManager>().PauseSound("MainTheme");
        FindObjectOfType<AudioManager>().PlaySound("Beat");
        PausePanel.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }
    public void Resume()
    {

        FindObjectOfType<AudioManager>().StopSound("Beat");
        FindObjectOfType<AudioManager>().PlaySound("MainTheme");
        PausePanel.SetActive(false);
        GameIsPaused = false;
        Time.timeScale = 1.0f;
    }
}
