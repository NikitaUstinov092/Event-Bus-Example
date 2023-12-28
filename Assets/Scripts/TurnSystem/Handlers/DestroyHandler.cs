  using Entity.Components;
  using Level;
  using TurnSystem.Events;
  using Zenject;

  namespace TurnSystem.Handlers
   {
       public sealed class DestroyHandler : BaseHandler<DestroyEvent>
       {
           [Inject]
           private readonly LevelMap _levelMap;
        
           protected override void HandleEvent(DestroyEvent evt)
           {
               if (evt.Entity.TryGet(out DeathComponent deathComponent))
               {
                   deathComponent.Die();
               }

               var coordinates = evt.Entity.Get<CoordinatesComponent>();
               _levelMap.Entities.RemoveEntity(coordinates.Value);
               //
               // // Visual
               // if (evt.Entity.TryGet(out DestroyComponent destroyComponent))
               // {
               //     destroyComponent.Destroy();
               // }
           }
       }
   }
