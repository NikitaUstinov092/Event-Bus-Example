using TurnSystem.Events.Effect;
using UnityEngine;

namespace Entity.Config
{
    [CreateAssetMenu(fileName = "New Weapon", menuName = "Lesson19/Weapon")]
    public sealed class Weapon : ScriptableObject
    {
        [SerializeReference]
        public IEffect[] Effects;
    }
}