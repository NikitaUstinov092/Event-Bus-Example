using System.Declarative.Scripts;
using System.Declarative.Scripts.Attributes;
using Entity.Model;

namespace Entity.Enemy
{
    public sealed class EnemyModel : DeclarativeModel
    {
        [Section]
        public Position Position;

        [Section]
        public Life Life;
        
        [Section]
        public Attack attack;
        
    }
}
