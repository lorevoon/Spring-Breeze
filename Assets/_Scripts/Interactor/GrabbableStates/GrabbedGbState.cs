using UnityEditor.Rendering.LookDev;
using UnityEngine;
using UnityEngine.InputSystem;

public class GrabbedGbState : GrabbableState
{
    public GrabbedGbState(GrabbableController grabbable) : base(grabbable) {}

    private InputAction _drop;
    private InputAction _action;

    protected override void StateStart() {
        PlayerController.Instance.grabbed = grabbable;

        _action = PlayerController.Instance.Input.actions["Grab"];
        _drop = PlayerController.Instance.Input.actions["Drop"];

        _drop.started += OnDrop;
    }

    public override void StateUpdate() {
        // Orbit the player
        grabbable.transform.position = Vector2.Lerp(grabbable.transform.position, 
            (Vector2)PlayerController.Instance.transform.position + PlayerController.Instance.RelativeMousePosition.normalized * new Vector2(1.5f, 1), 
            Time.deltaTime * 10);
    }

    public override void OnClick() {}

    private void OnDrop(InputAction.CallbackContext context) {
        Debug.Log($"{grabbable.gameObject.name} Dropped");
        grabbable.State = new IdleGbState(grabbable);

        PlayerController.Instance.grabbed = null;
        _drop.started -= OnDrop;
    }
}
