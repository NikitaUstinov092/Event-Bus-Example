using System.Atomic.Implementations;
using UnityEngine;

namespace Entity.Components
{
    public sealed class CoordinatesComponent
    {
        public Vector2Int Value
        {
            get => _coordinates.Value;
            set
            {
                _coordinates.Value = value; 
                // Debug.Log(_coordinates.Value);
            }
        }

        private readonly AtomicVariable<Vector2Int> _coordinates;

        public CoordinatesComponent(AtomicVariable<Vector2Int> coordinates)
        {
            _coordinates = coordinates;
        }
    }
}
