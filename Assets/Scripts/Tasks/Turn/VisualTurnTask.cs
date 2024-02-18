using Tasks.Visual;
using UnityEngine;
using Zenject;

namespace Tasks.Turn
{
    public sealed class VisualTurnTask : Task
    {
        [Inject]
        private readonly VisualPipeline _visualPipeline;
        
        protected override void OnRun()
        {
            _visualPipeline.Finished += OnVisualPipelineFinished;
            _visualPipeline.Run();
        }

        private void OnVisualPipelineFinished()
        {
            _visualPipeline.Finished -= OnVisualPipelineFinished;
            _visualPipeline.Clear();
            
            Finish();
        }
    }
}