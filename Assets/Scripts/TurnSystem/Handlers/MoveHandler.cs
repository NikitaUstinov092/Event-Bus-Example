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
                 
                 if (!_levelMap.Tiles.IsWalkable(evt.Coordinates)) // Если стоять нельзя убить сущность
                 {
                     EventBus.RaiseEvent(new DestroyEvent(evt.Entity));
                 }
             }
         }
     }
