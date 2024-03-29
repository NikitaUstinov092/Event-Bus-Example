
    using System.Atomic.Implementations;
    using Entity.Config;

    namespace Entity.Components
    {
        public sealed class MeleeWeaponComponent
        {
            public Weapon Value => _weapon.Value;
        
            private readonly AtomicVariable<Weapon> _weapon;
        
            public MeleeWeaponComponent(AtomicVariable<Weapon> weapon)
            {
                _weapon = weapon;
            }
        }
    }
