using UnityEngine;

public class CameraRigController : MonoBehaviour
{
    public Transform player; // Reference to the player's Transform
    public float rotationSpeed = 100f; // Speed of rotation

    public float minVerticalAngle = -30f; // Minimum vertical angle
    public float maxVerticalAngle = 60f;  // Maximum vertical angle

    private float currentVerticalAngle = 0f; // Tracks the current vertical rotation

    private void Update()
    {
        // Get input for rotation
        float verticalInput = Input.GetAxis("Vertical");

        // Calculate new vertical angle
        float newVerticalAngle = currentVerticalAngle - verticalInput * rotationSpeed * Time.deltaTime;

        // Clamp vertical angle
        newVerticalAngle = Mathf.Clamp(newVerticalAngle, minVerticalAngle, maxVerticalAngle);

        // Apply vertical rotation
        transform.RotateAround(player.position, transform.right, newVerticalAngle - currentVerticalAngle);
        currentVerticalAngle = newVerticalAngle;
    }
}