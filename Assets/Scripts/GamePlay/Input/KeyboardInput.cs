using System;
using UnityEngine;

namespace GamePlay.Input
{
    public sealed class KeyboardInput : MonoBehaviour, IMoveInput, IShootInput
    {
        public event Action<Vector2Int> MovePerformed;
        public event Action<Vector2Int> ShootPerformed;

        [SerializeField]
        private KeyCode _moveUp = KeyCode.W;
        
        [SerializeField]
        private KeyCode _moveDown = KeyCode.S;
        
        [SerializeField]
        private KeyCode _moveLeft = KeyCode.A;
        
        [SerializeField]
        private KeyCode _moveRight = KeyCode.D;
        
        [SerializeField]
        private KeyCode _shootUp = KeyCode.UpArrow;
        
        [SerializeField]
        private KeyCode _shootDown = KeyCode.DownArrow;
        
        [SerializeField]
        private KeyCode _shootLeft = KeyCode.LeftArrow;
        
        [SerializeField]
        private KeyCode _shootRight = KeyCode.RightArrow;
        
        private void Update()
        {
            var movement = new Vector2Int();
            var shootDirection = new Vector2Int();
            
            if (UnityEngine.Input.GetKeyUp(_moveUp))
            {
                movement.y += 1;
            }
            
            if (UnityEngine.Input.GetKeyUp(_moveDown))
            {
                movement.y -= 1;
            }
            
            if (UnityEngine.Input.GetKeyUp(_moveRight))
            {
                movement.x += 1;
            }
            
            if (UnityEngine.Input.GetKeyUp(_moveLeft))
            {
                movement.x -= 1;
            }
            
            if (UnityEngine.Input.GetKeyUp(_shootUp))
            {
                shootDirection.y += 1;
            }
            
            if (UnityEngine.Input.GetKeyUp(_shootDown))
            {
                shootDirection.y -= 1;
            }
            
            if (UnityEngine.Input.GetKeyUp(_shootRight))
            {
                shootDirection.x += 1;
            }
            
            if (UnityEngine.Input.GetKeyUp(_shootLeft))
            {
                shootDirection.x -= 1;
            }
            
            if (movement != Vector2Int.zero)
            {
                MovePerformed?.Invoke(movement);
            }
            
            if (shootDirection != Vector2Int.zero)
            {
                ShootPerformed?.Invoke(shootDirection);
            }
        }

      
    }

    public interface IMoveInput
    {
        public event Action<Vector2Int> MovePerformed;
    }
    
    public interface IShootInput
    {
        public event Action<Vector2Int> ShootPerformed;
    }
}