using UnityEngine;
using UnityEngine.UI;
using System.Collections;

namespace Tweens
{
    public class CanvasGroupAlphaTween : TimedAction
    {
        CanvasGroup target;

        float InitialAlpha;
        float TargetAlpha;

        public void Init(CanvasGroup _target, float _targetAlpha = 1, float _duration = 1)
        {
            target = _target;
            TargetAlpha = _targetAlpha;
            duration = _duration;
        }

        protected override void preAction()
        {
            InitialAlpha = target.alpha;
        }

        protected override void HandleAction(float progress)
        {
            target.alpha = Mathf.Lerp(InitialAlpha, TargetAlpha, progress);
        }

        protected override void postAction()
        {
        }
    }
}


