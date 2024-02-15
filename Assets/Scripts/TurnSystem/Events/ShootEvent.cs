using Entity;
using UnityEngine;

namespace TurnSystem.Events
{
    public readonly struct ShootEvent
    {
        public readonly IEntity Entity;
        public readonly Vector2Int ShootDirection;
        public readonly int MaxShootDistance;

        public ShootEvent(IEntity entity, Vector2Int shootDirection, int maxShootDistance)
        {
            Entity = entity;
            ShootDirection = shootDirection;
            MaxShootDistance = maxShootDistance;
        }
    }
}