using UnityEngine;

public abstract class Singleton<T> : MonoBehaviour where T : MonoBehaviour {
    public static T Instance { get; private set; }
    protected virtual void Awake() {
        if (Instance != null) {
            Debug.LogWarning("Duplicate " + typeof(T) + " detected. Destroying " + gameObject.name);
            Destroy(gameObject);
        }

        Instance = this as T;
    }

    protected virtual void OnApplicationQuit() {
        Instance = null;
        Destroy(gameObject);
    }
}