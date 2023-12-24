using System;
using System.Atomic.Implementations;

namespace Entity.Model
{
    [Serializable]
    public sealed class Stats
    {
        public AtomicVariable<int> strength;
    }
}
