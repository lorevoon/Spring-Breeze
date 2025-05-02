using UnityEngine;
using UnityEngine.Events;

public abstract class SensorController : MonoBehaviour
{
    [SerializeField] protected float radius;
    public UnityEvent onArrive;
    public UnityEvent onLeave;

    private bool _onRange = false;

    protected abstract bool IsDetection { get; }

    /// <summary>
    /// Checks if the desired object is on range
    /// </summary>
    public bool OnRange { 
        get => _onRange;
        private set {
            // Check for calling events
            if (value == true && _onRange == false) {
                onArrive?.Invoke();
            }
            if (value == false && _onRange == true) {
                onLeave?.Invoke();
            }
            // Modify value
            _onRange = value;
        }
    }

    private void FixedUpdate()
    {
        OnRange = IsDetection;
    }
}
