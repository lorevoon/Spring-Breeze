using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// Manages the player's different powers and habilities.
/// </summary>
public class PlayerPowers : MonoBehaviour
{
    // Input
    private PlayerInput _playerInput;
    private InputAction _sunAction;
    private InputAction _cloudAction;

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
        _sunAction = _playerInput.actions["Sun"];
        _cloudAction = _playerInput.actions["Cloud"];

        // TODO: Implement cloud
        _sunAction.started += context => {
            // Show sun
        };

        _sunAction.canceled += context => {
            // Hide sun
        };

        _cloudAction.started += context => {
            // Show cloud
        };

        _cloudAction.canceled += context => {
            // Hide cloud
        };
    }
}
