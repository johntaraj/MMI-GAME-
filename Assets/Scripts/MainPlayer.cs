using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainPlayer : MonoBehaviour
{
    bool dead;
    public int live;

    // Start is called before the first frame update
    void Start()
    {
        bool=false;
        live=3;
    }

    // Update is called once per frame
    void Update()
    {
     if(!dead){
        if(Input.GetKeyDown("up")){
            move(0);
        }else if(Input.GetKeyDown("down")){
            move(1);
        }
        if(Input.GetKeyDown("space")){
            shoot()

        }

     }   
    }

    void move(int p){
        if(p==0){
            transform.position = new Vector3(0,2,0) * Time.deltaTime;
        }
        else if(p==1){
            transform.position = new Vector3(0,-2,0) * Time.deltaTime;
        }
     
    }

    void shoot(){
        
    }

}
