using UnityEngine;

public class MoveLeftRight : MonoBehaviour
{
    private float minX = -3.5f; // minimum x position
    private float maxX = 3.5f; // maximum x position
    private float speed = .5f; // movement speed
    private float amplitude = 2.5f; // amplitude of the sinusoidal motion

    private float xOffset; // x offset for the sinusoidal motion

    // Update is called once per frame
    void Start()
    {
        // Set a random x offset for each platform
        xOffset = Random.Range(0f, 2 * Mathf.PI);
        speed += Random.Range(-0.5f, 1f);
        amplitude += Random.Range(-1f, 1f);
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
}