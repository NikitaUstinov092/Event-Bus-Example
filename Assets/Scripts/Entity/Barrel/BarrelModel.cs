using System.Declarative.Scripts;
using System.Declarative.Scripts.Attributes;
using Entity.Model;
using UnityEngine.Serialization;

public class BarrelModel : DeclarativeModel
{
    [Section]
    public Position Position;

    [Section]
    public Life Life;
    
    [FormerlySerializedAs("attack")] [Section]
    public Attack Attack;
}
