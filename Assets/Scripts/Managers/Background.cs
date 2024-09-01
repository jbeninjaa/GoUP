using UnityEngine;

public class VerticalBackgroundFollow : MonoBehaviour
{
    public Transform player; // The player's transform
    private Vector3 initialPosition; // Initial position of the background
    private float offsetY; // Offset between the background and the player on the Y-axis

    void Start()
    {
        // Store the initial position of the background
        initialPosition = transform.position;

        // Calculate the initial offset between the player and the background
        offsetY = initialPosition.y - player.position.y;
    }

    void Update()
    {
        // Follow the player's vertical position with the offset
        transform.position = new Vector3(initialPosition.x, player.position.y + offsetY, initialPosition.z);
    }
}
