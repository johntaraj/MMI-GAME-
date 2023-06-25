using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 10f;  // Speed of the bullet
    public int damage = 1;    // Damage inflicted on the target

    private Vector3 direction; // Direction of movement
    private bool movingRight;  // Indicates if the bullet is moving to the right

    private void Start()
    {
        // Set the initial direction based on the specified parameter
        direction = movingRight ? Vector3.right : Vector3.left;
    }

    private void Update()
    {
        // Move the bullet in the specified direction
        transform.Translate(direction * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the bullet has hit a character
        if (other.CompareTag("MainPlayer")){
            MainPlayer player =other.GetComponent<MainPlayer>();
            if (player != null)
            {
                player.RemoveLife();
                Destroy(gameObject);
        } 
        else if(other.CompareTag("Enemy")){
            Enemy E =other.GetComponent<Enemy>();
            if (E != null)
            {
                
                E.RemoveLife();
                 Destroy(gameObject);
        } }
               
            
        }
    }
}