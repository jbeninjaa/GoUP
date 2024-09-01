using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Authentication;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{   public bool isGrounded = false;
    
    public float bounceMultiplier = 2.0f;  // Multiplier for the bounce force

    private Rigidbody2D rb;

    private PlayerAudioController audioController;

    #region Score Values
        private float highestYpos;
        private float startingYpos;
        private int score = 0;
    #endregion

    // Update is called once per frame
    void Start(){
        audioController = GetComponent<PlayerAudioController>();
        rb = GetComponent<Rigidbody2D>();
        highestYpos = transform.position.y;
        startingYpos = transform.position.y;
    }
    void Update()
    {
       UpdateScore();
    }

    #region Collision Detection
        void OnCollisionEnter2D(Collision2D col){
            if(col.gameObject.CompareTag("Platform") && transform.position.y > col.transform.position.y) {
                isGrounded = true;
            }
        }

        void OnCollisionExit2D(Collision2D col){
            if(col.gameObject.CompareTag("Platform")) {
                isGrounded = false;
            }
        }

        void OnTriggerEnter2D(Collider2D collider){
        if(collider.gameObject.CompareTag("Bottom") || collider.gameObject.CompareTag("Enemy")) {
            GameOver();
        }
    }
    #endregion

    void stopMoving(){
        GetComponent<Rigidbody2D>().velocity = Vector2.zero;
    }

    void GameOver(){
        GameManager.Instance.GameOver();
    }

    void UpdateScore(){
        highestYpos = Mathf.Max(highestYpos, transform.position.y);

        score = Mathf.FloorToInt(highestYpos - startingYpos);
        // Update the score in the GameManager
        GameManager.Instance.SetScore(score);
    }
}
