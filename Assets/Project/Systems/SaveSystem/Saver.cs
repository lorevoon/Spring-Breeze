using UnityEngine;
using Utilities;

namespace SB.SaveSystem
{
    public abstract class Saver<T> : Singleton<Saver<T>>
    {
        protected string relativeDataPath;
        protected T dataCollection;

        public void Bind<TData>(ISaveable<TData> saveable, ref TData data)
        {
            saveable.Bind(ref data);
        }

        public void Save()
        {
            SaveFileManager.Save(dataCollection, relativeDataPath);
        }

        public void Load()
        {
            SaveFileManager.Load(ref dataCollection, relativeDataPath);
        }
    }
}
