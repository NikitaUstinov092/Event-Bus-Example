using Entity.Components;
using Level;
using Tasks.Visual;
using TurnSystem.Events;
using Zenject;

namespace TurnSystem.Handlers.Visual
{
    public sealed class CollideVisualHandler : BaseHandler<CollideEvent>
    {
        private VisualPipeline _visualPipeline;
        private LevelMap _levelMap;

        [Inject]
        private void Construct(VisualPipeline visualPipeline, LevelMap levelMap)
        {
            _visualPipeline = visualPipeline;
            _levelMap = levelMap;
        }
        protected override void HandleEvent(CollideEvent evt)
        {
            var sourcePosition = evt.Entity.Get<PositionComponent>();
            var targetCoordinates = evt.Target.Get<CoordinatesComponent>();
            var targetPosition = _levelMap.Tiles.CoordinatesToPosition(targetCoordinates.Value);
            
            _visualPipeline.AddTask(new MoveVisualTask(evt.Entity, targetPosition, 0.15f));
            _visualPipeline.AddTask(new MoveVisualTask(evt.Entity, sourcePosition.Value, 0.15f));
        }
    }
    
}