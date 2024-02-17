
    using Entity;

    namespace TurnSystem.Events.Effect
    {
        public interface IEffect
        {
            public IEntity Source { get; set; }
            public IEntity[] Targets { get; set; }
        }
    }
