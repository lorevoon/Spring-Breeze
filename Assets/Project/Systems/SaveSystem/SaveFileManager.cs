using UnityEngine;
using System.IO;
using System.Collections.Generic;
using Utilities;
using System.Linq;

namespace SB.SaveSystem {
    /// <summary>
    /// Includes methods to load and save data.<br/>
    /// Saves data in json files.
    /// </summary>
    public class SaveFileManager : SingletonPersistent<SaveFileManager>
    {
        /// <summary>
        /// Saves data to a json file.
        /// </summary>
        /// <typeparam name="T">Data type to save</typeparam>
        /// <param name="obj">Data to save</param>
        /// <param name="path">Path of the savefile relative to Application.persistentDataPath</param>
        public void Save<T>(T obj, string path)
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
        
        public void Bind<T, TData>(TData data) where T : MonoBehaviour, IBind<TData> where TData : ISaveable, new()
        {
            var entity = FindObjectsByType<T>(FindObjectsSortMode.None).FirstOrDefault();

            if (entity != null)
            {
                if (data == null)
                {
                    data = new TData { id = entity.id };
                }
                entity.Bind(data);
            }
        }

        public void Bind<T, TData>(List<TData> datas) where T : MonoBehaviour, IBind<TData> where TData : ISaveable, new()
        {
            var entities = FindObjectsByType<T>(FindObjectsSortMode.None);

            foreach (var entity in entities)
            {
                var data = datas.FirstOrDefault(d => d.id == entity.id);
                if (data == null)
                {
                    data = new TData { id = entity.id };
                    datas.Add(data);
                }
            }
        }
    }
}