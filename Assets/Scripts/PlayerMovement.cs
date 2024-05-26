using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Physics Properties")]
    [SerializeField] private float power = 2.0f;
    [SerializeField] private Vector2 minPower;
    [SerializeField] private Vector2 maxPower;

    private Camera cam;
    private Vector2 force;
    private Vector3 startPoint;
    private Vector3 endPoint;
    private Rigidbody2D playerRB;

    // Start is called before the first frame update
    void Start(){
        playerRB = GetComponent<Rigidbody2D>();
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update(){
        
    }

    public void Pull(){
        startPoint = cam.ScreenToWorldPoint(Input.mousePosition);
        startPoint.z = 15;
        Debug.Log(startPoint);
    }

    public void Relase(){
        endPoint = cam.ScreenToWorldPoint(Input.mousePosition);
        endPoint.z = 15;
        Debug.Log(endPoint);

        float forceX = Mathf.Clamp(startPoint.x - endPoint.x, minPower.x, maxPower.x);
        float forceY = Mathf.Clamp(startPoint.y - endPoint.y, minPower.y, maxPower.y);
        force = new Vector2(forceX, forceY);
        playerRB.AddForce(force * power, ForceMode2D.Impulse);
    }
}
