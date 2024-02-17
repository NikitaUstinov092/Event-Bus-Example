using System.Atomic.Implementations;
using Entity.Components;
using UnityEngine;

namespace Entity.Player
{
    [RequireComponent(typeof(PlayerModel))]
    [DefaultExecutionOrder(-100)]
    public sealed class PlayerEntity : MonoEntityBase
    {
        private void Awake()
        {
            var model = GetComponent<PlayerModel>();
            AddRange(new TransformComponent(transform),
                new PositionComponent(model.Position.transform),
                new CoordinatesComponent(model.Position.coordinates),
                new ShootComponent(model.Shoot.Weapon),
                new HitPointsComponent(model.Life.hitPoints, model.Life.maxHitPoints),
                new DeathComponent(model.Life.isDead),
                new TeamComponent(new AtomicVariable<int>(0)),
                new DestroyComponent(gameObject));
        }
    }
}
