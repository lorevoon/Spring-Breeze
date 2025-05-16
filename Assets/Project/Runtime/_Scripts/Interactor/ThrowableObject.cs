using DG.Tweening;
using UnityEngine;

namespace SB.Runtime
{
    public class ThrowableObject : GrabbableController, IInteractive
    {
        private Animator _anim;

        private void Awake() {
            _anim = GetComponent<Animator>();
        }
        
        public override void ClickAt(Vector2 position)
        {
            // Move object
            transform.DOMove(PlayerController.Instance.MousePosition, 
                Mathf.Sqrt(PlayerController.Instance.RelativeMousePosition.magnitude) * 0.2f)
                .SetEase(Ease.OutCubic)
                .OnComplete(() => Drop());
            
            PlayerController.Instance.Grabbed = null;
        }

        /// <summary>
        /// Should be called when the object is grabbed.
        /// </summary>
        void IInteractive.OnInteract()
        {
            PlayerController.Instance.Grabbed = this;
            if (PlayerController.Instance.Grabbed == this) {
                _anim.SetTrigger("Grab");
            }
        }

        /// <summary>
        /// Called when the object is dropped.
        /// </summary>
        public virtual void Drop() {
            _anim.SetTrigger("Drop");
            PlayerController.Instance.Grabbed = null;
        }
    }
}
