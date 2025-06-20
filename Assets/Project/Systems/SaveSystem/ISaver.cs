using System;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace SB.SaveSystem
{
    public interface ISaver
    {
        /// <summary>
        /// Must save all binded data
        /// </summary>
        protected void Save();

        /// <summary>
        /// Must load data and bind it to all ISaveables
        /// </summary>
        protected void Load();
    }
}