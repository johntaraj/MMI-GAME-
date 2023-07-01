using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows.Speech;

public class MainScript : MonoBehaviour
{
    private KeywordRecognizer m_Recognizer;

    public Rigidbody2D myRigidbody;
    public float flapstrength;
    public GameObject project;
    public float Spawnrate = 5.0f;
    public float timerProj = 0;
    public float timerDef = 0;
    public bool playeraliv = true;
    public LogicScript logic;
    public GameObject Shield;
    public bool shield = false;
    private string[] m_Keywords = { "shoot", "up", "down", "go" };

    private bool upDis = false;
    private bool downDis = false;
    private bool goCommandSpoken = false; // Flag to indicate "go" command spoken
    private float goCommandTime;
    private float maxDelay = 4.0f; // Max delay in seconds (85ms)

    void Start()
    {
        flapstrength = 8;
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
        m_Recognizer = new KeywordRecognizer(m_Keywords);
        m_Recognizer.OnPhraseRecognized += OnPhraseRecognized;
        m_Recognizer.Start();
    }

    private void OnPhraseRecognized(PhraseRecognizedEventArgs args)
    {
        string t = args.text;

        if (t == "shoot")
        {
            goCommandTime = Time.time; // Save the time when "go" is spoken
            goCommandSpoken = true; // Set flag to true
            shoot();
        }
        else if (t == "up")
        {
            upDis = true;
            moveUp();
        }
        else if (t == "down")
        {
            downDis = true;
            moveDown();
        }

    }
    void Update()
    {
        timerDef = timerDef + Time.deltaTime;
        timerProj = timerProj + Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.UpArrow) == true && playeraliv == true && !upDis)
        {
            moveUp();
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow) == true && playeraliv == true && !downDis)
        {
            moveDown();
        }

        if (Input.GetKeyDown(KeyCode.D) == true && playeraliv == true)
        {
            shieldf();
        }
        if (shield == true && timerDef > 2)
        {
            Shield.SetActive(false);
            shield = false;
        }

        if (Input.GetKeyDown(KeyCode.Space) == true && playeraliv == true)
        {
            if (goCommandSpoken && (Time.time - goCommandTime) <= maxDelay)
            {
                StartCoroutine(shoot_special()); // Execute the special shoot
                goCommandSpoken = false; // Reset the flag
            }
            else
            {
                shoot(); // Normal shoot
                goCommandSpoken = false; // Reset the flag after a regular shoot too
            }
        }

        if (logic.playerlives == 0)
        {
            playeraliv = false;
        }
        upDis = false;
        downDis = false;
    }

    // Remaining methods...

    IEnumerator shoot_special() // Coroutine for special shoot
    {
        if (timerProj > Spawnrate)
        {
            for (int i = 0; i < 5; i++)
            {
                Vector3 offset = new Vector3(i, 0, 0);
                Instantiate(project, transform.position + Vector3.right / 2 * 3 + Vector3.down / 2 + offset, transform.rotation);
                yield return new WaitForSeconds(0.2f);
            }
            timerProj = 0;
        }
    }



    void moveUp()
    {
        myRigidbody.velocity = Vector2.up * flapstrength;
    }

    void moveDown()
    {
        myRigidbody.velocity = Vector2.down * flapstrength;
    }

    void shieldf()
    {
        if (timerDef > Spawnrate * 5)
        {
            Shield.SetActive(true);
            shield = true;
            timerDef = 0;
        }
    }

    void shoot()
    {
        if (timerProj > Spawnrate)
        {
            Instantiate(project, transform.position + Vector3.right / 2 * 3 + Vector3.down / 2, transform.rotation);
            timerProj = 0;
        }
    }
}