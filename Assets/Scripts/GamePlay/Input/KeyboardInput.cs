using System;
using UnityEngine;

namespace GamePlay.Input
{
    public sealed class KeyboardInput : MonoBehaviour
    {
        public event Action<Vector2Int> MovePerformed;
        
        private void Update()
        {
            var movement = new Vector2Int();
            
            if (UnityEngine.Input.GetKeyUp(KeyCode.UpArrow))
            {
                movement.y += 1;
            }
            
            if (UnityEngine.Input.GetKeyUp(KeyCode.DownArrow))
            {
                movement.y -= 1;
            }
            
            if (UnityEngine.Input.GetKeyUp(KeyCode.RightArrow))
            {
                movement.x += 1;
            }
            
            if (UnityEngine.Input.GetKeyUp(KeyCode.LeftArrow))
            {
                movement.x -= 1;
            }
            
            if (movement != Vector2Int.zero)
            {
                MovePerformed?.Invoke(movement);
            }
        }
    }
}