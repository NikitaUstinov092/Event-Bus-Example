using System;
using Entity;

namespace TurnSystem.Events.Effect
{
    [Serializable]
    public struct DealDamageEffectEvent : IEffect
    {
        public IEntity Source { get; set; }
        public IEntity Target { get; set; }
        
        public int extraDamage;
    }
}
