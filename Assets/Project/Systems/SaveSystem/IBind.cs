using System;

namespace SB.SaveSystem
{
    public interface IBind<TData> where TData : ISaveable
    {
        string id { get; set; }
        public void Bind(TData data);
    }
}