using Zenject;

namespace Tasks.Turn.Common
{
    public class ZombieSpawnerTask: Task
    {
        [Inject]
        private ZombieSpawner _zombieSpawner;
        
        protected override void OnRun()
        {
            _zombieSpawner.CreateZombie();
            Finish();
        }
    }
}