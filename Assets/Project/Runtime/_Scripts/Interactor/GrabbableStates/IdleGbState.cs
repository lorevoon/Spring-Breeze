using UnityEngine;

namespace SB.Runtime {
    public class IdleGbState : GrabbableState
    {
        // TODO: Figure out grabbing input
        public IdleGbState(GrabbableController grabbable) : base(grabbable) {}

        protected override void StateStart() {}

        public override void StateUpdate() {}

        public override void OnInteractWith(InteractiveInstance other) {
            // Set the state to grabbed when grabbed
            if (PlayerController.Instance.Grabbed == null && grabbable.GetComponent<PlayerSensor>().OnRange) {
                // FIXME
                //grabbable.State = new GrabbedGbState(grabbable);
            }
        }
    }
}