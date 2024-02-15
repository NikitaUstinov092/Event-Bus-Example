
    using Entity;

    namespace TurnSystem.Events
    {
        public readonly struct MeleeCombatEvent
        {
            public readonly IEntity Entity;
            public readonly IEntity Target;

            public MeleeCombatEvent(IEntity entity, IEntity target)
            {
                Entity = entity;
                Target = target;
            }
        }
    }
