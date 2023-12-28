using Level;
using Tasks.Visual;
using TurnSystem.Events;
using Zenject;

namespace TurnSystem.Handlers.Visual
{
    public sealed class MoveVisualHandler : BaseHandler<MoveEvent>
    {
        private VisualPipeline _visualPipeline;
        private LevelMap _levelMap;
        
        [Inject]
        public void Construct(VisualPipeline visualPipeline, LevelMap levelMap)
        {
            _visualPipeline = visualPipeline;
            _levelMap = levelMap;
        }

        protected override void HandleEvent(MoveEvent evt)
        {
            var targetPosition = _levelMap.Tiles.CoordinatesToPosition(evt.Coordinates);
            _visualPipeline.AddTask(new MoveVisualTask(evt.Entity, targetPosition, 0.3f, evt.IsForced));
        }
    }
}