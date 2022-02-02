using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Regen : MonoBehaviour
{
    public int heal = 30;
    public float speed = 10f;

    void Update()
    {
        transform.Translate((-transform.up * speed * Time.deltaTime));
    }

    private void OnTriggerEnter2D(Collider2D other) {

        if(other.CompareTag("Player")){            
        Destroy(this.gameObject);
        }
    }
}
