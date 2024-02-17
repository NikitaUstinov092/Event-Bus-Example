using DG.Tweening;
using Entity;
using Entity.Components;
using Tasks.Visual;
using UnityEngine;

namespace TurnSystem.Handlers.Visual
{
    public class ExplodeVisualTask: VisualTask
    {
        public override bool Sticky { get; protected set; } = false;
        
        private readonly TransformComponent _transform;
        private readonly float _duration;
        public ExplodeVisualTask(IEntity entity, float duration)
        {
            _transform = entity.Get<TransformComponent>();
            _duration = duration;
        }
        protected override void OnRun()
        {
            var originalScale = _transform.Value.localScale;
            
            _transform.Value.DOScale(originalScale * 3, _duration / 2f)
                .SetEase(Ease.OutQuad) 
                .OnComplete(() =>
                {
                    _transform.Value.DOScale(Vector3.zero, 0)
                        .SetEase(Ease.InQuad) 
                        .OnComplete(Finish);
                });
        }
    }
}