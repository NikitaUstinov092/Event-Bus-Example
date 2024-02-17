using Zenject;

namespace Tasks.Turn.Common
{
    public class ZombieTaskSpawner: Task
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