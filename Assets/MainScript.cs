using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainScript : MonoBehaviour
{
    public Rigidbody2D myRigidbody;
    public int flapstrength;
    public GameObject project;
    public float Spawnrate = 1;
    private float timerProj = 0;
    private float timerDef = 0;
    public bool playeraliv = true;
    public LogicScript logic;
    public GameObject Shield;
    public bool shield = false;
    // Start is called before the first frame update
    void Start()
    {
        flapstrength = 4;
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
    }

    // Update is called once per frame
    void Update()
    {
        timerDef = timerDef + Time.deltaTime;
        timerProj = timerProj + Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.Space) == true && playeraliv == true)
        {
            myRigidbody.velocity = Vector2.up * flapstrength;
        }

        if (Input.GetKeyDown(KeyCode.D) == true && playeraliv == true)
        {
            if (timerDef > Spawnrate*5)
            {
                Shield.SetActive(true);
                shield = true;
                timerDef = 0;
            }
        }
        if (shield == true && timerDef > 1)
        {
            Shield.SetActive(false);
            shield =false;
        }

        if (Input.GetKeyDown(KeyCode.A) == true && playeraliv == true)
        {
            if (timerProj > Spawnrate)
            {
                Instantiate(project, transform.position + Vector3.right/2*3 + Vector3.down / 2, transform.rotation); 
                timerProj = 0;
            }
        }
        if (logic.playerlives == 0)
        {
            playeraliv = false;
        }
    }
}

