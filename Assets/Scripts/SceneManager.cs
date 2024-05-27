using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerScript : MonoBehaviour
{
    public static SceneManagerScript Instance {get; private set;}
    private void Awake() {
        // SceneManager should be generated between scenes 
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
        
    }

    public void OnPlayButtonClicked()
    {
        // Load the main game scene
        SceneManager.LoadScene("GameScene");
    }

    public void OnQuitButtonClicked()
    {
         // Quit the application
        Application.Quit();
    }

    public void LoadEndScene(){
        SceneManager.LoadScene("EndScene");
    }

    public void LoadGameScene(){
        SceneManager.LoadScene("GameScene");
    }

    public void LoadMenuScene(){
        SceneManager.LoadScene("MenuScene");
    }
}

