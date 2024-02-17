using Entity.Enemy;
using GamePlay;
using Turn;
using TurnSystem;
using Zenject;

namespace Tasks.Turn.Common
{
    public class ZombieTaskInstaller
    {
        private TurnPipeline _turnPipeline;
        
        private EnemyStorage _enemyStorage; 
        private EventBus _eventBus; 
        private PlayerService _playerService; 
            
        [Inject]
        public void Construct(TurnPipeline turnPipeline, DiContainer container)
        {
            _enemyStorage = container.Resolve<EnemyStorage>();
            _playerService = container.Resolve<PlayerService>();
            _eventBus = container.Resolve<EventBus>();
            _turnPipeline =  container.Resolve<TurnPipeline>();
        }
        
        public void Init()
        {
            foreach (var enemy in _enemyStorage.Enemies)
            {
                var enemyTusk = new ZombieTurnTask(_eventBus,_playerService, enemy);
                _turnPipeline.AddTask(enemyTusk);
            }
        }
    }
}