using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Maybe add random left/right movement patterns in future
public class EnemyCore : MonoBehaviour
{
    public int health = 10;
    public int damage = 10;
    int scoreToAward = 50;
    [SerializeField] Vector2 timeBetweenShots;
    [SerializeField] float destroyAfter = 2.3f;
    [SerializeField] float moveSpeed = 5f; 
    [SerializeField] GameObject bullet; 
    bool isAbletoShoot = false;
    Rigidbody2D rb;
    GameObject player;

    //Spawns and just goes forward

    private void Start() {
        player = GameObject.Find("Player");

        //Movement
        rb = this.GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(0, -moveSpeed);

        //Shooting
        StartCoroutine(Shoot());
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

    IEnumerator Shoot(){
        while(true){
            yield return new WaitForSeconds(Random.Range(timeBetweenShots.x, timeBetweenShots.y));
            GameObject enemy = Instantiate(bullet, this.transform.position, Quaternion.identity);
            Destroy(enemy, destroyAfter);
        }
    }

}