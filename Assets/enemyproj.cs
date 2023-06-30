using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyproj : MonoBehaviour
{
    public int project_volocity;
    public float timeTilDeath = 10;
    private float timer = 0;
    public LogicScript logic;
    public MainScript main;
    // Start is called before the first frame update
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
        main = GameObject.FindGameObjectWithTag("Main").GetComponent<MainScript>();
    }

    // Update is called once per frame
    void Update()
    {
        timer = timer + Time.deltaTime;
        if (timer > timeTilDeath)
        {
            Destroy(gameObject);
        }
        transform.position = transform.position + Vector3.left * project_volocity * Time.deltaTime;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (main.shield == false)
        {
            logic.sub_lives(1);
        }
        Destroy(gameObject);
    }
}