using System;
using System.Atomic.Implementations;

namespace Entity.Model
{
    [Serializable]
    public sealed class Life
    {
        public AtomicVariable<bool> isDead;

        public AtomicVariable<int> hitPoints;
        public AtomicVariable<int> maxHitPoints;
    }
}
