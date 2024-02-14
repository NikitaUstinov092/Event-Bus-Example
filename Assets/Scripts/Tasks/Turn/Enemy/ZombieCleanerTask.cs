using System;
using System.Collections.Generic;
using Entity;
using Entity.Components;
using Entity.Enemy;
using UnityEngine;
using Zenject;

namespace Tasks.Turn.Common
{
    public class ZombieCleanerTask: Task
    {
        [Inject]
        private EnemyStorage _enemyStorage;
        protected override void OnRun()
        {
            Debug.Log("ZombieCleanerTask started!");
            var enemies = _enemyStorage.Enemies;

            List<IEntity> deadEnemies = new();
           
            foreach (var enemy in enemies)
            {
                var hp = enemy.Get<HitPointsComponent>();
                if (hp.Value <= 0)
                {
                    deadEnemies.Add(enemy);
                }
            }
          
            _enemyStorage.RemoveEnemy(deadEnemies.ToArray());
            
            Finish();
        }
    }
}