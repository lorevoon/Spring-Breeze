using DG.Tweening;
using UnityEngine;

namespace SB.Runtime
{
    public class ThrowableObject : GrabbableController
    {
        public override void InteractWith(InteractiveInstance interaction)
        {
            // Throw only at empty spaces
            if (interaction != null && interaction != this) {
                return;
            }

            // Move object
            transform.DOMove(PlayerController.Instance.MousePosition, 
                Mathf.Sqrt(PlayerController.Instance.RelativeMousePosition.magnitude) * 0.2f)
                .SetEase(Ease.OutCubic)
                .OnComplete(() => Drop());
            
            PlayerController.Instance.Grabbed = null;
        }
    }
}
