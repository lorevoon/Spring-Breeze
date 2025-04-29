using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class IdleGbState : GrabbableState
{
    // TODO: Figure out grabbing input
    public IdleGbState(GrabbableController grabbable) : base(grabbable) {}

    protected override void StateStart() {}

    public override void StateUpdate() {}

    public override void OnClick() {
        // Set the state to grabbed when grabbed
        if (PlayerController.Instance.grabbed == null && grabbable.GetComponent<PlayerSensor>().OnRange) {
            grabbable.State = new GrabbedGbState(grabbable);
        }
    }
}
