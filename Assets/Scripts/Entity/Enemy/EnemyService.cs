using Entity;
using Entity.Player;
using UnityEngine;

public class EnemyService : MonoBehaviour
{
    public IEntity Enemy => _enemy;

    [SerializeField]
    private MonoEntity _enemy;
}

