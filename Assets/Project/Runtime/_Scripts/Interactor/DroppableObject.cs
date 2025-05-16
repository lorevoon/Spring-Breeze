using UnityEngine;

namespace SB.Runtime
{
    public class DroppableObject : GrabbableController, IInteractive
    {
        private Animator _anim;

        public bool CanInteract => PlayerController.Instance.Grabbed == null;

        private void Awake() {
            _anim = GetComponent<Animator>();
        }

        /// <summary>
        /// Should be called when the object is grabbed.
        /// </summary>
        void IInteractive.OnInteract()
        {
            PlayerController.Instance.Grabbed = this;
            if (PlayerController.Instance.Grabbed == this)
            {
                _anim.SetTrigger("Grab");
            }
            GetComponent<Collider2D>().enabled = false;
        }

        /// <summary>
        /// Called when the object is dropped.
        /// </summary>
        public virtual void Drop()
        {
            _anim.SetTrigger("Drop");
            PlayerController.Instance.Grabbed = null;
            GetComponent<Collider2D>().enabled = true;
        }

        public void SetHighlight(bool highlight)
        {
            transform.localScale = highlight ? Vector2.one * 1.1f : Vector2.one;
        }
    }
}
