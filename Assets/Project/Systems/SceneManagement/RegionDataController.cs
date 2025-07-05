using UnityEngine;
using Utilities;
using SB.SaveSystem;

namespace SB.SceneManagement
{
    [System.Serializable]
    public class RegionData : ISaveable
    {
        public string id { get; set; }
        public string loadedRegion;
        public string loadedZone;
    }

    public class RegionDataController : SingletonPersistent<RegionDataController>, IBind<RegionData>
    {
        public string id { get => gameObject.name; set => gameObject.name = value; }
        private RegionData _data;
        public RegionData Data { get => _data; }

        public void Bind(RegionData data)
        {
            // Load data
            _data = data;
        }

        // Must update region data when region is changed or when zone is changed
        void OnEnable()
        {
            // Add event listeners here
        }

        void OnDisable()
        {
            // Remove event listeners here just in case
        }
    }
}
