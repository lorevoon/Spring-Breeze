using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

namespace SB.Runtime {
    public class InteractiveController : MonoBehaviour
    {
        [SerializeField] private UnityEvent onInteract;
        private InputAction interactAction;
        private PlayerSensor sensor;

        void Awake()
        {
            interactAction = PlayerController.Instance.Input.actions["Interact"];

            interactAction.performed += context => {
                if (sensor.OnRange) {
                    onInteract?.Invoke();
                }
            };
        }
    }
}