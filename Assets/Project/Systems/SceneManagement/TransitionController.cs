using System.Threading.Tasks;
using UnityEngine;
using DG.Tweening;

namespace SB.SceneManagement
{
    public class TransitionController : MonoBehaviour
    {
        [SerializeField] private float _duration = 0.2f;
        [SerializeField] CanvasGroup cv;
        
        // TODO: Improve transition
        public void DoFade(float target)
        {
            cv.DOFade(target, _duration);
        }
    }
}
