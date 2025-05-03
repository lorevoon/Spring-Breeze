using UnityEngine;
using UnityEngine.InputSystem;

namespace SB.Runtime {
    public class PlayerController : Singleton<PlayerController>
    {
        // References
        private PlayerMovement _playerMovement;

        // Input
        public PlayerInput Input { get; private set; }
        private InputAction _cursorPosition;

        // Grabbing
        public GrabbableController grabbed;
        private Animator _anim;

        // Animation
        private Vector2 _lastDirection = Vector2.right;
        [Header("Animations")]
        [SerializeField] private Transform _sprite;
        [SerializeField] private Transform _head;
        [SerializeField] private float _headTwistAmount = 10f;

        /// <summary>
        /// Gets the position of the mouse relative to the player.
        /// </summary>
        public Vector2 RelativeMousePosition {
            get => MousePosition - (Vector2) transform.position;
        }

        /// <summary>
        /// Gets the position of the mouse in worldspace.
        /// </summary>
        public Vector2 MousePosition {
            get => Camera.main.ScreenToWorldPoint(_cursorPosition.ReadValue<Vector2>());
        }

        override protected void Awake() {
            base.Awake();
            _playerMovement = GetComponent<PlayerMovement>();
            _anim = GetComponent<Animator>();

            Input = GetComponent<PlayerInput>();
            _cursorPosition = Input.actions["Cursor"];
        }

        private void FixedUpdate() {
            if (_playerMovement.isMoving) {
                PointTowards(_playerMovement.movementDirection);
                _anim.SetFloat("Movement", Mathf.Abs(_playerMovement.movementDirection.x));
            }
            else if (grabbed != null) {
                PointTowards((grabbed.transform.position - transform.position).normalized);
            }
        }

        /// <summary>
        /// Makes the player look towards a given direction.
        /// </summary>
        /// <param name="direction">Vector pointing in the desired direction</param>
        private void PointTowards(Vector2 direction) {
            // Head looking up or down
            _head.localRotation = Quaternion.AngleAxis(direction.y * -_headTwistAmount, Vector3.forward);

            // Looking toward the correct size
            if (Mathf.Sign(direction.x) != Mathf.Sign(_lastDirection.x)) {
                transform.localScale = new Vector3((direction.x > 0 ? -1 : 1) * 1.05f, 0.95f, 1);
            }

            // Wiggle after changing direction
            transform.localScale = Vector2.Lerp(transform.localScale, new Vector3(direction.x > 0 ? -1 : 1, 1, 1), Time.deltaTime * 5);

            // Update direction
            _lastDirection = direction;
        }
    }
}