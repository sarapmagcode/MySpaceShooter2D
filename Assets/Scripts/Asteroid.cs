using UnityEngine;

public class Asteroid : MonoBehaviour
{
    [SerializeField]
    private float _rotationValue = 0.175f;

    [SerializeField]
    private float _speed = 5f;

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(_speed * Time.deltaTime * -1, 0, 0);
        transform.Rotate(new Vector3(0, 0, _rotationValue));
    }
}
