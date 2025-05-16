using UnityEngine;
using UnityEngine.Events;

namespace SB.Runtime {
    public class InteractiveController : IInteractive
    {
        [SerializeField] private UnityEvent onInteract;

        public void OnInteract() => onInteract?.Invoke();
    }
}