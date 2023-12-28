using Entity.Components;
using Level;
using TurnSystem.Events;
using Zenject;

namespace TurnSystem.Handlers
{
    public sealed class ApplyDirectionHandler : BaseHandler<ApplyDirectionEvent>
    {
        [Inject]
        private readonly LevelMap _levelMap;
        
        protected override void HandleEvent(ApplyDirectionEvent evt)
        {
            var coordinates = evt.Entity.Get<CoordinatesComponent>();
            var targetCoordinates = coordinates.Value + evt.Direction;

            if (_levelMap.Entities.HasEntity(targetCoordinates))
            {
                EventBus.RaiseEvent(new AttackEvent(evt.Entity, _levelMap.Entities.GetEntity(targetCoordinates)));
                return;
            }
            
            if (_levelMap.Tiles.IsWalkable(targetCoordinates))
            {
               EventBus.RaiseEvent(new MoveEvent(evt.Entity, targetCoordinates));
            }
        }
    }
}
