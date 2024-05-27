using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class EndScene : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI finalScoreText;
    private int finalScore;
    // Start is called before the first frame update
    void Start()
    {
        finalScore = GameManager.Instance.GetScore();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void updateFinalScoreText(){
         finalScoreText.text = "Score: " + finalScore.ToString();
    }

    private void OnRestartButtonClicked()
    {
        // Load the main game scene
        GameManager.Instance.ResetGame();
        SceneManagerScript.Instance.LoadGameScene();
    }

    private void OnMenuButtonClicked(){
        GameManager.Instance.ResetGame();
        SceneManagerScript.Instance.LoadMenuScene();
    }
}
