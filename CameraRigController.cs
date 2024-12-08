using UnityEngine;

public class CameraRigController : MonoBehaviour
{
    public Transform player; // Reference to the player's Transform
    public float rotationSpeed = 100f; // Speed of rotation

    private void Update()
    {
        // Rotate around the player based on input
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Horizontal rotation
        transform.RotateAround(player.position, Vector3.up, horizontalInput * rotationSpeed * Time.deltaTime);

        // Optional: Vertical rotation (clamp to prevent flipping)
        transform.RotateAround(player.position, transform.right, -verticalInput * rotationSpeed * Time.deltaTime);
    }
}