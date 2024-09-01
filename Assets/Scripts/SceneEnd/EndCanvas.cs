using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EndCanvas : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI finalScore;
    [SerializeField] private TMP_InputField playerNameInputField;
    [SerializeField] private TextMeshProUGUI scoreNameText;
    private string playerName;

    private bool oneEntryFlag = true;

    // Start is called before the first frame update
    void Start()
    {
        playerNameInputField.onEndEdit.AddListener(OnPlayerNameEntered);
        UpdateScoreText();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    #region UI renderer
        private void UpdateScoreText(){
            finalScore.text = GameManager.Instance.GetFinalScore().ToString();
        }

        private void UpdateScoreNameText(int score, string playerName){
            scoreNameText.text = score.ToString() + "  " + playerName;
        }
    #endregion

    #region Update leader boards
        void addLeaderBoardEntry(string name, int score){
            LeaderboardManager.instance.AddEntry(name, score);
        }

        private void OnPlayerNameEntered(string playerNameText){
            // Enter key was pressed

            playerName = playerNameText;
          
            if (oneEntryFlag){
                addLeaderBoardEntry(playerName, GameManager.Instance.GetFinalScore());
                UpdateScoreNameText(GameManager.Instance.GetFinalScore(), playerName);
                oneEntryFlag = false;
            }
            
        }

    #endregion
    
    #region OnRestartButtonClicked(), OnMenuClicked()
        public void OnRestartButtonClicked()
        {
            // Load the main game scene
            SceneManagerScript.Instance.LoadGameScene();
        }

        public void OnMenuClicked()
        {
            // Quit the application
            SceneManagerScript.Instance.LoadMenuScene();
        }
    #endregion
}
