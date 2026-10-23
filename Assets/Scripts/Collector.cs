using System.Linq;
using UnityEngine;

public class Collector : MonoBehaviour
{
    private static readonly string[] _tagsToDestroy = new[]
    {
        "PlayerBullet",
        "Asteroid"
    };

    /// <summary>
    /// Destroys the specified game objects that the it collides with.
    /// </summary>
    /// <remarks>
    /// Don't forget to add <see cref="Rigidbody2D"/> on the game object for it to be detected upon collision.
    /// </remarks>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (_tagsToDestroy.Contains(collision.tag))
        {
            Destroy(collision.gameObject);
        }
    }
}
