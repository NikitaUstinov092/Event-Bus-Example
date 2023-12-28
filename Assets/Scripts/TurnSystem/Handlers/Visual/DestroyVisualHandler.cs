using Tasks.Visual;
using TurnSystem.Events;
using Zenject;

namespace TurnSystem.Handlers.Visual
{
    public sealed class DestroyVisualHandler : BaseHandler<DestroyEvent>
    {
        [Inject]
        private readonly VisualPipeline _visualPipeline;

        protected override void HandleEvent(DestroyEvent evt)
        {
            _visualPipeline.AddTask(new DestroyVisualTask(evt.Entity, 0.3f));
        }
    }
}