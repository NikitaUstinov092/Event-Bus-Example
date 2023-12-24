using TurnSystem.Events.Effect;
using UnityEngine;

namespace Lessons.Entities.Config
{
    [CreateAssetMenu(fileName = "New Weapon", menuName = "Lesson19/Weapon")]
    public sealed class Weapon : ScriptableObject
    {
        [SerializeReference]
        public IEffect[] Effects;
    }
}