using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class enemy : MonoBehaviour
{
    public Rigidbody2D myRigidbody;
    [SerializeField] public int flapstrength;
    public GameObject project;
    [SerializeField] public float Spawnrate = 3;
    [SerializeField] private float timerProj = 10; //was 0
    public bool enemyliv = true;
    public LogicScript logic;
    public float deadZone;
    [SerializeField] public int live=3;
    // Start is called before the first frame update
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();

        Random.InitState(10);
        flapstrength = 3;
        Shoot();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < deadZone)
        {
            myRigidbody.velocity = Vector2.up * flapstrength;

        }
        if (timerProj < Spawnrate)
        {
            timerProj = timerProj + Time.deltaTime;
        }
        else
        {
            Shoot();
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (live == 1)
        {
            Destroy(gameObject);
            logic.deadenemy(1);
        }
        else
        {
            live = live - 1;
        }
    }

    private void Shoot()
    {
        int randomNumber = Random.Range(0, 10);
        if (randomNumber == 0 || randomNumber == 3 || randomNumber == 4 || randomNumber == 6 || randomNumber == 8 || randomNumber == 5 || randomNumber == 1)
        {
            Instantiate(project, transform.position + Vector3.left / 2 * 3 + Vector3.down / 2, transform.rotation);
        }
        timerProj = 0;
    }
}
