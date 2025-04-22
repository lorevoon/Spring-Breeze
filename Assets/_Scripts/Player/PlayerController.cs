using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour// Singleton<PlayerController>
{
    // References
    private PlayerMovement _playerMovement;

    void Awake()
    {
        _playerMovement = GetComponent<PlayerMovement>();
    }
}
