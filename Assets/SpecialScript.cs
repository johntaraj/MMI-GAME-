using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpecialScript : MonoBehaviour
{
    [SerializeField] private Image uiFill;

    public MainScript main;
    public float Spawnrate;
    public float timerProj;
    // Start is called before the first frame update
    void Start()
    {
        main = GameObject.FindGameObjectWithTag("Main").GetComponent<MainScript>();
        Spawnrate = main.Spawnrate;
        timerProj = main.timerProj;
    }

    // Update is called once per frame
    void Update()
    {
        Spawnrate = main.Spawnrate;
        timerProj = main.timerProj;
        if (timerProj < Spawnrate)
        {
            Debug.Log("Dans update");
            uiFill.fillAmount = timerProj / Spawnrate;
            Debug.Log(uiFill.fillAmount);
        }
        else
        {
            uiFill.fillAmount = 1;
        }
    }
}
