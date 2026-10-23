using System.Collections;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class AsteroidSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject[] _asteroidReference;

    private GameObject _spawnedAsteroid;

    private BoxCollider2D _collider;

    private void Start()
    {
        _collider = GetComponent<BoxCollider2D>();

        StartCoroutine(SpawnAsteroids());
    }

    private IEnumerator SpawnAsteroids()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(1, 5));

            _spawnedAsteroid = Instantiate(_asteroidReference[0]);
            float asteroidRadiusWithOffset = _spawnedAsteroid.GetComponent<CircleCollider2D>().radius + 0.3f;

            // Randomized y-position of spawned asteroid based on the collector's height (and making
            // sure the asteroid doesn't go out of spawner bounds)
            _spawnedAsteroid.transform.position = new Vector3(
                transform.position.x,
                Random.Range(
                    -(_collider.size.y / 2) + asteroidRadiusWithOffset, // Topmost
                    (_collider.size.y / 2) - asteroidRadiusWithOffset), // Bottommost
                transform.position.z);
        }
    }
}
