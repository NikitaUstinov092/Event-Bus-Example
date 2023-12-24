
    using Entity.Components;
    using TurnSystem.Events;

    namespace TurnSystem.Handlers
     {
         public sealed class DealDamageHandler : BaseHandler<DealDamageEvent>
         {
             public DealDamageHandler(EventBus eventBus) : base(eventBus)
             {
            
             }
        
             protected override void HandleEvent(DealDamageEvent evt)
             {
                 if (!evt.Entity.TryGet(out HitPointsComponent hitPoints))
                 {
                     return;
                 }
            
                 hitPoints.Value -= evt.Damage;

                 if (hitPoints.Value <= 0)
                 {
                     EventBus.RaiseEvent(new DestroyEvent(evt.Entity));
                 }
             }
         }
     }
