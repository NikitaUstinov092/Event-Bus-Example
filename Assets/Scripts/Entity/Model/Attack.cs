using System;
using System.Atomic.Implementations;
using Entity.Config;

namespace Entity.Model
{
    [Serializable]
    public sealed class Attack
    {
        public AtomicVariable<Weapon> weapon;
    }
}
