using Entity;
using Entity.Components;
using GamePlay;
using Tasks;
using TurnSystem;
using TurnSystem.Events;
using UnityEngine;

public class ZombieTurnTask : Task
{
    private IEntity _enemy;
    private IEntity _target;
    private EventBus _eventBus;
    
    public ZombieTurnTask (EventBus eventBus, PlayerService playerService, IEntity enemy)
    {
        _target = playerService.Player;
        _enemy = enemy;
        _eventBus = eventBus;
    }
        
    protected override void OnRun()
    {
        var targetCoordinates = _target.Get<CoordinatesComponent>().Value;
        var enemyCoordinates = _enemy.Get<CoordinatesComponent>().Value;
        var direction = DirectionHelper.GetDirection(enemyCoordinates, targetCoordinates); // Получаем единичное направление
        
        if (_enemy.Get<HitPointsComponent>().Value <= 0)
        {
            Finish();
            return;
        }
        
        OnMovePreformed(direction);
    }

    private void OnMovePreformed(Vector2Int direction)
    {
        _eventBus.RaiseEvent(new ApplyDirectionEvent(_enemy, direction));
        Finish();
    }
}

public static class DirectionHelper
{
    public static Vector2Int GetDirection(Vector2Int enemyCoordinates, Vector2Int targetCoordinates)
    {
        if (enemyCoordinates.x != targetCoordinates.x)
        {
            if (enemyCoordinates.x < targetCoordinates.x)
            {
                return new Vector2Int(1, 0);
            }

            if (enemyCoordinates.x > targetCoordinates.x)
            {
                return new Vector2Int(-1, 0);
            }
        }

        else if (enemyCoordinates.y != targetCoordinates.y)
        {
            if (enemyCoordinates.y < targetCoordinates.y)
            {
                return new Vector2Int(0, 1);
            }

            if (enemyCoordinates.y > targetCoordinates.y)
            {
                return new Vector2Int(0, -1);
            }
        }

        return Vector2Int.zero; // Если текущие координаты совпадают с целевыми, возвращаем нулевое направление
    }
}
