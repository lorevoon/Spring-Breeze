using UnityEngine;
using UnityEngine.EventSystems;

namespace SB.Runtime
{
    public abstract class InteractiveInstance : MonoBehaviour, IPointerDownHandler
    {
        private PlayerSensor sensor;

        public abstract bool CanInteract { get; }

        /// <summary>
        /// Called when the object is clicked or interacted with.
        /// </summary>
        protected abstract void OnInteract();

        protected virtual void Awake()
        {
            sensor = GetComponent<PlayerSensor>();
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            // Trigger interaction when available to be interacted with
            if (sensor.OnRange && CanInteract) {
                OnInteract();
            }
        }
    }
}
