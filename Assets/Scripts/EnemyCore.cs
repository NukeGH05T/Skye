using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Maybe add random left/right movement patterns in future
public class EnemyCore : MonoBehaviour
{
    public int health = 10;
    public int damage = 10;
    int scoreToAward = 50;
    [SerializeField] float moveSpeed = 5f; 
    Rigidbody2D rb;
    GameObject player;

    //Spawns and just goes forward

    private void Start() {
        player = GameObject.Find("Player");

        //Movement
        rb = this.GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(0, -moveSpeed);
    }

    //Taking Damage
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Fired")){
            DealDamage(other.GetComponent<Projectile>().damage);
        }
    }

    public void DealDamage(int dmg){
        health -= dmg;
        if(health <= 0){
            player.GetComponent<Player>().ScoreUpdate(scoreToAward);
            Destroy(this.gameObject);
        }
    }

}