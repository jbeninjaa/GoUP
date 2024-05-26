using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MouseInput : MonoBehaviour
{
    [Header("Script Reference")]
    [SerializeField] private PlayerMovement playerMovementScript; 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) {
            playerMovementScript.Pull();
        }

        if (Input.GetMouseButtonUp(0)) {
            playerMovementScript.Relase();
        }
    }
}
