using UnityEngine;

[RequireComponent(typeof(PlayerSensor))]
public class GrabbableController : MonoBehaviour
{
    /// <summary>
    /// Text to be display in the UI that represents the action you can perform while grabbing an object
    /// </summary>
    [SerializeField] private string _interactionAlias;
    private GrabbableState _state;
    public PlayerSensor Sensor { get; private set; }

    protected virtual void Awake() {
        Sensor = GetComponent<PlayerSensor>();
    }

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
