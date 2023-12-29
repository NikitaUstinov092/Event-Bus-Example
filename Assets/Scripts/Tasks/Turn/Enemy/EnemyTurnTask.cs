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
        var direction = (targetCoordinates - enemyCoordinates).normalizedToInteger();
        OnMovePreformed(direction);
    }

    private void OnMovePreformed(Vector2Int direction)
    {
        
        _eventBus.RaiseEvent(new ApplyDirectionEvent(_enemy, direction));
        Finish();
    }
}

public static class Vector2IntExtensions
{
    public static Vector2Int normalizedToInteger(this Vector2Int vector)
    {
        int gcd = Mathf.Abs(GreatestCommonDivisor(vector.x, vector.y));
        return new Vector2Int(vector.x / gcd, vector.y / gcd);
    }

    // Нахождение наибольшего общего делителя (GCD) с помощью алгоритма Евклида
    private static int GreatestCommonDivisor(int a, int b)
    {
        while (b != 0)
        {
            int remainder = a % b;
            a = b;
            b = remainder;
        }
        return a;
    }
}
