
    using Entity.Components;
    using TurnSystem.Events;
    using TurnSystem.Events.Effect;
    using UnityEngine;

    namespace TurnSystem.Handlers.Effect
     {
         public sealed class DealDamageEffectHandler : BaseHandler<DealDamageEffectEvent>
         {
             protected override void HandleEvent(DealDamageEffectEvent evt)
             {
                 var damage = evt.extraDamage;
                 foreach (var entity in evt.Targets)
                 {
                     EventBus.RaiseEvent(new DealDamageEvent(entity, damage));
                 }
                
             }
         }
     }
