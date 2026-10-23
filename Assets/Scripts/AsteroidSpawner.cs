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

            // Randomize asteroid type
            int randomIndex = Random.Range(0, _asteroidReference.Length);
            _spawnedAsteroid = Instantiate(_asteroidReference[randomIndex]);

            // Randomized y-position of spawned asteroid based on the collector's height (and making
            // sure the asteroid doesn't go out of spawner bounds)
            float asteroidRadiusWithOffset = _spawnedAsteroid.GetComponent<CircleCollider2D>().radius + 0.3f;

            _spawnedAsteroid.transform.position = new Vector3(
                transform.position.x,
                Random.Range(
                    -(_collider.size.y / 2) + asteroidRadiusWithOffset, // Topmost
                    (_collider.size.y / 2) - asteroidRadiusWithOffset), // Bottommost
                transform.position.z);
        }
    }
}
