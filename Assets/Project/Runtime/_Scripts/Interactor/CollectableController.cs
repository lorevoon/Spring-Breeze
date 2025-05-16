using UnityEngine;

namespace SB.Runtime
{
    public class CollectableController : IInteractive
    {
        [SerializeField] string itemId;

        void IInteractive.OnInteract()
        {
            // TODO: Add to inventory
        }
    }
}
