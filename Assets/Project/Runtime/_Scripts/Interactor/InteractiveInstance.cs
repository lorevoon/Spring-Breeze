using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

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
            if (sensor.OnRange && CanInteract) {
                OnInteract();
            }
        }
    }
}
