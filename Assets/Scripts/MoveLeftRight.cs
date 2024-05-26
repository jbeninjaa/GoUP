using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class MoveLeftRight : MonoBehaviour
{
    private float minX = -1f; // minimum x position
    private float maxX = 1f; // maximum x position
    private float speed = 1f; // movement speed
    private float amplitude = 2f; // amplitude of the sinusoidal motion

    private float xOffset = 0f; // x offset for the sinusoidal motion

    // Update is called once per frame
    void Start(){
        speed += Random.Range(-0.5f, 0.5f);
        amplitude += Random.Range(-0.5f, 0.5f);
    }
    void Update()
    {
        // Calculate the x position using a sinusoidal function
        float xPos = minX + (maxX - minX) / 2 + Mathf.Sin(xOffset) * amplitude;

        // Update the x offset for the next frame
        xOffset += speed * Time.deltaTime;

        // Set the platform's position
        transform.position = new Vector3(xPos, transform.position.y, transform.position.z);
    }

    // Ride the platform if collision is from above
    void OnCollisionEnter2D(Collision2D collision){
        if (collision.gameObject.CompareTag("Player") && collision.gameObject.transform.position.y > transform.position.y){
            collision.gameObject.transform.parent = transform;
        }
    }

    // detach from the platform when exiting collision
    void OnCollisionExit2D(Collision2D collision){
    if (collision.gameObject.CompareTag("Player")){
        collision.gameObject.transform.parent = null;
    }
}
}