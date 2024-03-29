using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    public int damage = 10;
    public float speed = 10f;

    void Update()
    {
        //It just goes down lmao, maybe add something fancy here depending on the projectile
        transform.Translate((-transform.up * speed * Time.deltaTime));
    }

    private void OnTriggerEnter2D(Collider2D other) {

        if(other.CompareTag("Player") || other.CompareTag("Fired")){            
        Destroy(this.gameObject);
        }
    }
}
