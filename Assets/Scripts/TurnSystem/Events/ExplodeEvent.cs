using Entity;
using Entity.Config;

namespace TurnSystem.Events
{
    public class ExplodeEvent
    {
        public readonly IEntity Entity;
        public readonly Weapon PostDeathEffect;

        public ExplodeEvent(IEntity entity, Weapon postDeathEffect)
        {
            Entity = entity;
            PostDeathEffect = postDeathEffect;
        }
    }
}