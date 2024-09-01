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
        // mouse clicked down
        if (Input.GetMouseButtonDown(0)) {
            playerMovementScript.Pull();
        }

        // mouse held
        if (Input.GetMouseButton(0)) {
            playerMovementScript.Drag();
        }

        // mouse released
        if (Input.GetMouseButtonUp(0)) {
            playerMovementScript.Relase();
        }
    }
}
