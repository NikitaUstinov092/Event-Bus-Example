using System.Declarative.Scripts;
using System.Declarative.Scripts.Attributes;
using Entity.Model;

namespace Entity.Player
{
    public sealed class PlayerModel : DeclarativeModel
    {
        [Section]
        public Position Position;
        
        [Section]
        public Life Life;
        
        [Section]
        public Attack Shoot;
    }
}
