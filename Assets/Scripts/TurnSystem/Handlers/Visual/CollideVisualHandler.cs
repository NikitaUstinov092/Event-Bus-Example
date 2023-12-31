using Entity.Components;
using Tasks.Visual;
using TurnSystem.Events;
using Zenject;

namespace TurnSystem.Handlers.Visual
{
    public sealed class CollideVisualHandler : BaseHandler<CollideEvent>
    {
        [Inject]
        private readonly VisualPipeline _visualPipeline;
        protected override void HandleEvent(CollideEvent evt)
        {
            var sourcePosition = evt.Entity.Get<PositionComponent>();
            var targetPosition = evt.Target.Get<PositionComponent>();
            var offset = (targetPosition.Value - sourcePosition.Value) * 0.5f;
            
            _visualPipeline.AddTask(new MoveVisualTask(evt.Entity, sourcePosition.Value + offset, 0.15f));
            _visualPipeline.AddTask(new MoveVisualTask(evt.Entity, sourcePosition.Value, 0.15f));
        }
    }
    
}