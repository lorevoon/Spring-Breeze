using UnityEngine;
using UnityEngine.InputSystem;

namespace SB.Runtime {
    [RequireComponent(typeof(PlayerInput))]
    public class PlayerMovement : MonoBehaviour
    {
        // Parameters
        [Header("Movement")]
        [SerializeField] private float _defaultPlayerSpeed = 1f;
        public float PlayerSpeed { get; private set; }
        [SerializeField] private float _movementSmooth = 2f;

        // Input
        private InputAction _moveAction;
        private Vector2 _movementVector;
        
        // Components
        private Rigidbody2D rb;

        // Properties
        /// <summary>
        /// Gets the magnitude of the player's velocity in a range of [0,1]
        /// </summary>
        public Vector2 movementDirection {
            get => _movementVector / PlayerSpeed;
        }

        public bool isMoving {
            get => _movementVector.magnitude >= 0.3f;
        }

        /// <summary>
        /// Multiplies the default player speed. Set to 1 to reset speed to default value.
        /// </summary>
        public float playerSpeedMultiplier {
            get => PlayerSpeed / _defaultPlayerSpeed;
            set => PlayerSpeed = _defaultPlayerSpeed * value;
        }

        void Awake()
        {
            // Setup components
            rb = GetComponent<Rigidbody2D>();

            // Setup input actions
            _moveAction = PlayerController.Instance.Input.actions["Move"];

            // Setup variables
            PlayerSpeed = _defaultPlayerSpeed;
        }

        void FixedUpdate()
        {
            // Smooth out movement
            _movementVector = Vector2.Lerp(_movementVector, _moveAction.ReadValue<Vector2>() * PlayerSpeed, 
                Time.fixedDeltaTime * _movementSmooth);
            rb.linearVelocity = _movementVector;
            
        }
    }
}