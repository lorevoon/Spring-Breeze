using System.Threading.Tasks;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using Unity.Cinemachine;

namespace SB.SceneManagement
{
    [RequireComponent(typeof(Collider2D))]
    public class ZoneController : MonoBehaviour
    {
        // Attributes
        [SerializeField] private SceneAsset _zoneScene;

        // References
        private CinemachineConfiner2D _confiner2D;
        private Collider2D _collider2D;

        private void Awake()
        {
            // Get references
            _confiner2D = FindAnyObjectByType<CinemachineConfiner2D>();
            _collider2D = GetComponent<Collider2D>();
        }

        public void LoadZone()
        {
            SceneManager.LoadSceneAsync(_zoneScene.name, LoadSceneMode.Additive)
                    .GetAwaiter()
                    .OnCompleted(()=>
                    {
                        _confiner2D.BoundingShape2D = _collider2D;
                    });
        }

        void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.transform.CompareTag("Player"))
            {
                RegionManager.Instance.LoadZone(_zoneScene.name, this);
            }
        }
    }
}
