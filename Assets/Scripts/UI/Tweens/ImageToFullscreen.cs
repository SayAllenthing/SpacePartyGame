using UnityEngine;
using UnityEngine.UI;
using System.Collections;

namespace Tweens
{
    public class ImageToFullscreen : TimedAction
    {
        RectTransform target;

        Vector3 InitialPos;
        Vector2 InitialSize;

        public void Init(RectTransform _target, float _duration = 1)
        {
            target = _target;
            duration = _duration;
        }

        protected override void preAction()
        {
            InitialPos = target.position;
            InitialSize = target.sizeDelta;
        }

        protected override void HandleAction(float progress)
        {
            target.position = Vector3.Lerp(InitialPos, Vector3.zero, progress);
            target.sizeDelta = Vector2.Lerp(InitialSize, new Vector2(1330, 750), progress);
        }

        protected override void postAction()
        {
        }
    }
}