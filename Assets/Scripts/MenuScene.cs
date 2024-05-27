using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MenuScene : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI highScoreText;

    // Start is called before the first frame update
    void Start()
    {
        UpdateHighScoreText();
         foreach (var entry in LeaderboardManager.instance.leaderboardEntries){
            Debug.Log("Name: " + entry.playerName + " Score: " + entry.score.ToString());
         }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void UpdateHighScoreText(){
        highScoreText.text = "High Score: " + LeaderboardManager.instance.leaderboardEntries[0].playerName + " = " + LeaderboardManager.instance.leaderboardEntries[0].score.ToString();
    }
    
    public void OnPlayButtonClicked()
    {
        // Load the main game scene
        SceneManagerScript.Instance.LoadGameScene();
    }

    public void OnQuitButtonClicked()
    {
         // Quit the application
        Application.Quit();
    }
}
