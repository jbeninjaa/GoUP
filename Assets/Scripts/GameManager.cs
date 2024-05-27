using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance {get; private set;}

    private bool isGameOver = false;
    private int score = 0;
    private int finalScore;
    private string playerName;



    private void Awake() {
        // Game Manager should be generated between scenes 
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
     if (isGameOver && Input.GetKeyDown(KeyCode.R))
        {
            ResetGame();
        }   
    }

    #region Setters and getters 
    public int GetScore(){
        return score;
    }

    public void SetScore(int score){
        this.score = score;
    }

    public int GetFinalScore(){
        return finalScore;
    }

    public void SetFinalScore(int finalScore){
        this.finalScore = finalScore;
    }
    public void SetPlayerName(string playerName){
        this.playerName = playerName;
    }
    public string GetPlayerName(){
        return playerName;
    }
    #endregion

    public void GameOver(){
        isGameOver = true;
        // UIManagerScript.ShowGameOverScreen();
        SceneManagerScript.Instance.LoadEndScene();
        finalScore = score;
    }

    public void ResetGame(){
        isGameOver = false;
        score = 0;
        finalScore = 0;
        playerName = null;
    }
}
