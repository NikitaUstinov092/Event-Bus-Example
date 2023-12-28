
    using Entity.Components;
    using Level;
    using TurnSystem.Events;
    using Zenject;

    namespace TurnSystem.Handlers
     {
         public sealed class MoveHandler : BaseHandler<MoveEvent>
         {
             [Inject]
             private readonly LevelMap _levelMap;
             
             protected override void HandleEvent(MoveEvent evt)
             {
                 var coordinates = evt.Entity.Get<CoordinatesComponent>();
            
                 _levelMap.Entities.RemoveEntity(coordinates.Value);
                 _levelMap.Entities.SetEntity(evt.Coordinates, evt.Entity);
                 coordinates.Value = evt.Coordinates;

                  // Visual
                  var position = evt.Entity.Get<PositionComponent>();
                  position.Value = _levelMap.Tiles.CoordinatesToPosition(evt.Coordinates);
                 
                 if (!_levelMap.Tiles.IsWalkable(evt.Coordinates))
                 {
                     EventBus.RaiseEvent(new DestroyEvent(evt.Entity));
                 }
             }
         }
     }
