using UnityEngine;

public class AsteroidContainer : MonoBehaviour
{
    [SerializeField]
    private float _speed = 5f;

    // Update is called once per frame
    private void Update()
    {
        transform.position += new Vector3(_speed * Time.deltaTime * -1, 0, 0);
    }
}
