using Tasks.Visual;
using TurnSystem.Events;
using Zenject;

namespace TurnSystem.Handlers.Visual
{
    public sealed class DeathVisualHandler : BaseHandler<DeathEvent>
    {
        [Inject]
        private readonly VisualPipeline _visualPipeline;

        protected override void HandleEvent(DeathEvent evt)
        {
            _visualPipeline.AddTask(new DeathVisualTask(evt.Entity, 0.3f));
        }
    }
}   