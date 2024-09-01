using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    [SerializeField] private float smoothingValue = 0.1f;
    [SerializeField] private Transform target;
    // Start is called before the first frame update
    void Start()
    {
        Vector3 playerPosition = GameObject.FindGameObjectWithTag("Player").transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(target.position.y > transform.position.y){
            float newPosY = Mathf.Lerp(transform.position.y, target.position.y, smoothingValue);
            transform.position = new Vector3(transform.position.x, newPosY, transform.position.z);
        }
    }
}

