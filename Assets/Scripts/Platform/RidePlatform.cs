using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RidePlatform : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // stay on the platform on collision
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
