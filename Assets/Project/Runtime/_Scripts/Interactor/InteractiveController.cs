using UnityEngine;
using UnityEngine.Events;

namespace SB.Runtime {
    public class InteractiveController : IInteractive
    {
        [SerializeField] private UnityEvent onInteract;
        [SerializeField] private UnityEvent onHighlighted;
        [SerializeField] private UnityEvent onUnhighlighted;

        public bool CanInteract => true;

        public void OnInteract() => onInteract?.Invoke();

        public void SetHighlight(bool highlight)
        {
            if (highlight)
            {
                onHighlighted?.Invoke();
            }
            else
            {
                onUnhighlighted?.Invoke();
            }
        }
    }
}