using UnityEngine;

public class MouseInput : MonoBehaviour
{
    [Header("Script Reference")]
    [SerializeField] private PlayerMovement playerMovementScript; 
    [SerializeField] private PlayerController playerControllerScript; 

    
    Animator animator;

    void Start(){
        animator = GetComponent<Animator>();
        
    }
    // Update is called once per frame
    void Update()
    {
        
        // mouse clicked down
        if (Input.GetMouseButtonDown(0) && playerControllerScript.isGrounded) {
            playerMovementScript.Pull();
        }

        // mouse held
        if (Input.GetMouseButton(0) && playerControllerScript.isGrounded) {
            playerMovementScript.Drag();
        }

        // mouse released
        if (Input.GetMouseButtonUp(0) && playerControllerScript.isGrounded) {
            playerMovementScript.Release();
        }
    }
}
