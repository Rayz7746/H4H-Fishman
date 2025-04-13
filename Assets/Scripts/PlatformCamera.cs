using UnityEngine;

public class PlatformCamera : MonoBehaviour
{
    private bool shouldFollow = true;
    public Transform player;
    public float verticalOffset = 0.5f;
    
    // Add these new variables
    [Header("Camera Bounds")]
    public float minX = -10f;  // Leftmost point camera can see
    public float maxX = 30f;   // Rightmost point camera can see
    public float minY = -5f;   // Lowest point camera can see
    public float maxY = 10f;   // Highest point camera can see

    private Camera cam;

    void Start()
    {
        cam = GetComponent<Camera>();
        if (cam == null) cam = Camera.main;
        
        // Ensure camera is orthographic
        cam.orthographic = true;
        
        // Set a larger orthographic size to see more of the scene
        cam.orthographicSize = 5f;
    }

    void Update()
    {
        if (shouldFollow)
        {
            // Calculate desired position
            float targetX = Mathf.Clamp(player.position.x, minX, maxX);
            float targetY = Mathf.Clamp(player.position.y + verticalOffset, minY, maxY);
            
            // Update camera position with clamped values
            transform.position = new Vector3(targetX, targetY, transform.position.z);
        }
    }

    public void StopFollowing()
    {
        shouldFollow = false;
    }

    public void StartFollowing()
    {
        shouldFollow = true;
    }
}