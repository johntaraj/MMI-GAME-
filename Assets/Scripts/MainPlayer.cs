using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class MainPlayer : MonoBehaviour
{
    bool dead;
    public GameObject bulletPrefab;
    public int live;
    bool shootRight;

    // Start is called before the first frame update
    void Start()
    {
        dead=false;
        live=3;
        shootRight=  true;
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
            shoot();

        }

     }  else{
        deathScene();
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

    public void RemoveLife(){
        
        live=live-1;
        if (live<1){
            dead=true;
        }
    }
    void shoot(){
    GameObject bulletObject = Instantiate(bulletPrefab, transform.position, Quaternion.identity);

    Bullet bullet = bulletObject.GetComponent<Bullet>();
    if (bullet != null)
    {
        bullet.movingRight = shootRight;
    }
    }
    void deathScene(){
        //screen when dead
    }

}
