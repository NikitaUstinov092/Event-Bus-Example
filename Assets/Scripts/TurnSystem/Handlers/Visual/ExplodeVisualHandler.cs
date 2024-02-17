using Tasks.Visual;
using TurnSystem.Events;
using Zenject;

namespace TurnSystem.Handlers.Visual
{
    public class ExplodeVisualHandler: BaseHandler<ExplodeEvent>
    {
        [Inject]
        private readonly VisualPipeline _visualPipeline;

        protected override void HandleEvent(ExplodeEvent evt)
        {
            _visualPipeline.AddTask(new ExplodeVisualTask(evt.Entity, 2));
        }
    }
}