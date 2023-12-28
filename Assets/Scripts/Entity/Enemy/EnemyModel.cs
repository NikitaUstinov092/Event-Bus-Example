using System.Declarative.Scripts;
using System.Declarative.Scripts.Attributes;
using Entity.Model;

namespace Entity.Enemy
{
    public sealed class EnemyModel : DeclarativeModel
    {
        [Section]
        public Position position;

        [Section]
        public Life life;
    }
}
