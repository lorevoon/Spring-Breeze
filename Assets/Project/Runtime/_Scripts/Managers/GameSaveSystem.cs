using UnityEngine;
using SB.SaveSystem;
using SB.SceneManagement;

namespace SB.Runtime
{
    [System.Serializable]
    public class GameData
    {
        public PlayerData playerData;
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
