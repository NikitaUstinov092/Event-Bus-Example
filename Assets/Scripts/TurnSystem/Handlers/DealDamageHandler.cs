
    using Entity.Components;
    using TurnSystem.Events;

    namespace TurnSystem.Handlers
     {
         public sealed class DealDamageHandler : BaseHandler<DealDamageEvent>
         {
             protected override void HandleEvent(DealDamageEvent evt)
             {
                 if (!evt.Entity.TryGet(out HitPointsComponent hitPoints))
                 {
                     return;
                 }
                 hitPoints.Value -= evt.Damage;

                 if (hitPoints.Value <= 0 && evt.Entity.TryGet(out DeathComponent _))
                 {
                     EventBus.RaiseEvent(new DeathEvent(evt.Entity));
                 }
                 else if (hitPoints.Value <= 0 && evt.Entity.TryGet(out ExplodeComponent explodeComponent))
                 {
                     EventBus.RaiseEvent(new ExplodeEvent(evt.Entity, explodeComponent.PostDeathWeaponEffect));
                 }
             }
         }
     }
