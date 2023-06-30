using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectScript : MonoBehaviour
{
    public int project_volocity;
    public float timeTilDeath=10f; //was 4
    private float timer=0;
    public LogicScript logic;
    // Start is called before the first frame update
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
        project_volocity = -10; // test test test
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
        logic.deadenemy(1);
        Destroy(gameObject);
    }
}
