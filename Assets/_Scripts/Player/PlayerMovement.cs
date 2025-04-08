using UnityEditor.Rendering.LookDev;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(PlayerInput))]
public class PlayerMovement : MonoBehaviour
{
    // Parameters
    [SerializeField] private float _defaultPlayerSpeed = 1f;
    private float _playerSpeed;
    [SerializeField] private float _movementSmooth = 2f;

    // Input
    private PlayerInput _input;
    private InputAction _moveAction;
    private Vector2 _movementVector;
    
    // Components
    private Rigidbody2D rb;
    private Animator anim;

    // Properties
    /// <summary>
    /// Gets the magnitude of the player's velocity in a range of [0,1]
    /// </summary>
    public float movementAmount {
        get => _movementVector.magnitude / _playerSpeed;
    }

    public bool isMoving {
        get => _movementVector != Vector2.zero;
    }

    /// <summary>
    /// Multiplies the default player speed. Set to 1 to reset speed to default value.
    /// </summary>
    public float playerSpeedMultiplier {
        get => _playerSpeed /  _defaultPlayerSpeed;
        set => _playerSpeed = _defaultPlayerSpeed * value;
    }

    void Awake()
    {
        // Setup components
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        // Setup input actions
        _input = GetComponent<PlayerInput>();
        _moveAction = _input.actions["Move"];

        // Setup variables
        _playerSpeed = _defaultPlayerSpeed;
    }

    void FixedUpdate()
    {
        // Smooth out movement
        _movementVector = Vector2.Lerp(_movementVector, _moveAction.ReadValue<Vector2>() * _playerSpeed, 
            Time.fixedDeltaTime * _movementSmooth);
        rb.linearVelocity = _movementVector;
        anim.SetFloat("Movement", movementAmount);

        // Face towards movement
        transform.localScale = new Vector3(_movementVector.x > 0 ? -1 : 1, 1, 1);
    }
}
