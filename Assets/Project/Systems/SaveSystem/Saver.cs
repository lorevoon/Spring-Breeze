using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Utilities;
/*
namespace SB.SaveSystem
{
    public abstract class Saver : Singleton<Saver> 
    {
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

        void Bind<T, TData>(List<TData> datas) where T : MonoBehaviour, IBind<TData> where TData : ISaveable, new()
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
}*/
