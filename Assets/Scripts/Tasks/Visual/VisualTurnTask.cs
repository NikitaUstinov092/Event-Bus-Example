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
            Debug.Log("Visual started!");

            _visualPipeline.Finished += OnVisualPipelineFinished;
            _visualPipeline.Run();
        }

        private void OnVisualPipelineFinished()
        {
            Debug.Log("Visual finished!");
            
            _visualPipeline.Finished -= OnVisualPipelineFinished;
            _visualPipeline.Clear();
            
            Finish();
        }
    }
}