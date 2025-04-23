using UnityEditor.Rendering.LookDev;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(PlayerInput))]
public class PlayerMovement : MonoBehaviour
{
    // Parameters
    [Header("Movement")]
    [SerializeField] private float _defaultPlayerSpeed = 1f;
    private float _playerSpeed;
    [SerializeField] private float _movementSmooth = 2f;
    [Header("Animations")]
    [SerializeField] private Transform _head;
    [SerializeField] private float _headTwistAmount = 10f;

    // Input
    private PlayerInput _input;
    private InputAction _moveAction;
    private Vector2 _movementVector;
    
    // Components
    private Rigidbody2D rb;
    private Animator anim;

    // Animation
    private float _direction = 1;

    // Properties
    /// <summary>
    /// Gets the magnitude of the player's velocity in a range of [0,1]
    /// </summary>
    public Vector2 movementDirection {
        get => _movementVector / _playerSpeed;
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
        anim.SetFloat("Movement", Mathf.Abs(_movementVector.x) / _playerSpeed);

        // Head looking up or down
        _head.localRotation = Quaternion.AngleAxis(movementDirection.y * -_headTwistAmount, Vector3.forward);

        // Looking toward the correct size
        int newDirection =  movementDirection.x > 0 ? -1 : 1;
        if (_direction != newDirection) {
            _direction = newDirection;
            transform.localScale = new Vector3(_direction * 1.05f, 0.95f, 1);
        }

        // TODO: This animation shouldn't be procedural
        transform.localScale = Vector2.Lerp(transform.localScale, new Vector3(_direction, 1, 1), Time.deltaTime * 5);
    }
}
