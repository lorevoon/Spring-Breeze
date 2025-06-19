using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;
using Utilities;

namespace SB.SceneManagement
{
    public class SceneTransitionManager : SingletonPersistent<SceneTransitionManager>
    {
        // Events
        public event System.Action onLoadStart;
        public event System.Action onLoadEnd;

        [SerializeField] CanvasGroup fadeScreen;

        /// <summary>
        /// Loads a new scene.
        /// </summary>
        /// <param name="id">Name of the scene to load</param>
        public void LoadScene(string id)
        {
            // TODO: Implement Transition
            LoadSceneAsync(id).GetAwaiter();
        }

        private async Task LoadSceneAsync(string id)
        {
            using (new EventStartEndDisposable(onLoadStart, onLoadEnd))
            {
                await SceneManager.LoadSceneAsync(id);
            }
        }

        public void LoadRegion(string id) => LoadRegionAsync(id).GetAwaiter();

        private async Task LoadRegionAsync(string id)
        {
            using (new EventStartEndDisposable(onLoadStart, onLoadEnd))
            {
                await SceneManager.LoadSceneAsync(id);
            }
        }
    }
}
