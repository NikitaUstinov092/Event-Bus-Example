using System;
using System.Atomic.Implementations;
using Entity.Config;

public sealed class ExplodeComponent 
{
    public event Action<bool> IsDeadChanged
    {
        add => _isDead.Subscribe(value);
        remove => _isDead.Unsubscribe(value);
    }
        
    public bool IsDead => _isDead.Value;
    public Weapon PostDeathWeaponEffect => _postDeadEffect.Value;

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
