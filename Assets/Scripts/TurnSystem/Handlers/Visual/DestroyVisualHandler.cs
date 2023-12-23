using Lessons.Tasks.Visual;
using Lessons.Visual;

namespace Lessons.TurnSystem.Handlers.Visual
{
    public sealed class DestroyVisualHandler : BaseHandler<DestroyEvent>
    {
        private readonly VisualPipeline _visualPipeline;
        
        public DestroyVisualHandler(EventBus eventBus, VisualPipeline visualPipeline) : base(eventBus)
        {
            _visualPipeline = visualPipeline;
        }

        protected override void HandleEvent(DestroyEvent evt)
        {
            _visualPipeline.AddTask(new DestroyVisualTask(evt.Entity, 0.3f));
        }
    }
}