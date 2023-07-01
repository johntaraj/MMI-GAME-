using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LogicScript : MonoBehaviour
{
    public int playerlives = 5;
    public int numene = 9;
    public Text livesText;
    public GameObject gameOverScreen;
    public GameObject finishScreen;
    public GameObject livesScreen;

    void Start()
    {
        // This will display "Lives: 5" at the start
        livesText.text = playerlives.ToString();
    }

    public void sub_lives(int scoreToAdd)
    {
        playerlives = playerlives - scoreToAdd;
        livesText.text = playerlives.ToString();
        if (playerlives <= 0 && numene!=0)
        {
            gameOverScreen.SetActive(true);
            livesScreen.SetActive(false);
            Time.timeScale = 0;
        }
    }
    public void deadenemy(int scoreToAdd)
    {
        numene = numene - scoreToAdd;
        if (playerlives >= 0 && numene <= 0)
        {
            finishScreen.SetActive(true);
            livesScreen.SetActive(false);
            Time.timeScale = 0;
        }
    }

    public void restartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1;
    }
}