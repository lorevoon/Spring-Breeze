using DG.Tweening;
using UnityEngine;

namespace SB.Runtime
{
    public class ThrowableObject : DroppableObject
    {
        public override void ClickAt(Vector2 position)
        {
            // Can't throw if something is blocking you
            if (Physics2D.OverlapPoint(position))
            {
                return;
            }

            // Move object
            transform.DOMove(PlayerController.Instance.MousePosition,
                Mathf.Sqrt(PlayerController.Instance.RelativeMousePosition.magnitude) * 0.2f)
                .SetEase(Ease.OutCubic)
                .OnComplete(() => Drop());

            PlayerController.Instance.Grabbed = null;
        }
    }
}
