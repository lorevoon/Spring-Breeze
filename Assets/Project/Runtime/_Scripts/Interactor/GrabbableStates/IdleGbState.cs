using UnityEngine;

namespace SB.Runtime {
    public class IdleGbState : GrabbableState
    {
        public IdleGbState(GrabbableController grabbable) : base(grabbable) {}

        protected override void StateStart() {}

        public override void StateUpdate() {}
    }
}