using UnityEngine;
using SB.SaveSystem;

namespace SB.Runtime
{
    public struct GameData
    {
        public Vector3 playerPos { get; set; }
        public string loadedZone { get; set; }
    }

    public class GameSaveSystem : Saver<GameData>
    {
        protected override void Awake()
        {
            base.Awake();

            Load();
        }
    }
}
