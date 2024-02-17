using Entity.Components;
using TurnSystem.Events;

namespace TurnSystem.Handlers
{
    public class BulletAttackHandler: BaseHandler<BulletAttackEvent>
    {
        protected override void HandleEvent(BulletAttackEvent evt)
        {
            if (!evt.Entity.TryGet(out ShootComponent weapon))
            {
                return;
            }
         
            foreach (var effect in weapon.Value.Effects)
            {
                effect.Source = evt.Entity;
                effect.Targets = new[]{evt.Target};
                EventBus.RaiseEvent(effect);
            }
        }
    }
}