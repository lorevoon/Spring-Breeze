using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// Manages the player's different powers and habilities.
/// </summary>
public class PlayerPowers : MonoBehaviour
{
    // Parameters
    [SerializeField] private float _interactionRad = 1f;

    // Input
    private PlayerInput _playerInput;
    private InputAction _cursor;
    private InputAction _sunAction;
    private InputAction _cloudAction;
    private Vector2 _mousePos { 
        get => Camera.main.ScreenToWorldPoint(_cursor.ReadValue<Vector2>());
    }

    // Properties
    public bool isUsingPowers {
        get => _sunAction.IsPressed() || _cloudAction.IsPressed();
    }

    void Awake()
    {
        // Components
        _playerInput = GetComponent<PlayerInput>();

        // Input actions
        // TODO: Update action map
        _cursor = _playerInput.actions["Cursor"];
        _sunAction = _playerInput.actions["Sun"];
        _cloudAction = _playerInput.actions["Cloud"];

        // TODO: Implement cloud
        _sunAction.started += context => {
            // Show sun
        };

        _sunAction.performed += context => {
            InteractAtCursor(EInteraction.Light);
        };

        _sunAction.canceled += context => {
            // Hide sun
        };

        _cloudAction.started += context => {
            // Show cloud
        };

        _cloudAction.performed += context => {
            InteractAtCursor(EInteraction.Water);
        };

        _cloudAction.canceled += context => {
            // Hide cloud
        };
    }

    /// <summary>
    /// Triggers an interaction with all Interactors in range from the mouse position.
    /// </summary>
    /// <param name="type">Type of the interactor</param>
    private void InteractAtCursor(EInteraction type) {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(_mousePos, _interactionRad);
        
        foreach (Collider2D c in colliders) {
            c.TryGetComponent(out Interactor interactor); {
                interactor.Interact(type);
            }
        }
        
    }
}
