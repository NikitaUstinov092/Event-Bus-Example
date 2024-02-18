using Entity;
using Entity.Enemy;
using Entity.Player;
using Sirenix.OdinInspector;
using UnityEngine;
using Zenject;

public class ZombieSpawner : MonoBehaviour
{
    [SerializeField]
    private MonoEntity _zombie;
    
    [SerializeField]
    private Transform[] _spawnPoints;
    
    private EnemyStorage _enemyStorage;
    private EntityInstaller _entityInstaller;

    private int _spawnPointIndex;
    
    [Inject]
    private void Construct(EnemyStorage enemyStorage, EntityInstaller entityInstaller)
    {
        _enemyStorage = enemyStorage;
        _entityInstaller = entityInstaller;
    }

    [Button]
    public void CreateZombie()
    {
       var zombie =  Instantiate(_zombie, _entityInstaller.transform);
       zombie.transform.position = _spawnPoints[_spawnPointIndex].position;
       
       _enemyStorage.AddEnemy(zombie);
       _entityInstaller.InstallEntity(zombie);

       MoveNextPoint();
    }

    private void MoveNextPoint()
    {
        if (_spawnPointIndex < _spawnPoints.Length-1)
        {
            ++_spawnPointIndex;
        }
        else
        {
            _spawnPointIndex = 0;
        }
    }
  
}
