using System.Declarative.Scripts;
using System.Declarative.Scripts.Attributes;
using Entity.Model;

public class BarrelModel : DeclarativeModel
{
    [Section]
    public Position Position;

    [Section]
    public Life Life;
    
    [Section]
    public Attack attack;
}
