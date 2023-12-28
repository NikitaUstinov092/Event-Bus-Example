using System;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Entity.Player
{
    public abstract class MonoEntityBase : MonoEntity
    {
        private readonly ListEntity _entity = new();

        public override T Get<T>()
        {
            try
            {
                return _entity.Get<T>();
            }
            catch (Exception exception)
            {
                Debug.LogError(exception.Message, this);
                throw;
            }
        }

        public override object[] GetAll()
        {
            return _entity.GetAll();
        }

        public T[] GetAll<T>()
        {
            return _entity.GetAll<T>();
        }

        public void Add(object element)
        {
            _entity.Add(element);
        }

        public void Remove(object element)
        {
            _entity.Remove(element);
        }

        public void AddRange(params object[] elements)
        {
            _entity.AddRange(elements);
        }

        public void AddRange(IEnumerable<object> elements)
        {
            _entity.AddRange(elements);
        }

        public override bool TryGet<T>(out T element)
        {
            return _entity.TryGet(out element);
        }
    }
}