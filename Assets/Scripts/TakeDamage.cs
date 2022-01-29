using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TakeDamage : MonoBehaviour
{
    BoxCollider2D col;
    int scoreToAward = 50;
    public int health = 100;
    [SerializeField] TMP_Text hpText;

    private void Start() {
        col = this.GetComponent<BoxCollider2D>();
    }

    private void OnTriggerEnter2D(Collider2D other) {

        //Deal damage from EnemyCore script if it's an enemy otherwise deal damage from Projectile script and destroy the object
        if(other.CompareTag("Enemy") || other.CompareTag("EFired")){

        if(other.CompareTag("Enemy")){
            health -= other.GetComponent<EnemyCore>().damage;
        } else {
            health -= other.GetComponent<Projectile>().damage;
        }

        hpText.SetText("HP: " + health.ToString());
            
        Destroy(other.gameObject);
        this.GetComponent<Player>().ScoreUpdate(scoreToAward);
        }
    }
}
