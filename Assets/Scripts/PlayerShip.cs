using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerShip : MonoBehaviour
{
    // Hold the Action references
    InputAction moveAction;

    [SerializeField]
    private float _moveForce = 5f;

    /// <summary>
    /// Start is called once before the first execution of Update after the MonoBehaviour is created
    /// </summary>
    /// <remarks>
    /// For the new input system, refer to <see href="https://docs.unity3d.com/Packages/com.unity.inputsystem@6.7/manual/quick-start-guide.html"/>
    /// </remarks>
    private void Start()
    {
        moveAction = InputSystem.actions.FindAction("Move");
    }

    // Update is called once per frame
    void Update()
    {
        // Moving player ship with the new input system
        // Refer to https://stackoverflow.com/questions/69783710/moving-players-with-unitys-new-input-system
        Vector2 moveValue = moveAction.ReadValue<Vector2>();
        transform.position += new Vector3(moveValue.x, moveValue.y, 0f) * _moveForce * Time.deltaTime;
    }
}
