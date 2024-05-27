using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sensor : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision){
        // Check if the collided object has a tag named "Platform"
        if (collision.gameObject.CompareTag("Platform"))
        {
            // Destroy the platform
            Destroy(collision.gameObject);
        }
    }
}
