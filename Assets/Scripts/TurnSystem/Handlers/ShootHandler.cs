using Entity.Components;
using Level;
using TurnSystem.Events;
using Zenject;

namespace TurnSystem.Handlers
{
    public sealed class ShootHandler: BaseHandler<ShootEvent>
    {
        [Inject]
        private readonly LevelMap _levelMap;
        
        protected override void HandleEvent(ShootEvent evt)
        {
            var shooter = evt.Entity;
            var coordinates = shooter.Get<CoordinatesComponent>().Value;

            var bulletCoordinates = coordinates;
            
            for (var i = 0; i < evt.MaxShootDistance; i++)
            {
                var bulletDirection = bulletCoordinates += evt.ShootDirection;
               
                if (_levelMap.Entities.HasEntity(bulletDirection))
                {
                    var shootEntity = _levelMap.Entities.GetEntity(bulletDirection);
                    
                    EventBus.RaiseEvent(new BulletAttackEvent(shooter, shootEntity));
                    break;
                }
               
                if (!_levelMap.Tiles.IsWalkable(bulletDirection)) // Если пуля вылетает за пределы поля
                {
                    break;
                }
            }
        }
    }
}
