
    using System.Atomic.Implementations;
    using Entity.Config;

    namespace Entity.Components
    {
        public sealed class WeaponComponent
        {
            public Weapon Value => _weapon.Value;
        
            private readonly AtomicVariable<Weapon> _weapon;
        
            public WeaponComponent(AtomicVariable<Weapon> weapon)
            {
                _weapon = weapon;
            }
        }
    }
