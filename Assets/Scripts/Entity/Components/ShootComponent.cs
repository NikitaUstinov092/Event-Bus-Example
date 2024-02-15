using System.Atomic.Implementations;
using Entity.Config;

namespace Entity.Components
{
    public class ShootComponent
    {
        public Weapon Value => _weapon.Value;
        
        private readonly AtomicVariable<Weapon> _weapon;
       
        
        public ShootComponent(AtomicVariable<Weapon> weapon)
        {
            _weapon = weapon;
        }
    }
}