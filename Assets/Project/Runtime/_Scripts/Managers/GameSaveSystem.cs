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
            data = SaveFileManager.Instance.Load(data, "./");
            SaveFileManager.Instance.Bind<PlayerController, PlayerData>(data.playerData);
            
        }

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                SaveFileManager.Instance.Save(data, "./");
            }
        }
    }
}
