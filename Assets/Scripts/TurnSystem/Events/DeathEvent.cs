
    using Entity;

    namespace TurnSystem.Events
    {
        public readonly struct DeathEvent
        {
            public readonly IEntity Entity;

            public DeathEvent(IEntity entity)
            {
                Entity = entity;
            }
        }
    }
