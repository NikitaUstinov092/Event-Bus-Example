using System.Collections.Generic;
using System.Linq;
using Entity;
using UnityEngine;

namespace Level
{
    public sealed class EntityMap
    {
        private readonly Dictionary<Vector2Int, IEntity> _entities = new();

        public bool HasEntity(Vector2Int coordinates)
        {
            return _entities.ContainsKey(coordinates);
        }

        public IEntity GetEntity(Vector2Int coordinates)
        {
            return _entities.ContainsKey(coordinates) ? _entities[coordinates] : null;
        }
        
        public Vector2Int GetEntityCoordinates(IEntity entity)
        {
            foreach (var coordinates in _entities.Keys.Where(coordinates => _entities[coordinates] == entity))
            {
                return coordinates;
            }

            return Vector2Int.zero;
        }

        public void RemoveEntity(Vector2Int coordinates)
        {
            _entities.Remove(coordinates);
        }
        
        public void SetEntity(Vector2Int coordinates, IEntity entity)
        {
            _entities[coordinates] = entity;
        }
    }
}
