using Entity;
using Entity.Player;
using UnityEngine;

namespace GamePlay
{
    public sealed class PlayerService : MonoBehaviour
    {
        public IEntity Player => player;

        [SerializeField]
        private MonoEntity player;
    }
}