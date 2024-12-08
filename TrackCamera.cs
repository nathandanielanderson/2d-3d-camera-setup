using UnityEngine;

public class TrackCamera : MonoBehaviour
{
    public Transform cameraTransform; // Reference to the camera's transform

    void Update()
    {
        if (cameraTransform == null) return;

        // Get the direction to the camera
        Vector3 directionToCamera = cameraTransform.position - transform.position;
        directionToCamera.y = 0; // Zero out the Y-axis to ensure only Y rotation

        // Rotate to face the camera on the Y-axis
        transform.rotation = Quaternion.LookRotation(directionToCamera);
    }
}