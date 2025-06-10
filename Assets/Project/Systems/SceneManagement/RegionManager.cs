using System;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;
using Utilities;

namespace SB.SceneManagement
{
    public class RegionManager : Singleton<RegionManager>
    {
        private ZoneController _loadedZone;

        public event Action onZoneLoadStart;
        public event Action onZoneLoadEnd;

        public void LoadZone(string id)
        {
            LoadZoneAsync(id).GetAwaiter();
        }

        private async Task LoadZoneAsync(string id)
        {
            using (new EventStartEndDisposable(onZoneLoadStart, onZoneLoadEnd))
            {
                // Save zone data
                _loadedZone.SaveZoneData().GetAwaiter();

                // Load the scene
                await SceneManager.LoadSceneAsync(id, LoadSceneMode.Additive);

                // Set new zone as active scene
                Scene newZone = SceneManager.GetSceneByName(id);
                SceneManager.SetActiveScene(newZone);

                // Unload last scene
                await SceneManager.UnloadSceneAsync(id);
            }
        }
    }
}
