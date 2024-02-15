using System.Declarative.Scripts;
using System.Declarative.Scripts.Attributes;
using Entity.Model;
using UnityEngine.Serialization;

namespace Entity.Enemy
{
    public sealed class EnemyModel : DeclarativeModel
    {
        [Section]
        public Position Position;

        [Section]
        public Life Life;
        
        [FormerlySerializedAs("MeleeAttack")] [Section]
        public Attack attack;
        
    }
}
