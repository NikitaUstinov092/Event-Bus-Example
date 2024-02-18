using System.Atomic.Implementations;
using Entity.Config;

public sealed class ExplodeComponent 
{
    public Weapon PostDeathWeaponEffect => _postDeadEffect.Value;
    public bool IsExploded => _isDead.Value;
    
    private readonly AtomicVariable<bool> _isDead;
    private readonly AtomicVariable<Weapon> _postDeadEffect;

    public ExplodeComponent(AtomicVariable<bool> isDead, AtomicVariable<Weapon> postDeadEffect)
    {
        _isDead = isDead;
        _postDeadEffect = postDeadEffect;
    }

    public void Explode()
    {
        _isDead.Value = true;
    }
}
