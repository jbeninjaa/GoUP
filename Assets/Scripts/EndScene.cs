using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;
using UnityEditor.UI;

public class EndScene : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI finalScoreText;
    [SerializeField] private TextMeshProUGUI playerNameText;
    [SerializeField] private TMP_InputField playerNameInputField;
    private int finalScore = 0;
    private string playerName;
    
    // Start is called before the first frame update
    void Start()
    {
        finalScore = GameManager.Instance.GetFinalScore();
        playerNameInputField.onEndEdit.AddListener(OnPlayerNameEntered);

        updateFinalScoreText();
        playerNameText.text = playerNameInputField.text;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void updateFinalScoreText(){
        finalScoreText.text = "Score: " + finalScore.ToString();
    }

    void updatePlayerNameText(){
        playerNameText.text = GameManager.Instance.GetPlayerName();
    }

    private void OnPlayerNameEntered(string playerNameText){
            // Enter key was pressed
        GameManager.Instance.SetPlayerName(playerNameText);
        updatePlayerNameText();

        LeaderboardManager.instance.AddEntry(playerNameText, finalScore);
    }

    private void OnRestartButtonClicked()
    {
        // Load the main game scene
        GameManager.Instance.ResetGame();
        SceneManagerScript.Instance.LoadGameScene();
    }

    private void OnMenuButtonClicked(){
        // GameManager.Instance.ResetGame();
        SceneManagerScript.Instance.LoadMenuScene();
    }
}
