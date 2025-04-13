using UnityEngine;

public class Platform3 : MonoBehaviour
{
    public Transform posA, posB;
    public float speed = 5f;
    private bool hasTriggered = false;
    private bool isReturning = false;
    private PlatformCamera platformCamera;


    void Start()
    {
        if (posA == null || posB == null)
        {
            enabled = false;
            return;
        }
        transform.position = posA.position;
        //camera
        platformCamera = Camera.main.GetComponent<PlatformCamera>();
    }

    void Update()
    {
        if (hasTriggered && !isReturning)
        {
            float distance = Vector2.Distance(transform.position, posB.position);
            if (distance > 0.1f)
            {
                Vector2 newPosition = Vector2.MoveTowards(transform.position, posB.position, speed * Time.deltaTime);
                transform.position = newPosition;
            }
        }
        
        // Return to original position when player jumps off
        if (isReturning)
        {
            float distance = Vector2.Distance(transform.position, posA.position);
            if (distance > 0.1f)
            {
                Vector2 newPosition = Vector2.MoveTowards(transform.position, posA.position, speed * Time.deltaTime);
                transform.position = newPosition;
            }
            else
            {
                isReturning = false;
                hasTriggered = false; // Reset trigger so platform can be used again
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !hasTriggered)
        {
            hasTriggered = true;
            isReturning = false;
            collision.transform.SetParent(transform);
            
            // Add this to stop camera
            if (platformCamera != null)
            {
                platformCamera.StopFollowing();
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.transform.SetParent(null);
            isReturning = true;
            
            // Add this to resume camera
            if (platformCamera != null)
            {
                platformCamera.StartFollowing();
            }
        }
    }
}