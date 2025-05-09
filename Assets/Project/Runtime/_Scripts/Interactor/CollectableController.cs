using UnityEngine;
using UnityEngine.EventSystems;

namespace SB.Runtime
{
    public class CollectableController : InteractiveInstance
    {
        public override bool CanInteract => throw new System.NotImplementedException();

        protected override void OnInteract()
        {
            throw new System.NotImplementedException();
        }
    }
}
