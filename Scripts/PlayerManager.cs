using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerManager : MonoBehaviour
{
    public static bool gameOver = false;
    public GameObject gameOverPanel;

    public static bool isGameStarted;

    public static int numberOfCoins;
    [SerializeField] private TMP_Text Score;

    [SerializeField] public Button QuitButton;
    [SerializeField] public Button StartButton;
    void MyStart()
    {
        isGameStarted = true;
        StartButton.gameObject.SetActive(false);
        Score.gameObject.SetActive(true);
    }
    // Start is called before the first frame update
    void Start()
    {
        gameOver = false;
        Time.timeScale = 1;
        isGameStarted = false;
        numberOfCoins = 0;
    }

    // Update is called once per frame
    void Update()
    {
        QuitButton.onClick.AddListener(Application.Quit) ;

        StartButton.onClick.AddListener(MyStart);

        Score.text ="Score : "+ (numberOfCoins *10 ).ToString();
        Score.gameObject.SetActive(true);
        if(gameOver)
        {
            Time.timeScale = 0;
            gameOverPanel.SetActive(true);
            QuitButton.gameObject.SetActive(false);

        }
    }
}
