using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaScript : MonoBehaviour
{
    public LogicScript logic;
    public MainScript main;

    // Start is called before the first frame update
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        logic.sub_lives(1);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (Mathf.Abs(collision.gameObject.transform.position.y) > 8)
        {
            logic.sub_lives(5);
        }
    }
}
