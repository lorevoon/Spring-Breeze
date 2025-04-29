using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(PlayerSensor))]
public class GrabbableController : MonoBehaviour, IPointerClickHandler
{
    /// <summary>
    /// Text to be display in the UI that represents the action you can perform while grabbing an object
    /// </summary>
    [SerializeField] private string _interactionAlias;
    private GrabbableState _state;
    public PlayerSensor Sensor { get; private set; }
    public Animator Anim { get; private set; }

    protected virtual void Awake() {
        Sensor = GetComponent<PlayerSensor>();
        Anim = GetComponent<Animator>();

        _state = new IdleGbState(this);
    }

    /// <summary>
    /// Modifies the state of the GrabbableController. Should be provided with a new GrabbableState instance.
    /// </summary>
    public GrabbableState State {
        set {
            _state = value;
        }
    }

    void FixedUpdate() {
        _state.StateUpdate();
    }

    public void OnPointerClick(PointerEventData eventData) {
        Debug.Log("Clicked"); 
        if (eventData.button == PointerEventData.InputButton.Left) {
              
            _state.OnClick();
        }
    }
}
