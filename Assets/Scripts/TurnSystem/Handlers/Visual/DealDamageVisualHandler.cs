using Tasks.Visual;
using TurnSystem.Events;
using Zenject;

namespace TurnSystem.Handlers.Visual
{
    public class DealDamageVisualHandler : BaseHandler<DealDamageEvent>
    {
        [Inject]
        private readonly VisualPipeline _visualPipeline;

        protected override void HandleEvent(DealDamageEvent evt)
        {
           _visualPipeline.AddTask(new DealDamageVisualTask(evt.Entity, 0.15f));
        }
    }
}