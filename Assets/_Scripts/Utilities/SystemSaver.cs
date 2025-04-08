using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class SystemSaver : MonoBehaviour
{
    /// <summary>
    /// Includes the <color=#ffff00>DataSave()</color> and <color=#ffff00>DataLoad()</color> methods
    /// </summary>
    public static void SaveObject<T>(T obj, string name)
    {
        string json = JsonUtility.ToJson(obj);

        name.Replace(' ', '_');
        File.WriteAllText($"{Application.persistentDataPath}/{name}.json", json );

        if (Debug.isDebugBuild)
            Debug.Log($"<color=#ffff00><b>SaveSystem - SaveObject</b></color>\n" +
                      $"Saving data at <color=#00ff00>{name}</color> || Data stored: <color=#00ff00>{json}</color>");
    }
    
    public static object LoadObject<T>(T obj, string name)
    {
        T loadedData = obj;
        name.Replace(' ', '_');
        if (File.Exists($"{Application.persistentDataPath}/{name}.json"))
        {
            string json = File.ReadAllText($"{Application.persistentDataPath}/{name}.json");
            loadedData = JsonUtility.FromJson<T>(json);

            if(Debug.isDebugBuild)
                Debug.Log($"<color=#ffff00><b>SaveSystem - LoadObject</b></color>\n " +
                          $"Loading data from: <color=#00ff00>{Application.persistentDataPath}/{name}.json</color> || Data loaded: <color=#00ff00>{json}</color>");
        }
        else
        {
            if (Debug.isDebugBuild)
                Debug.Log($"<color=#ffff00><b>SaveSystem - LoadObject</b></color>\n " +
                          $"<b>New file </b> created at: <color=#00ff00>{Application.persistentDataPath}/{name}.json</color>");
            SaveObject(obj, name);
        }

        return loadedData;
    }
}
