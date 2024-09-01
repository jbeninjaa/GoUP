using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class PlayerMovement : MonoBehaviour
{
    [Header("Physics Properties")]
    [SerializeField] private float power = 2.0f;
    [SerializeField] private Vector2 minPower;
    [SerializeField] private Vector2 maxPower;


    
// Flip the sprite if the force is to the left
    
    [Header("References")]
    [SerializeField] private PlayerController playerControllerScript; 
    private PlayerAudioController audioController;
    
    
    
    private Reticle trajectoryLine; 

    private Camera cam;
    private Vector2 force;
    private Vector3 startPoint;
    private Vector3 endPoint;
    private Rigidbody2D playerRB;

    

    Animator animator;

    // Start is called before the first frame update
    void Start(){
        playerRB = GetComponent<Rigidbody2D>();
        cam = Camera.main;
        trajectoryLine = GetComponent<Reticle>();
        animator = GetComponent<Animator>();
        audioController = GetComponent<PlayerAudioController>();
    }

    void Update(){
        animator.SetBool("isGrounded_b", playerControllerScript.isGrounded);
    }

    // Get mouse position when clicked
    public void Pull() { 
        if(!GameManager.Instance.GetIsGamePause()){
            animator.SetBool("isDragging_b", true);

            startPoint = cam.ScreenToWorldPoint(Input.mousePosition);
            startPoint.z = 15;
        }
    }

    // current mouse position
    public void Drag() {
        if(!GameManager.Instance.GetIsGamePause()){
            Vector3 currentPoint = cam.ScreenToWorldPoint(Input.mousePosition);
            currentPoint.z = 15;
            trajectoryLine.RenderLine(startPoint, currentPoint);
            // Flip the sprite if the force is to the left
            float forceX = Mathf.Clamp(startPoint.x - currentPoint.x, minPower.x, maxPower.x);
            
            spriteDirection(forceX);
        }
    }

    // release mouse position
    public void Release() {
        if(!GameManager.Instance.GetIsGamePause()){
            audioController.PlayJumpAudio();

            animator.SetBool("isDragging_b", false);

            endPoint = cam.ScreenToWorldPoint(Input.mousePosition);
            endPoint.z = 15;
            
            // Set the velocity of the player to zero
            playerRB.velocity = Vector2.zero;
            
            // calculate force to add to the player
            float forceX = Mathf.Clamp(startPoint.x - endPoint.x, minPower.x, maxPower.x);
            float forceY = Mathf.Clamp(startPoint.y - endPoint.y, minPower.y, maxPower.y);
            force = new Vector2(forceX, forceY);
            
        
            playerRB.AddForce(force * power, ForceMode2D.Impulse);
            trajectoryLine.EndLine();            
        }
    }

    
    private void spriteDirection(float direction){ // Flip the sprite if the force is to the left
        if (direction < 0) {
            SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
            spriteRenderer.flipX = true;
        } else {
            SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
            spriteRenderer.flipX = false;
        }
    }
}
