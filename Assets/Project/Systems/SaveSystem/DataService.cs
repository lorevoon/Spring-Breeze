using UnityEngine;
using System.IO;
using Utilities;
using System;

namespace SB.SaveSystem
{
    internal class DataService
    {
        [SerializeField] private int _fileId;

        public DataService(int fileId)
        {
            _fileId = fileId;
        }

        /// <summary>
        /// Saves data to a json file.
        /// </summary>
        /// <typeparam name="T">Data type to save</typeparam>
        /// <param name="obj">Data to save</param>
        /// <param name="path">Path of the savefile relative to Application.persistentDataPath</param>
        public void Save<T>(T obj, string path)
        {
            string json = JsonUtility.ToJson(obj);

            File.WriteAllText($"{Application.persistentDataPath}/{_fileId}/{path}.json", json);
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
        public T Load<T>(T obj, string path)
        {
            if (!File.Exists($"{Application.persistentDataPath}/{path}.json"))
            {
                if (Debug.isDebugBuild)
                    Debug.Log($"<color=#ffff00><b>SaveSystem - Load</b></color>\n " +
                            $"<b>New file </b> created at: <color=#00ff00>{Application.persistentDataPath}/{path}.json</color>");
                Save(obj, path);
            }

            string json = File.ReadAllText($"{Application.persistentDataPath}/{path}.json");
            obj = JsonUtility.FromJson<T>(json);

            if (Debug.isDebugBuild)
                Debug.Log($"<color=#ffff00><b>SaveSystem - Load</b></color>\n " +
                        $"Loading data from: <color=#00ff00>{Application.persistentDataPath}/{path}.json</color>\nData loaded: <color=#00ff00>{json}</color>");

            return obj;
        }
    }
}
