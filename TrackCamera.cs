using UnityEngine;

public class TrackCamera : MonoBehaviour
{
    public Transform cameraTransform; // Reference to the camera's transform
    public GameObject spriteObject; // Reference to the GameObject holding the SpriteRenderer
    public Sprite[] sprites; // Array of 8 sprites for each direction

    private SpriteRenderer spriteRenderer; // Cached reference to the SpriteRenderer

    void Start()
    {
        // Ensure the GameObject has a SpriteRenderer
        if (spriteObject != null)
        {
            spriteRenderer = spriteObject.GetComponent<SpriteRenderer>();
        }

        if (spriteRenderer == null)
        {
            Debug.LogError("SpriteRenderer component not found on the assigned GameObject!");
        }
    }

    void Update()
    {
        if (cameraTransform == null || spriteRenderer == null || sprites.Length != 8) return;

        // Get the direction to the camera
        Vector3 directionToCamera = cameraTransform.position - transform.position;
        directionToCamera.y = 0; // Zero out the Y-axis to ensure only Y rotation

        // Rotate to face the camera on the Y-axis
        transform.rotation = Quaternion.LookRotation(directionToCamera);

        // Calculate the angle on the Y-axis
        float angle = Mathf.Atan2(directionToCamera.x, directionToCamera.z) * Mathf.Rad2Deg;

        // Ensure the angle is between 0 and 360
        if (angle < 0) angle += 360;

        // Determine the sprite index based on the angle
        int spriteIndex = Mathf.FloorToInt(angle / 45) % 8; // 360° divided into 8 segments

        // Update the sprite based on the index
        spriteRenderer.sprite = sprites[spriteIndex];
    }
}