using Entity;
using Entity.Components;
using GamePlay;
using Tasks;
using TurnSystem;
using TurnSystem.Events;
using UnityEngine;
using Zenject;

public class EnemyTurnTask : Task
{
    private IEntity _enemy;
    private IEntity _target;
    private EventBus _eventBus;
        
    [Inject]
    public void Construct (EventBus eventBus, PlayerService playerService, EnemyService enemyService )
    {
        _target = playerService.Player;
        _enemy = enemyService.Enemy;
        _eventBus = eventBus;
    }
        
    protected override void OnRun()
    {
        var targetCoordinates = _target.Get<CoordinatesComponent>().Value;
        var enemyCoordinates = _enemy.Get<CoordinatesComponent>().Value;
        var direction = DistanceHelper.GetDirection(enemyCoordinates, targetCoordinates); // Получаем единичное направление
        OnMovePreformed(direction);
    }

    private void OnMovePreformed(Vector2Int direction)
    {
        _eventBus.RaiseEvent(new ApplyDirectionEvent(_enemy, direction));
        Finish();
    }
}

public static class DistanceHelper
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

        if (enemyCoordinates.y != targetCoordinates.y)
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
