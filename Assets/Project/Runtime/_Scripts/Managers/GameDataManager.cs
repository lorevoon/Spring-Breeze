using System.Collections.Generic;
using UnityEngine;
using SB.SaveSystem;

namespace SB.Runtime
{
    [System.Serializable]
    public class GameData
    {
        public PlayerData playerData;
    }
    public class GameDataManager : MonoBehaviour
    {
        [SerializeField] private GameData _data;

        [ContextMenu("Load Game Data")]
        public void LoadGameData()
        {
            _data = SaveFileManager.Instance.Load(_data, "gameData");
            SaveFileManager.Instance.Bind<PlayerDataController, PlayerData>(_data.playerData);
        }

        [ContextMenu("Save Game Data")]
        public void SaveGameData()
        {
            SaveFileManager.Instance.Save(_data, "gameData");
        }

        // TODO: On region load must update loaded region data
    }
}
