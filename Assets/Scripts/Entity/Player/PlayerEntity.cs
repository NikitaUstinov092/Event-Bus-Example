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
                new PositionComponent(model.position.transform),
                new StatsComponent(model.stats),
                new WeaponComponent(model.attack.weapon),
                new PositionComponent(model.position.transform),
                new CoordinatesComponent(model.position.coordinates));
        }
    }
}
