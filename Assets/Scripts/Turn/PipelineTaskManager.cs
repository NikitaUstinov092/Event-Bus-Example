using Tasks.Turn;
using Tasks.Turn.Common;
using Zenject;

namespace Turn
{
    public sealed class PipelineTaskManager
    {
        private TurnPipeline _turnPipeline;
        private PlayerTurnTask _playerTurnTask;
        private ZombieTaskInstaller _zombieTaskInstaller;
        private VisualTurnTask _visualTurnTask;
        private ZombieSpawnerTask _zombieSpawnerTask;
        
        public void Start()
        {
            SetPipelineTasks();
            _turnPipeline.Run();
        }
        
        [Inject]
        private void Construct(TurnPipeline turnPipeline, DiContainer container)
        {
            _turnPipeline = turnPipeline;

            _playerTurnTask = container.Resolve<PlayerTurnTask>();
            _zombieTaskInstaller = container.Resolve<ZombieTaskInstaller>();
            _visualTurnTask = container.Resolve<VisualTurnTask>();
            _zombieSpawnerTask = container.Resolve<ZombieSpawnerTask>();
        }
        private void SetPipelineTasks()
        {
            _turnPipeline.ClearAllTasks();
            _turnPipeline.AddTask(_playerTurnTask);
            _zombieTaskInstaller.Init();
            _turnPipeline.AddTask(_visualTurnTask);
            _turnPipeline.AddTask(_zombieSpawnerTask);
        }
    }
}