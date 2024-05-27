using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] Transform playerTransform;
    private int scoreToAdd;
    private int scoreMultiplier = 1;
    private int maxScoreToAdd = 0;
    
    private void Start(){
        
    }

    private void Update(){
        UpdateScoreText();
    }

    private void UpdateScoreText(){
        // update score, score is relatively proportional to the max Y position of player;
        scoreToAdd = (int) (scoreMultiplier + playerTransform.position.y);
        if(scoreToAdd > maxScoreToAdd){
            maxScoreToAdd = scoreToAdd;
        }
        GameManager.Instance.SetScore(maxScoreToAdd);

        scoreText.text = "Score: " + GameManager.Instance.GetScore().ToString();
    }
}
