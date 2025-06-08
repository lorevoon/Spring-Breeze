using UnityEngine;

namespace SB.Runtime
{
    public class CollectableController : IInteractive
    {
        [SerializeField] string itemId;

        public bool CanInteract => true;

        public void SetHighlight(bool highlight)
        {
            throw new System.NotImplementedException();
        }

        void IInteractive.OnInteract()
        {
            // TODO: Add to inventory
        }
    }
}
