using UnityEngine;
using System.Collections;

namespace Tweens
{
    public class MoveTransformToTransform : TimedAction
    {
        Transform target;
        Transform destination;

        Vector3 InitialPosition;
        Quaternion InititialRotation;

        float apex;

        float prevProg;

        public void Init(Transform _target, Transform _destination, float _duration = 1)
        {
            target = _target;
            destination = _destination;
            duration = _duration;
        }

        protected override void preAction()
        {
            InitialPosition = target.position;
            InititialRotation = target.rotation;
        }

        protected override void HandleAction(float progress)
        {
            target.position = Vector3.Lerp(InitialPosition, destination.position, progress);
            target.rotation = Quaternion.Slerp(InititialRotation, destination.rotation, progress);
        }

        protected override void postAction()
        {
        }
    }
}