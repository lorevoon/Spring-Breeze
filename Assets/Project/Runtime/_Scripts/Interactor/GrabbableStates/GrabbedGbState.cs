using UnityEngine;
using UnityEngine.InputSystem;
using DG.Tweening;

namespace SB.Runtime {
    public class GrabbedGbState : GrabbableState
    {
        public GrabbedGbState(GrabbableController grabbable) : base(grabbable) {}

        private InputAction _drop;
        private InputAction _action;

        protected override void StateStart() {
            PlayerController.Instance.Grabbed = grabbable;
        }

        public override void StateUpdate() {
            Vector2 relativePos = PlayerController.Instance.RelativeMousePosition.normalized;
            relativePos *= Mathf.Log(PlayerController.Instance.RelativeMousePosition.magnitude * 0.5f + 1);
            relativePos += PlayerController.Instance.RelativeMousePosition.normalized * 0.5f;
            // Orbit the player
            grabbable.transform.position = Vector2.Lerp(grabbable.transform.position, 
                (Vector2) PlayerController.Instance.transform.position + relativePos * new Vector2(1.2f, 0.8f), 
                Time.deltaTime * 10);
        }
    }
}