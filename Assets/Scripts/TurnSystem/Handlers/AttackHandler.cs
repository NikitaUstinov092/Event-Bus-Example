
    using Entity.Components;
    using TurnSystem.Events;

    namespace TurnSystem.Handlers
     {
         public sealed class AttackHandler : BaseHandler<AttackEvent>
         {
             protected override void HandleEvent(AttackEvent evt)
             {
                 if (!evt.Entity.TryGet(out WeaponComponent weapon))
                 {
                     return;
                 }
            
                 foreach (var effect in weapon.Value.Effects)
                 {
                     effect.Source = evt.Entity;
                     effect.Target = evt.Target;
                     EventBus.RaiseEvent(effect);
                 }
             }
         }
     }
