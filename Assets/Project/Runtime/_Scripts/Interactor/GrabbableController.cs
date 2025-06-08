using UnityEngine;

namespace SB.Runtime {
    public abstract class GrabbableController : MonoBehaviour
    {
        /// <summary>
        /// Text to be display in the UI that represents the action you can perform while grabbing an object
        /// </summary>
        [SerializeField] private string _interactionAlias;
        

        /// <summary>
        /// The PlayerController should call the method to make the object orbit the player.
        /// </summary>
        /// <param name="relativePos">Relative mouse position to the player in worldspace metrics</param>
        public void OrbitPlayer(Vector2 relativePos) {
            Vector2 pos = relativePos.normalized;
            pos *= Mathf.Log(relativePos.magnitude * 0.5f + 1);
            pos += relativePos.normalized * 0.5f;

            // Orbit the player
            transform.position = Vector2.Lerp(transform.position, 
                (Vector2) PlayerController.Instance.transform.position + pos * new Vector2(1.2f, 0.8f), 
                Time.deltaTime * 10);
        }
        

        /// <summary>
        /// Called when there is a mouse click input at any point of the screen.
        /// </summary>
        /// <param name="position">Position where the click takes place in Worldspace.</param>
        public virtual void ClickAt(Vector2 position) {
            
        }
    }
}