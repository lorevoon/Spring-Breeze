using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour// Singleton<PlayerController>
{
    

    // Dependencies
    private PlayerMovement _playerMovement;
    private PlayerPowers _playerPowers;

    // Components
    private Animator _anim;

    void Awake()
    {
        // Components
        _anim = GetComponent<Animator>();
        _playerMovement = GetComponent<PlayerMovement>();
        _playerPowers = GetComponent<PlayerPowers>();
    }

    void Update()
    {
        // Power animations and speed adjustment
        _anim.SetBool("Focused", _playerPowers.isUsingPowers);
        _playerMovement.playerSpeedMultiplier = _playerPowers.isUsingPowers ? 0.4f : 1f;
    }
}
