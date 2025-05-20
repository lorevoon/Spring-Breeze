using UnityEngine;
using UnityEngine.EventSystems;

namespace SB.Runtime
{
    public class DroppableObject : GrabbableController, IPointerDownHandler, IPointerEnterHandler, IPointerExitHandler
    {
        private Animator _anim;

        private void Awake() {
            _anim = GetComponent<Animator>();
        }

        /// <summary>
        /// Called when the object is grabbed.
        /// </summary>
        public void OnPointerDown(PointerEventData eventData)
        {
            // Avoid grabbing when something else is grabbed or when it's not on the ground
            if (PlayerController.Instance.Grabbed != null || !_anim.GetCurrentAnimatorStateInfo(0).IsName("Waiting"))
            {
                return;
            }
            Debug.Log("HEY");
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
            if (PlayerController.Instance.Grabbed == this)
            {
                PlayerController.Instance.Grabbed = null;
            }
            GetComponent<Collider2D>().enabled = true;
        }

        public void SetHighlight(bool highlight)
        {
            transform.Find("Sprite").localScale = highlight ? Vector2.one * 1.1f : Vector2.one;
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            SetHighlight(true);
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            SetHighlight(false);
        }
    }
}
