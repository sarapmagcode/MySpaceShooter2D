using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerShip : MonoBehaviour
{

    [SerializeField]
    private float _moveForce = 5f;

    // Hold the Action references
    private InputAction _moveAction;

    private SpriteRenderer _spriteRenderer;

    /// <summary>
    /// Start is called once before the first execution of Update after the MonoBehaviour is created
    /// </summary>
    /// <remarks>
    /// For the new input system, refer to <see href="https://docs.unity3d.com/Packages/com.unity.inputsystem@6.7/manual/quick-start-guide.html"/>
    /// </remarks>
    private void Start()
    {
        _moveAction = InputSystem.actions.FindAction("Move");

        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        // Moving player ship with the new input system
        // Refer to https://stackoverflow.com/questions/69783710/moving-players-with-unitys-new-input-system
        Vector2 moveValue = _moveAction.ReadValue<Vector2>();
        transform.position += new Vector3(moveValue.x, moveValue.y, 0f) * _moveForce * Time.deltaTime;
        ClampPlayerOnCameraView();
    }

    /// <summary>
    /// <para>
    /// Clamps player ship on the camera view.
    /// </para>
    /// <para>
    /// For positioning objects in our world, we want to work in worldspace units.
    /// </para>
    /// </summary>
    /// <remarks>
    /// Refer to <see href="https://gamedev.stackexchange.com/questions/152500/how-to-get-camera-width-in-unity"/>
    /// </remarks>
    private void ClampPlayerOnCameraView()
    {
        Camera mainCamera = Camera.main; // Orthographic

        // Gives the vertical height of the camera in world units (the distance from
        // the center of the camera to its top).
        float cameraHalfHeight = mainCamera.orthographicSize;

        // Multiplying the camera's half height with its aspect ratio (width:height) will give us its
        // half-width in worldspace units
        float cameraHalfWidth = mainCamera.aspect * cameraHalfHeight;

        // Clamp top
        if (transform.position.y + (_spriteRenderer.bounds.size.y / 2) >= mainCamera.transform.position.y + cameraHalfHeight)
        {
            transform.position = new Vector3(
                transform.position.x,
                mainCamera.transform.position.y + cameraHalfHeight - (_spriteRenderer.bounds.size.y / 2),
                transform.position.z);
        }

        // Clamp bottom
        if (transform.position.y - (_spriteRenderer.bounds.size.y / 2) <= mainCamera.transform.position.y - cameraHalfHeight)
        {
            transform.position = new Vector3(
                transform.position.x,
                mainCamera.transform.position.y - cameraHalfHeight + (_spriteRenderer.bounds.size.y / 2),
                transform.position.z);
        }

        // Clamp left
        if (transform.position.x - (_spriteRenderer.bounds.size.x / 2) <= mainCamera.transform.position.x - cameraHalfWidth)
        {
            transform.position = new Vector3(
                mainCamera.transform.position.x - cameraHalfWidth + (_spriteRenderer.bounds.size.x / 2),
                transform.position.y,
                transform.position.z);
        }

        // Clamp right
        if (transform.position.x + (_spriteRenderer.bounds.size.x / 2) >= mainCamera.transform.position.x + cameraHalfWidth)
        {
            transform.position = new Vector3(
                mainCamera.transform.position.x + cameraHalfWidth - (_spriteRenderer.bounds.size.x / 2),
                transform.position.y,
                transform.position.z);
        }
    }
}
