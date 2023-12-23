using UnityEngine;


    public sealed class PlayerService : MonoBehaviour
    {
        public IEntity Player => player;
        
        [SerializeField]
        private Entity player;
    }

internal class Entity : IEntity //TO DO дописать
{
    T IEntity.Get<T>()
    {
        throw new System.NotImplementedException();
    }

    bool IEntity.TryGet<T>(out T element)
    {
        throw new System.NotImplementedException();
    }

    object[] IEntity.GetAll()
    {
        throw new System.NotImplementedException();
    }
}
