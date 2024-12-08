using UnityEngine;

public class CameraRigController : MonoBehaviour
{
    public Transform player; // Reference to the player's Transform
    public float rotationSpeed = 100f; // Speed of rotation

    public float minVerticalAngle = -30f; // Minimum vertical angle
    public float maxVerticalAngle = 60f;  // Maximum vertical angle
    public float minHorizontalAngle = 0f; // Minimum horizontal angle
    public float maxHorizontalAngle = 360f; // Maximum horizontal angle

    private float currentVerticalAngle = 0f; // Tracks the current vertical rotation
    private float currentHorizontalAngle = 0f; // Tracks the current horizontal rotation

    private void Update()
    {
        // Get input for rotation
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Calculate new horizontal angle
        float newHorizontalAngle = currentHorizontalAngle + horizontalInput * rotationSpeed * Time.deltaTime;

        // Clamp horizontal angle
        newHorizontalAngle = Mathf.Clamp(newHorizontalAngle, minHorizontalAngle, maxHorizontalAngle);

        // Apply horizontal rotation
        transform.RotateAround(player.position, Vector3.up, newHorizontalAngle - currentHorizontalAngle);
        currentHorizontalAngle = newHorizontalAngle;

        // Calculate new vertical angle
        float newVerticalAngle = currentVerticalAngle - verticalInput * rotationSpeed * Time.deltaTime;

        // Clamp vertical angle
        newVerticalAngle = Mathf.Clamp(newVerticalAngle, minVerticalAngle, maxVerticalAngle);

        // Apply vertical rotation
        transform.RotateAround(player.position, transform.right, newVerticalAngle - currentVerticalAngle);
        currentVerticalAngle = newVerticalAngle;
    }
}