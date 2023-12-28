
    using TurnSystem.Events;

    namespace TurnSystem.Handlers
     {
         public sealed class CollideHandler : BaseHandler<CollideEvent>
         {
             protected override void HandleEvent(CollideEvent evt)
             {
                 EventBus.RaiseEvent(new DealDamageEvent(evt.Entity, 1));
                 EventBus.RaiseEvent(new DealDamageEvent(evt.Target, 1));
             }
         }
     }
