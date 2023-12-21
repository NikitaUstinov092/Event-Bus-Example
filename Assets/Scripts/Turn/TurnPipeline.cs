using System;
using System.Collections.Generic;
using Lessons.Tasks;
using Sirenix.OdinInspector;

namespace Lessons.Turn
{
    public sealed class TurnPipeline
    {
        public event Action Finished;

        [ShowInInspector, ReadOnly]
        private readonly List<Task> _tasks = new();

        private int _currentIndex = -1;

        public void AddTask(Task task)
        {
            _tasks.Add(task);
        }
        
        public void Run()
        {
            _currentIndex = 0;
            RunNextTask();
        }

        private void RunNextTask()
        {
            if (_currentIndex >= _tasks.Count)
            {
                Finished?.Invoke();
                return;
            }

            var task = _tasks[_currentIndex];
            task.Run(OnTaskFinished);
        }

        private void OnTaskFinished(Task task)
        {
            ++_currentIndex;
            RunNextTask();
        }
    }
}