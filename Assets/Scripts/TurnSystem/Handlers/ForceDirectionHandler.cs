using Entity.Components;
using Level;
using TurnSystem.Events;
using Zenject;

namespace TurnSystem.Handlers
{
    public class ForceDirectionHandler : BaseHandler<ForceDirectionEvent>
    {
        [Inject]
        private readonly LevelMap _levelMap;

        protected override void HandleEvent(ForceDirectionEvent evt)
        {
            var coordinates = evt.Entity.Get<CoordinatesComponent>();
            var targetCoordinates = coordinates.Value + evt.Direction;

            if (_levelMap.Entities.HasEntity(targetCoordinates))
            {
                EventBus.RaiseEvent(new CollideEvent(evt.Entity, _levelMap.Entities.GetEntity(targetCoordinates)));
            }
            else
            {
                EventBus.RaiseEvent(new MoveEvent(evt.Entity, targetCoordinates, true));
            }
        }
    }
}
