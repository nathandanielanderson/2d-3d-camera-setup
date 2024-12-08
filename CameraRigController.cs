using UnityEngine;

public class CameraRigController : MonoBehaviour
{
    public Transform player; // Reference to the player's Transform
    public float rotationSpeed = 100f; // Speed of rotation

    public float minVerticalAngle = -30f; // Minimum vertical angle (looking down)
    public float maxVerticalAngle = 60f; // Maximum vertical angle (looking up)

    private float currentVerticalAngle = 0f; // Tracks the current vertical angle

    private void Update()
    {
        // Get input
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Horizontal rotation
        transform.RotateAround(player.position, Vector3.up, horizontalInput * rotationSpeed * Time.deltaTime);

        // Vertical rotation (clamped)
        float verticalRotation = -verticalInput * rotationSpeed * Time.deltaTime;
        float newVerticalAngle = Mathf.Clamp(currentVerticalAngle + verticalRotation, minVerticalAngle, maxVerticalAngle);

        // Calculate the change in angle
        float angleDelta = newVerticalAngle - currentVerticalAngle;
        currentVerticalAngle = newVerticalAngle;

        // Apply the vertical rotation
        transform.RotateAround(player.position, transform.right, angleDelta);
    }
}