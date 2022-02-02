using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Player : MonoBehaviour
{
    [Header("Base Stats")]
    [SerializeField] private float moveForce = 10f;

    [Header("Prefab Inctances")]
    [SerializeField] private Rigidbody2D rb;
    public Transform gunPoint;

    [SerializeField] TMP_Text scrtext;
    
    [Header("Projectile Variants")]
    [SerializeField] private GameObject fire_small;
    [SerializeField] private GameObject fire_mid;

    int score = 0;

    private void Start() {
        ScoreUpdate(score);
    }
    
    void Update()
    {
        if(Input.GetAxisRaw("Horizontal") != 0){
            rb.velocity = Vector2.right * moveForce * Input.GetAxisRaw("Horizontal"); 
        }

        //Maybe allow players to use only Primary or Secondary fire instead of both ?
        if(Input.GetButtonDown("Fire1")){
            GameObject newFire = Instantiate(fire_small, gunPoint.transform.position, Quaternion.identity);
            Destroy (newFire, 2.4f);
        }

        if(Input.GetButton("Fire2")){
            GameObject newFire = Instantiate(fire_mid, gunPoint.transform.position, Quaternion.identity);
            Destroy (newFire, 3.0f);
        }

        //A way to close the game
        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }
    }

    public void ScoreUpdate(int scr){
        score += scr;
        scrtext.SetText(score.ToString());
    }
}
