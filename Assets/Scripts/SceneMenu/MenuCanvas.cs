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
     
    }

    // Update is called once per frame
    void Update()
    {
        
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
