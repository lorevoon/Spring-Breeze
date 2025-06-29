using UnityEngine;
using System.IO;

namespace SB.SaveSystem {
    /// <summary>
    /// Includes methods to load and save data.<br/>
    /// Saves data in json files.
    /// </summary>
    public static class SaveFileManager
    {
        /// <summary>
        /// Saves data to a json file.
        /// </summary>
        /// <typeparam name="T">Data type to save</typeparam>
        /// <param name="obj">Data to save</param>
        /// <param name="path">Path of the savefile relative to Application.persistentDataPath</param>
        public static void Save<T>(T obj, string path)
        {
            string json = JsonUtility.ToJson(obj);

            File.WriteAllText($"{Application.persistentDataPath}/{path}.json", json);
            if (Debug.isDebugBuild)
                Debug.Log($"<color=#ffff00><b>SaveSystem - Savet</b></color>\n" +
                        $"Saving data at <color=#00ff00>{path}</color> || Data stored: <color=#00ff00>{json}</color>");
        }

        /// <summary>
        /// Loads data from a json file
        /// </summary>
        /// <typeparam name="T">Data type to save</typeparam>
        /// <param name="obj">Reference to object data, if the file is not found a new file is created with current data</param>
        /// <param name="path">Path of the savefile relative to Application.persistentDataPath</param>
        /// <returns>Data loaded from the file</returns>
        public static void Load<T>(ref T obj, string path)
        {
            if (!File.Exists($"{Application.persistentDataPath}/{path}.json")) {
                if (Debug.isDebugBuild)
                    Debug.Log($"<color=#ffff00><b>SaveSystem - Load</b></color>\n " +
                            $"<b>New file </b> created at: <color=#0000ff>{Application.persistentDataPath}/{path}.json</color>");
                Save(obj, path);
            }

            string json = File.ReadAllText($"{Application.persistentDataPath}/{path}.json");
            obj = JsonUtility.FromJson<T>(json);

            if (Debug.isDebugBuild)
                Debug.Log($"<color=#ffff00><b>SaveSystem - Load</b></color>\n " +
                        $"Loading data from: <color=#0000ff>{Application.persistentDataPath}/{path}.json</color>\nData loaded: <color=#00ff00>{json}</color>");
        }
    }
}