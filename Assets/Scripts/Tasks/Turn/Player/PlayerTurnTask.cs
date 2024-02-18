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
        private IMoveInput _inputMove;
        private IShootInput _inputShoot;
        private IEntity _player;
        private EventBus _eventBus;
        
        [Inject]
        public void Construct(IMoveInput inputMove, IShootInput inputShoot, 
            EventBus eventBus, PlayerService playerService)
        {
            _inputMove = inputMove;
            _inputShoot = inputShoot;
            _player = playerService.Player;
            _eventBus = eventBus;
        }
        protected override void OnRun()
        {
            _inputMove.MovePerformed += OnMovePreformed;
            _inputShoot.ShootPerformed += OnShootPreformed;
        }

        private void OnMovePreformed(Vector2Int direction)
        {
            RemoveListeners();
            
            _eventBus.RaiseEvent(new ApplyDirectionEvent(_player, direction));
            Finish();
        }
        
        
        private void OnShootPreformed(Vector2Int direction)
        {
            RemoveListeners();
            _eventBus.RaiseEvent(new ShootEvent(_player, direction, 5));
            Debug.Log("<color=#" + ColorUtility.ToHtmlStringRGB(Color.green) + $">ВЫСТРЕЛ В НАПРАВЛЕНИЕ {direction}</color>");
            Finish();
        }

        private void RemoveListeners()
        {
            _inputMove.MovePerformed -= OnMovePreformed;
            _inputShoot.ShootPerformed -= OnShootPreformed;
        }
    }
}
