using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TakeDamage : MonoBehaviour
{
    BoxCollider2D col;
    int scoreToAward = 50;
    public int health = 100;
    public int maxHealth = 300;
    [SerializeField] TMP_Text hpText;

    private void Start() {
        col = this.GetComponent<BoxCollider2D>();
    }

    private void OnTriggerEnter2D(Collider2D other) {

        //Deal damage from EnemyCore script if it's an enemy otherwise deal damage from Projectile script and destroy the object
        if(other.CompareTag("Enemy") || other.CompareTag("EFired") || other.CompareTag("Regen")){

            if(other.CompareTag("Enemy")){
                health -= other.GetComponent<EnemyCore>().damage;

            } else if(other.CompareTag("Regen")){
                if(health <= maxHealth - 30){
                    health += other.GetComponent<Regen>().heal;
                } else if(health < maxHealth && health > maxHealth - other.GetComponent<Regen>().heal){
                    health = maxHealth;
                }

            } else { //Getting hit by enemy projectile
                health -= other.GetComponent<EnemyProjectile>().damage;
            }

            hpText.SetText("HP: " + health.ToString());
                
            Destroy(other.gameObject);
            this.GetComponent<Player>().ScoreUpdate(scoreToAward);
        }
    }
}
