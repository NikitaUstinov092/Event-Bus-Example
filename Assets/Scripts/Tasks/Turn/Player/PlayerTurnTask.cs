using Entity;
using GamePlay;
using GamePlay.Input;
using TurnSystem;
using TurnSystem.Events;
using UnityEngine;
using Zenject;

namespace Tasks.Turn
{
    public sealed class PlayerTurnTask : Task
    {
        private IMoveInput _input;
        private IEntity _player;
        private EventBus _eventBus;
        
        [Inject]
        public void Construct(IMoveInput input, EventBus eventBus, PlayerService playerService)
        {
            _input = input;
            _player = playerService.Player;
            _eventBus = eventBus;
        }
        protected override void OnRun()
        {
            Debug.Log("PlayerTurnTask started!");
            _input.MovePerformed += OnMovePreformed;
        }

        private void OnMovePreformed(Vector2Int direction)
        {
            _input.MovePerformed -= OnMovePreformed;
          
            _eventBus.RaiseEvent(new ApplyDirectionEvent(_player, direction));
            Finish();
        }

        protected override void OnFinish()
        {
            Debug.Log("PlayerTurnTask finished!");
        }
    }
}
