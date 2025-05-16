using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace SB.Runtime {
    [RequireComponent(typeof(PlayerInput))]
    public class PlayerController : Singleton<PlayerController>
    {
        // References
        private PlayerMovement _playerMovement;

        // Input
        public PlayerInput Input { get; private set; }
        private InputAction _cursorPosition;
        private InputAction _interact;
        private InputAction _drop;

        // Interaction
        [Header("Interaction")]
        [SerializeField] private float interactionRange = 5f;
        private IInteractive _interactive;
        private IInteractive Interactive {
            get => _interactive;
            set {
                if (_interactive != value)
                {
                    _interactive?.SetHighlight(false);
                    _interactive = value;
                    _interactive?.SetHighlight(true);
                }
            }
        }

        // Grabbing
        private GrabbableController _grabbed = null;
        /// <summary>
        /// The GrabbableController of the object the player holds on his hand. Can be
        /// modified only when it's null, but it can also be set to null.
        /// </summary>
        public GrabbableController Grabbed {
            get => _grabbed;
            set {
                if (_grabbed == null || value == null) {
                    _grabbed = value;
                }
            }
        }
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
            get => MousePosition - (Vector2)transform.position;
        }

        /// <summary>
        /// Gets the position of the mouse in worldspace.
        /// </summary>
        public Vector2 MousePosition {
            get => Camera.main.ScreenToWorldPoint(_cursorPosition.ReadValue<Vector2>());
        }

        override protected void Awake()
        {
            base.Awake();

            // Components
            _playerMovement = GetComponent<PlayerMovement>();
            _anim = GetComponent<Animator>();
            Input = GetComponent<PlayerInput>();

            // Input setup
            _cursorPosition = Input.actions["Cursor"];
            _interact = Input.actions["Interact"];
            _drop = Input.actions["Drop"];

            // Input event calls
            _interact.started += context =>
            {
                Interactive?.OnInteract();
            };

            _drop.started += context =>
            {
                if (_grabbed is DroppableObject)
                {
                    (_grabbed as DroppableObject).Drop();
                }
            };

            // TODO: Implement clicking input
        }

        private void FixedUpdate()
        {
            // Movement animations
            if (_playerMovement.isMoving)
            {
                PointTowards(_playerMovement.movementDirection);
                _anim.SetFloat("Movement", Mathf.Abs(_playerMovement.movementDirection.x));
            }
            else if (_grabbed != null)
            {
                PointTowards((_grabbed.transform.position - transform.position).normalized);
            }

            // Interaction detection
            CheckInteractions();

            // Grabbing
            _grabbed?.OrbitPlayer(RelativeMousePosition);
        }

        /// <summary>
        /// Makes the player look towards a given direction.<br/>
        /// The player will flip and point its head toward the desired direction.
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

        /// <summary>
        /// Sets targeted interactivable to the nearest interactable object.
        /// </summary>
        private void CheckInteractions() {
            // Get all interactives
            // Layer 6 is reserved for interactive instances
            Collider2D[] detection = Physics2D.OverlapCircleAll(transform.position, interactionRange, 1 << 6);

            // Base case: nothing detected
            if (detection.Length == 0) {
                Interactive = null;
                return;
            }

            // Base case: only one detected
            IInteractive nextInteractive = null;
            if (detection.Length == 1) {
                nextInteractive = detection[0].GetComponent<IInteractive>();
                if (nextInteractive.CanInteract) {
                    Interactive = nextInteractive;
                }
                return;
            }

            // More than one: get closest
            float maxDist = interactionRange;
            float nextDist;
            foreach (Collider2D c in detection) {
                if (!c.GetComponent<IInteractive>().CanInteract) {
                    continue;
                }
                nextDist = Vector2.Distance(MousePosition, c.transform.position);
                if (nextDist < maxDist)
                {
                    nextInteractive = c.GetComponent<IInteractive>();
                    maxDist = nextDist;
                }
            }
            Interactive = nextInteractive;
        }
    }
}