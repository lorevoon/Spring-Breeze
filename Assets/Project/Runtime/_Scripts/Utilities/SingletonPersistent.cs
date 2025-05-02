using UnityEngine;

/// <summary>
/// SingletonPersisten will call DontDestroyOnLoad on Awake.
/// </summary>
public abstract class SingletonPersistent<T> : Singleton<T> where T : MonoBehaviour
{
    protected override void Awake()
    {
        base.Awake();
        DontDestroyOnLoad(gameObject);
    }
}
