using UnityEngine;
using SB.SaveSystem;

namespace SB.Runtime
{
    [System.Serializable]
    public class GameData
    {
        public PlayerData playerData;
        public string loadedZone;
    }

    public class GameSaveSystem : MonoBehaviour
    {
        [SerializeField] private GameData data;

        void Start()
        {
            SaveFileManager.Instance.Bind<PlayerController, PlayerData>(data.playerData);
        }
    }
}
