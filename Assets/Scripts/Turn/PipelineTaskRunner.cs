using Entity.Components;
using GamePlay;
using Turn;
using Zenject;
public sealed class PipelineTaskRunner : IStartListener, IDisableListener
    {
        private TurnPipeline _turnPipeline;
        private PipelineTaskManager _pipelineTaskManager;
        private PlayerService _playerService;
        private DeathComponent _deathComponent;
        
        [Inject]
        private void Construct(TurnPipeline turnPipeline, PipelineTaskManager pipelineTaskManager, PlayerService playerService)
        {
            _turnPipeline = turnPipeline;
            _pipelineTaskManager = pipelineTaskManager;
            _playerService = playerService;
        }
        void IStartListener.StartGame()
        {
            _turnPipeline.Finished += OnTurnPipelineFinished;
            _deathComponent = _playerService.Player.Get<DeathComponent>();
            Run();
        }
        void IDisableListener.Disable()
        {
            _turnPipeline.Finished -= OnTurnPipelineFinished;
        }
        private void Run()
        {
            _pipelineTaskManager.Start();
        }

        private void OnTurnPipelineFinished()
        {
            if (!_deathComponent.IsDead)
            {
                Run();
            }
        }
    }
