using System;
using Entity;
using Entity.Components;
using Entity.Enemy;
using Entity.Model;
using Entity.Player;
using Sirenix.OdinInspector;
using UnityEngine;
using Zenject;

public class EnemyStorageManager : MonoBehaviour, IInitializable
{
    [Inject]
    private EnemyStorage _enemyStorage;
    
    [SerializeField]
    private MonoEntity[] _enemy;
    
    public void Initialize()
    {
        foreach (var enemy in _enemy)
        {
            if (!enemy.TryGet(out HitPointsComponent lifeComp))
            {
                throw new Exception($"Добавьте компонент Life на сущность {enemy.gameObject.name}");
            }
            _enemyStorage.AddEnemy(enemy);
        }
        
    }

    [Button]
    public void RemoveEntity(IEntity entity)
    {
        _enemyStorage.RemoveEnemy(entity);
    }
}

