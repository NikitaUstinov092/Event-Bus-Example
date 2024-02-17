using System;
using Entity;

namespace TurnSystem.Events.Effect
{
    [Serializable]
    public struct DealDamageEffectEvent : IEffect
    {
        public IEntity Source { get; set; }
        public IEntity []Targets { get; set; }
        
        public int extraDamage;
    }
}
