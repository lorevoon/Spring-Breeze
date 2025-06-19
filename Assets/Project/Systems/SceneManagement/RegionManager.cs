using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;
using Utilities;
using Unity.Cinemachine;

namespace SB.SceneManagement
{
    public class RegionManager : Singleton<RegionManager>
    {
        [SerializeField] private string _loadedZone;
        [SerializeField] private CinemachineConfiner2D _confiner2D;

        public void LoadZone(string id, ZoneController controller)
        {
            LoadZoneAsync(id, controller).GetAwaiter();
        }

        private async Task LoadZoneAsync(string nextZone, ZoneController controller)
        {
            // Load next zone
            await SceneManager.LoadSceneAsync(nextZone, LoadSceneMode.Additive);

            // Camera transition
            _confiner2D.BoundingShape2D = controller.GetComponent<Collider2D>();
            await Task.Delay(500);

            // Unload current Zone
            if (_loadedZone != string.Empty)
            {
                await SceneManager.UnloadSceneAsync(_loadedZone);
            }

            // Set new loaded zone
            _loadedZone = nextZone;
        }
    }
}
