using Lessons.Tasks.Turn;
using Zenject;


namespace Lessons.Turn
{
    public sealed class TurnPipelineInstaller : IInitializable
    {
        private readonly TurnPipeline _turnPipeline;
        private readonly DiContainer _container;
        
        public TurnPipelineInstaller(TurnPipeline turnPipeline, DiContainer container)
        {
            _turnPipeline = turnPipeline;
            _container = container;
        }
        
        void IInitializable.Initialize()
        {
            _turnPipeline.AddTask(new StartTurnTask());
            /*_turnPipeline.AddTask(_objectResolver.CreateInstance<PlayerTurnTask>());
            _turnPipeline.AddTask(_objectResolver.CreateInstance<VisualTurnTask>());*/
            _turnPipeline.AddTask(new FinishTurnTask());
        }
    }
}