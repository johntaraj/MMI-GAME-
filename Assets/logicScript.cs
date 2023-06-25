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

    public void sub_lives(int scoreToAdd)
    {
        playerlives = playerlives - scoreToAdd;
        livesText.text = "lives:" + playerlives.ToString();
        if (playerlives <= 0 && numene!=0)
        {
            gameOverScreen.SetActive(true);
        }
    }
    public void deadenemy(int scoreToAdd)
    {
        numene = numene - scoreToAdd;
        if (playerlives >= 0 && numene <= 0)
        {
            finishScreen.SetActive(true);
        }
    }
}