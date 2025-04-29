using UnityEditor.Rendering.LookDev;
using UnityEngine;
using UnityEngine.InputSystem;
using DG.Tweening;

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
        _action.started += OnAction;

        grabbable.Anim.SetTrigger("Grab");
    }

    public override void StateUpdate() {
        Vector2 relativePos = PlayerController.Instance.RelativeMousePosition.normalized;
        relativePos += PlayerController.Instance.RelativeMousePosition * 0.15f;
        // Orbit the player
        grabbable.transform.position = Vector2.Lerp(grabbable.transform.position, 
            (Vector2) PlayerController.Instance.transform.position + relativePos * new Vector2(1.2f, 0.8f), 
            Time.deltaTime * 10);
    }

    public override void OnClick() {}

    private void OnDrop(InputAction.CallbackContext context) {
        Debug.Log($"{grabbable.gameObject.name} Dropped");
        grabbable.State = new IdleGbState(grabbable);

        grabbable.Anim.SetTrigger("Drop");

        PlayerController.Instance.grabbed = null;
        _drop.started -= OnDrop;
    }

    // TODO: This behaviour is temporary, modify later on
    private void OnAction(InputAction.CallbackContext context) {
        if (PlayerController.Instance.RelativeMousePosition.magnitude > 8) {
            return;
        }

        Debug.Log($"{grabbable.gameObject.name} Action");
        grabbable.State = new IdleGbState(grabbable);

        grabbable.Anim.SetTrigger("Drop");

        PlayerController.Instance.grabbed = null;

        grabbable.transform.DOMove(PlayerController.Instance.MousePosition, 0.25f).SetEase(Ease.Linear);

        _action.started -= OnAction;
    }
}
