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

    [Header("References")]
    private Reticle trajectoryLine; 

    private Camera cam;
    private Vector2 force;
    private Vector3 startPoint;
    private Vector3 endPoint;
    private Rigidbody2D playerRB;

    // Start is called before the first frame update
    void Start(){
        playerRB = GetComponent<Rigidbody2D>();
        cam = Camera.main;
        trajectoryLine = GetComponent<Reticle>();
    }

    // Update is called once per frame
    void Update(){

    }

    public void Pull() {
        startPoint = cam.ScreenToWorldPoint(Input.mousePosition);
        startPoint.z = 15;

    }

    public void Drag() {
        Vector3 currentPoint = cam.ScreenToWorldPoint(Input.mousePosition);
        currentPoint.z = 15;
        trajectoryLine.RenderLine(startPoint, currentPoint);
    }

    public void Relase() {
        endPoint = cam.ScreenToWorldPoint(Input.mousePosition);
        endPoint.z = 15;
        
        // add Force to player
        float forceX = Mathf.Clamp(startPoint.x - endPoint.x, minPower.x, maxPower.x);
        float forceY = Mathf.Clamp(startPoint.y - endPoint.y, minPower.y, maxPower.y);
        force = new Vector2(forceX, forceY);
        playerRB.AddForce(force * power, ForceMode2D.Impulse);
        
        trajectoryLine.EndLine();
    }

    public void UpdateScore(){
        // int scoreToAdd = 0;
        // float maxY = 0;
        // if(maxY < transform.position.y){
        //     maxY = transform.position.y;
        // }

        

        GameManager.Instance.SetScore(100);
    }
}
