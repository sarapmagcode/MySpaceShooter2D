using UnityEngine;

public class Collector : MonoBehaviour
{
    private const string PlayerBulletTag = "PlayerBullet";

    /// <summary>
    /// Destroys the specified game objects that the it collides with.
    /// </summary>
    /// <remarks>
    /// Don't forget to add <see cref="Rigidbody2D"/> on the game object for it to be detected upon collision.
    /// </remarks>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(PlayerBulletTag))
        {
            Destroy(collision.gameObject);
        }
    }
}
