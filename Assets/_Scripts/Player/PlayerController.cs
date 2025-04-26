using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : Singleton<PlayerController>
{
    // References
    private PlayerMovement _playerMovement;

    // Input
    public PlayerInput Input { get; private set; }
    private InputAction _cursorPosition;

    // Grabbing
    public GrabbableController grabbed;

    /// <summary>
    /// Gets the position of the mouse relative to the player.
    /// </summary>
    public Vector2 RelativeMousePosition {
        get => Camera.main.ScreenToWorldPoint(_cursorPosition.ReadValue<Vector2>()) - transform.position;
    }

    override protected void Awake() {
        base.Awake();
        _playerMovement = GetComponent<PlayerMovement>();

        Input = GetComponent<PlayerInput>();
        _cursorPosition = Input.actions["Cursor"];
    } 
}
