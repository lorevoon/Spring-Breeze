using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    // C# Events
    public event System.Action OnSave;
    public string ID;
    public int loaded;
    
    public void OnSaveData()
    {
        if (OnSave != null)
            OnSave();
    }
}
