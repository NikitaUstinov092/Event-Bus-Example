
    using Entity.Components;
    using TurnSystem.Events;

    namespace TurnSystem.Handlers
     {
         public sealed class MeleeCombatHandler : BaseHandler<MeleeCombatEvent>
         {
             protected override void HandleEvent(MeleeCombatEvent evt)
             {
                 if (!evt.Entity.TryGet(out MeleeWeaponComponent weapon))
                 {
                     return;
                 }
            
                 
                 foreach (var effect in weapon.Value.Effects)
                 {
                     effect.Source = evt.Entity;
                     effect.Targets = new []{evt.Target};
                     EventBus.RaiseEvent(effect);
                 }
             }
         }
     }
