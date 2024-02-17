using System.Atomic.Implementations;
using Entity.Components;
using Entity.Player;
using UnityEngine;

namespace Entity.Enemy
{
    [RequireComponent(typeof(EnemyModel))]
    [DefaultExecutionOrder(-100)]
    public sealed class EnemyEntity : MonoEntityBase
    {
        private void Awake()
        {
            var model = GetComponent<EnemyModel>();
            Add(new TransformComponent(transform));
            Add(new PositionComponent(model.Position.transform));
            Add(new MeleeWeaponComponent(model.attack.Weapon));
            Add(new CoordinatesComponent(model.Position.coordinates));
            Add(new HitPointsComponent(model.Life.hitPoints, model.Life.maxHitPoints));
            Add(new DeathComponent(model.Life.isDead));
            Add(new TeamComponent(new AtomicVariable<int>(2)));
            Add(new DestroyComponent(gameObject));
        }
    }
}
