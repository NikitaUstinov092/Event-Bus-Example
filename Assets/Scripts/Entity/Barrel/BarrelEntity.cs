using Entity.Components;
using Entity.Player;
using UnityEngine;

[RequireComponent(typeof(BarrelModel))]
[DefaultExecutionOrder(-100)]
public class BarrelEntity : MonoEntityBase
{
        private void Awake()
        {
            var model = GetComponent<BarrelModel>();
            Add(new TransformComponent(transform));
            Add(new PositionComponent(model.Position.transform));
            Add(new MeleeWeaponComponent(model.Attack.Weapon));
            Add(new CoordinatesComponent(model.Position.coordinates));
            Add(new HitPointsComponent(model.Life.hitPoints, model.Life.maxHitPoints));
            Add(new ExplodeComponent(model.Life.isDead, model.Attack.Weapon));
            Add(new DestroyComponent(gameObject));
           
        }
}
