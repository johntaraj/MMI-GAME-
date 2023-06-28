using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows.Speech;

public class MainScript : MonoBehaviour
{
    private KeywordRecognizer m_Recognizer;

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
    private string[] m_Keywords = {"shoot","up","down"};

    private bool upDis = false;
    private bool downDis = false;

    // Start is called before the first frame update
    void Start()
    {
        flapstrength = 4;
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
        m_Recognizer = new KeywordRecognizer(m_Keywords);
        m_Recognizer.OnPhraseRecognized += OnPhraseRecognized;
        m_Recognizer.Start();
    }

     private void OnPhraseRecognized(PhraseRecognizedEventArgs args)
    {  
       string t = args.text;

        if(t=="shoot"){
            shoot();
        }else if (t=="up"){
            upDis=true;
            moveUp();
        }
        else if(t=="down"){
            downDis=true;
            moveDown();
        }
    }
    // Update is called once per frame
    void Update()
    {
        timerDef = timerDef + Time.deltaTime;
        timerProj = timerProj + Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.UpArrow) == true && playeraliv == true && !upDis)
        {
         moveUp();  
        }else if(Input.GetKeyDown(KeyCode.DownArrow) == true && playeraliv == true && !downDis) {
            moveDown();
        }

        if (Input.GetKeyDown(KeyCode.D) == true && playeraliv == true)
        {
           shieldf();
        }
        if (shield == true && timerDef > 1)
        {
            Shield.SetActive(false);
            shield =false;
        }
        if (Input.GetKeyDown(KeyCode.Space) == true && playeraliv == true)
        {
            shoot();
        }
        
        if (logic.playerlives == 0)
        {
            playeraliv = false;
        }
        upDis = false;
        downDis = false;
    }


void moveUp(){
 myRigidbody.velocity = Vector2.up * flapstrength;
}

void moveDown(){
 myRigidbody.velocity = Vector2.down * flapstrength;
}
void shieldf(){
 if (timerDef > Spawnrate*5)
            {
                Shield.SetActive(true);
                shield = true;
                timerDef = 0;
            }
}
void shoot(){
if (timerProj > Spawnrate)
            {
                Instantiate(project, transform.position + Vector3.right/2*3 + Vector3.down / 2, transform.rotation); 
                timerProj = 0;
            }
}

}