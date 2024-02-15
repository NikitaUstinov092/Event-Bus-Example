using System;
using System.Atomic.Implementations;
using Entity.Config;
using UnityEngine.Serialization;

namespace Entity.Model
{
    [Serializable]
    public sealed class Attack
    {
       public AtomicVariable<Weapon> Weapon;
    }
}
