﻿using UnityEngine;

namespace Entity.Components
{
    public sealed class DestroyComponent
    {
        private readonly GameObject _gameObject;
        
        public DestroyComponent(GameObject gameObject)
        {
            _gameObject = gameObject;
        }

        public void Destroy()
        {
            Object.Destroy(_gameObject);
        }
    }
}
