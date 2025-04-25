using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : Singleton<PlayerController>
{
    // References
    private PlayerMovement _playerMovement;
    public PlayerInput Input { get; private set; }

    override protected void Awake() {
        base.Awake();
        _playerMovement = GetComponent<PlayerMovement>();
        Input = GetComponent<PlayerInput>();
    } 
}
