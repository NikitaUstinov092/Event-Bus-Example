using Zenject;

namespace Tasks.Turn.Common
{
    public class DeadEntityCleanerTask: Task
    {
        [Inject]
        private EntityObjectDestroyer _cleaner;
        protected override void OnRun()
        {
            _cleaner.DestroyDeadObjects();
            Finish();
        }
    }
}