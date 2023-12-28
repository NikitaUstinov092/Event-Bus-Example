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
            Add(new PositionComponent(model.position.transform));
            Add(new CoordinatesComponent(model.position.coordinates));
            Add(new HitPointsComponent(model.life.hitPoints, model.life.maxHitPoints));
            Add(new DeathComponent(model.life.isDead));
            Add(new DestroyComponent(gameObject));
            Add(new TransformComponent(transform));
        }
    }
}
