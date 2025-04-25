using UnityEngine;

public class GrabbableController : MonoBehaviour
{
    /// <summary>
    /// Text to be display in the UI that represents the action you can perform while grabbing an object
    /// </summary>
    [SerializeField] string interactionAlias;
    GrabbableState _state;

    /// <summary>
    /// Modifies the state of the GrabbableController. Should be provided with a new GrabbableState instance.
    /// </summary>
    public GrabbableState State {
        set {
            _state = value;
        }
    }

    void Update()
    {
        _state.StateUpdate();
    }
}
