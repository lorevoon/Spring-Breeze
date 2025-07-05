using System.Collections.Generic;
using UnityEngine;
using SB.SaveSystem;

namespace SB.Runtime
{
    [System.Serializable]
    public class PlayerData : ISaveable
    {
        public string id { get; set; }
        public Vector2 position;
        public List<string> inventory;
    }

    public class PlayerDataController : MonoBehaviour, IBind<PlayerData>
    {
        public string id { get => gameObject.name; set => gameObject.name = value; }
        private PlayerData _data;
        public PlayerData Data { get => _data; }
        public List<string> Inventory { get => _data.inventory; set => _data.inventory = value; }

        public void Bind(PlayerData data)
        {
            // Update data reference
            _data = data;

            // Load current data
            transform.position = _data.position;
        }

        void FixedUpdate()
        {
            if (_data != null)
            {
                _data.position = transform.position;
            }
        }

        // TODO: Add data update on inventory
    }
}
