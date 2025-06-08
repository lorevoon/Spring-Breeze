using UnityEngine;
namespace SB.Runtime {
    public interface IInteractive
    {
        /// <summary>
        /// This is a ver important thing that does stuff.<br/>
        /// Arioch.
        /// </summary>
        public void OnInteract();

        /// <summary>
        /// Returns whether it is possible to interact with the object or not.
        /// </summary>
        public bool CanInteract { get; }

        /// <summary>
        /// Triggers highlighting animation when the object can be interacted with by the player.<br/>
        /// 
        /// </summary>
        /// <param name="highlight">Display or hide highlight</param>
        public void SetHighlight(bool highlight);
    }
}