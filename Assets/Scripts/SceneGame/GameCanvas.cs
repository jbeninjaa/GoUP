using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameCanvas : MonoBehaviour
{
    [SerializeField] private GameObject pausePanel;
    [SerializeField] private TextMeshProUGUI scoreText;
    private AudioSource adSrc;

    // Start is called before the first frame update
    void Start()
    {
        adSrc = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateScoreText();
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseGame();
        }
    }
    
    #region Button Events
        public void OnPlayPauseClicked(){
            PauseGame();
        }

        public void OnPlayResumeClicked()
        {
            ResumeGame();
        }

        public void OnPlayMenuClicked(){
            ResumeGame();
            GameManager.Instance.ResetGame();
            SceneManagerScript.Instance.LoadMenuScene();
        }
    #endregion 
    
    #region Ui Renderer
        private void UpdateScoreText(){
            scoreText.text = GameManager.Instance.GetScore().ToString();
        }
    #endregion

    public void PauseGame(){
        adSrc.Pause();
        pausePanel.SetActive(true);
        GameManager.Instance.SetIsGamePause(true);
        
        // Pause the game
        Time.timeScale = 0;
    }

    public void ResumeGame(){
        adSrc.Play();
        pausePanel.SetActive(false);
        GameManager.Instance.SetIsGamePause(false);
        
        // Resume the game
        Time.timeScale = 1;
    }
}
