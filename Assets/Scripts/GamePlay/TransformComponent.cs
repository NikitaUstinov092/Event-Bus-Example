using UnityEngine;

namespace GamePlay
{
    public sealed class TransformComponent
    {
        public Transform Value { get; }

        public TransformComponent(Transform transform)
        {
            Value = transform;
        }
    }
}
