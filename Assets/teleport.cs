using UnityEngine;

public class TeleportPlayer : MonoBehaviour
{
    public Vector2 teleportPosition; // Set this in the Inspector

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) // Ensure the player has the correct tag
        {
            Debug.Log("Teleporting Player to: " + teleportPosition);
            other.transform.position = teleportPosition; // Move player to new position
        }
    }
}
