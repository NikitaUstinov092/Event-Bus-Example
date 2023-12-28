using DG.Tweening;
using Entity;
using Entity.Components;
using UnityEngine;
using TransformComponent = GamePlay.TransformComponent;

namespace Tasks.Visual
{
    public sealed class MoveVisualTask : VisualTask
    {
        public override bool Sticky { get; protected set; }

        private readonly TransformComponent _transform;
        private readonly Vector3 _position;
        private readonly float _duration;
        
        public MoveVisualTask(IEntity entity, Vector3 position, float duration, bool sticky = false)
        {
            entity.TryGet(out PositionComponent a);
            Debug.Log(a);
            Debug.Log(entity.GetAll().Length);
            
            _transform = entity.Get<TransformComponent>();
            _position = position;
            
            _duration = duration;

            Sticky = sticky;
        }
        
        protected override void OnRun()
        {
           _transform.Value.DOMove(_position, _duration).OnComplete(Finish);
        }
        
    }
}