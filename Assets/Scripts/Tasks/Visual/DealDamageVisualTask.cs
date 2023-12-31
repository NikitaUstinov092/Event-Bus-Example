using DG.Tweening;
using Entity;
using Entity.Components;
using GamePlay;
using UnityEngine;

namespace Tasks.Visual
{
    public sealed class DealDamageVisualTask : VisualTask
    {
        public override bool Sticky { get; protected set; } = true;
        
        private readonly TransformComponent _transform;
        private readonly float _duration;
        
        public DealDamageVisualTask(IEntity entity, float duration)
        {
            _transform = entity.Get<TransformComponent>();
            _duration = duration;
        }
        
        protected override void OnRun()
        {
            _transform.Value.DOPunchScale(Vector3.one * 1.3f, _duration, 5).OnComplete(Finish);
        }
    }
}
