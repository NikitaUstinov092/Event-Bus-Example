using Entity;

namespace TurnSystem.Events
{
    public struct BulletAttackEvent
    {
            public readonly IEntity Entity;
            public readonly IEntity Target;

            public BulletAttackEvent(IEntity entity, IEntity target)
            {
                Entity = entity;
                Target = target;
            }
    }
}