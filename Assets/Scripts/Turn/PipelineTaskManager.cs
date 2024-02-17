using System;
using Tasks.Turn;
using Tasks.Turn.Common;
using UnityEngine;
using Zenject;

namespace Turn
{
    public sealed class PipelineTaskManager: MonoBehaviour, IDisposable
    {
        public event Action OnPipeLineSet;
        
        private TurnPipeline _turnPipeline;
        private DiContainer _container;
        
        private PlayerTurnTask _playerTurnTask;
        private ZombieTaskInstaller _zombieTaskInstaller;
        
        private VisualTurnTask _visualTurnTask;
        private DeadEntityCleanerTask _deadEntityCleanerTask;
        private ZombieTaskSpawner _zombieTaskSpawner;
        private void SetPipelineTasks()
        {
            _turnPipeline.ClearAllTasks();
            _turnPipeline.AddTask(_playerTurnTask);
            _zombieTaskInstaller.Init();
            _turnPipeline.AddTask(_visualTurnTask);
            _turnPipeline.AddTask(_zombieTaskSpawner);
            _turnPipeline.AddTask(_deadEntityCleanerTask);
            
            OnPipeLineSet?.Invoke();
        }
        
        [Inject]
        private void Construct(TurnPipeline turnPipeline, DiContainer container)
        {
            _turnPipeline = turnPipeline;
            _container = container;

            _playerTurnTask = _container.Resolve<PlayerTurnTask>();
            _zombieTaskInstaller = _container.Resolve<ZombieTaskInstaller>();
            _visualTurnTask = _container.Resolve<VisualTurnTask>();
            _deadEntityCleanerTask = _container.Resolve<DeadEntityCleanerTask>();
            _zombieTaskSpawner = _container.Resolve<ZombieTaskSpawner>();
        }
        
        private void Start()
        {
            SetPipelineTasks();
            _turnPipeline.Run();
            
            OnPipeLineSet += _turnPipeline.Run;
            _turnPipeline.Finished += SetPipelineTasks;
        }
        
        void IDisposable.Dispose()
        {
            OnPipeLineSet -= _turnPipeline.Run;
            _turnPipeline.Finished -= SetPipelineTasks;
        }
        
    }
}