using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadingScript : MonoBehaviour
{
    [SerializeField] private Image uiFill;
    //public GameObject gameObject;
    public MainScript main;
    public float Spawnrate;
    public float timerProj;
    // Start is called before the first frame update
    void Start()
    {
        main = GameObject.FindGameObjectWithTag("Main").GetComponent<MainScript>();
        if (gameObject != null)
        {
            getValues(gameObject.name);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject != null)
        {
            getValues(gameObject.name);
        }
        if (timerProj < Spawnrate)
        {
            uiFill.fillAmount = timerProj / Spawnrate;
        }
        else
        {
            uiFill.fillAmount = 1;
        }
    }

    void getValues(string name)
    {
        if (name == "Special")
        {
            Spawnrate = main.Spawnrate;
            timerProj = main.timerProj;
        }
        else if (name == "Shield")
        {
            Spawnrate = main.Spawnrate * 5;
            timerProj = main.timerDef;
        }
        else
        {
            Spawnrate = 1;
            timerProj = 0;
        }
    }
}
