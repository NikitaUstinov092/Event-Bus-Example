using Entity;
using Entity.Player;
using Sirenix.OdinInspector;
using TurnSystem;
using TurnSystem.Events;
using UnityEngine;
using Zenject;

namespace GamePlay
{
    public sealed class PlayerService : MonoBehaviour
    {
        public IEntity Player => player;

        [SerializeField]
        private MonoEntity player;
        
        /*
        [Inject]
        private EventBus _eventBus;
        
        
        [Button]
        private void Raise()
        {
            _eventBus.RaiseEvent(new ApplyDirectionEvent(player, new Vector2Int(0,1)));
        }*/
    }
}