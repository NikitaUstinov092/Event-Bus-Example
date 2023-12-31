using UnityEngine;

namespace Entity.Player
{
    public abstract class MonoEntity : MonoBehaviour, IEntity
    {
        public abstract T Get<T>();
        
        public abstract bool TryGet<T>(out T element);
        
        public abstract object[] GetAll();
    }
}