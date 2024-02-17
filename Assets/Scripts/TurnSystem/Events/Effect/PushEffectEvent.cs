using System;
using Entity;

namespace TurnSystem.Events.Effect
{
    [Serializable]
    public struct PushEffectEvent : IEffect
    {
        public IEntity Source { get; set; }
        public IEntity[] Targets { get; set; }
    }
}
