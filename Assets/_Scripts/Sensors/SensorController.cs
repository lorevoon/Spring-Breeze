using UnityEngine;
using UnityEngine.Events;

public abstract class SensorController<T> : MonoBehaviour where T : MonoBehaviour
{
    [SerializeField] private float _radius;
    public UnityEvent onArrive;
    public UnityEvent onLeave;

    private bool _onRange = false;

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

    /// <summary>
    /// Updates the value for the OnRange parameter
    /// </summary>
    public void CheckRange() {
        foreach (T other in FindObjectsByType<T>(FindObjectsSortMode.None)) {
            if (Vector2.Distance(other.transform.position, transform.position) < _radius) {
                OnRange = true;
                return;
            }
        }
        
        OnRange = false;
    }

    void OnEnable() {
        // TODO: Sensor manager
    }

    void OnDisable() {
        // TODO: Sensor manager
    }
}
