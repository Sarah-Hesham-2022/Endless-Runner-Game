using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void LoadScene(string Scene)
    {
        SceneManager.LoadScene(Scene);
    }
    public void PlayGame()
    {
        SceneManager.LoadScene("Level");
    }
    public void QuitGame()
    {
        Application.Quit(); 
    }
}
