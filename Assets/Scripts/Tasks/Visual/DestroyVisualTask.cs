using DG.Tweening;
using Entity;
using Entity.Components;
using GamePlay;
using UnityEngine;

namespace Tasks.Visual
{
    public sealed class DestroyVisualTask : VisualTask
    {
        public override bool Sticky { get; protected set; } = false;
        
        private readonly TransformComponent _transform;
        private readonly float _duration;
        
        public DestroyVisualTask(IEntity entity, float duration)
        {
            _transform = entity.Get<TransformComponent>();
            _duration = duration;
        }
        
        protected override void OnRun()
        {
            _transform.Value.DOScale(Vector3.zero, _duration).OnComplete(Finish);
        }
    }
}