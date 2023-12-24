using System;
using System.Atomic.Implementations;
using UnityEngine;

namespace Entity.Model
{
    [Serializable]
    public sealed class Position
    {
        public Transform transform;
        
        public AtomicVariable<Vector2Int> coordinates;   
    }
}
