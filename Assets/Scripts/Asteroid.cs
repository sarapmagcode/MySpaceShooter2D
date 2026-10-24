using System.Collections;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    [SerializeField]
    private float _rotationValue = 0.175f;

    [SerializeField]
    private HealthBar _healthBar;

    private int _maxHealth = 100;
    private int _currentHealth;

    private void Start()
    {
        _currentHealth = _maxHealth;
        _healthBar.SetMaxHealth(_maxHealth);

        StartCoroutine(TakeDamage(15)); // TODO: Remove this
    }

    // Update is called once per frame
    private void Update()
    {
        transform.Rotate(new Vector3(0, 0, _rotationValue));
    }

    private IEnumerator TakeDamage(int damage)
    {
        while (true)
        {
            yield return new WaitForSeconds(1);

            _currentHealth -= damage;
            _healthBar.SetHealth(_currentHealth);
        }
    }
}
