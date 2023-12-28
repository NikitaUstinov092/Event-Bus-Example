using Entity;
using GamePlay;
using GamePlay.Input;
using Tasks.Turn;
using TurnSystem;
using Zenject;

namespace Turn
{
    public sealed class TurnPipelineInstaller : IInitializable
    {
        private TurnPipeline _turnPipeline;
        private DiContainer _container;
        
        [Inject]
        private KeyboardInput _input;
        [Inject]
        private PlayerService _playerService;
        [Inject]
        private EventBus _eventBus;
        
        
        [Inject]
        public void Construct(TurnPipeline turnPipeline, DiContainer container)
        {
            _turnPipeline = turnPipeline;
            _container = container;
        }
        
        void IInitializable.Initialize()
        {
            var pt = new PlayerTurnTask(_input,_eventBus, _playerService);
            _turnPipeline.AddTask(new StartTurnTask());
            
            _turnPipeline.AddTask(pt);
           // _turnPipeline.AddTask(_container.Resolve<VisualTurnTask>());
            _turnPipeline.AddTask(new FinishTurnTask());
        }
    }
}