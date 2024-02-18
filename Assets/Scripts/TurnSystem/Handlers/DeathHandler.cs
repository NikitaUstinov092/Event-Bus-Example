  using Entity.Components;
  using Level;
  using TurnSystem.Events;
  using Zenject;

  namespace TurnSystem.Handlers
   {
       public sealed class DeathHandler : BaseHandler<DeathEvent>
       {
           [Inject]
           private readonly LevelMap _levelMap;
        
           protected override void HandleEvent(DeathEvent evt)
           {
               if (evt.Entity.TryGet(out DeathComponent deathComponent))
               {
                   deathComponent.Die();
               }

               var coordinates = evt.Entity.Get<CoordinatesComponent>();
               _levelMap.Entities.RemoveEntity(coordinates.Value);
           }
       }
   }
