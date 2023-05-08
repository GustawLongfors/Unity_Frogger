using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Code.Input
{
    public class PlayerInput : PlayerControls.IGameplayActions
    {
        private readonly PlayerControls controls;

        public event Action<Vector2Int> OnMovementPerformed;
    
        public PlayerInput()
        {
            controls = new PlayerControls();
            controls.Gameplay.SetCallbacks(this);
            controls.Gameplay.Enable();
        }

        public void Destroy()
        {
            controls.Gameplay.SetCallbacks(null);
            controls.Gameplay.Disable();
        }

        public bool Enabled
        {
            set
            {
                if(value) controls.Gameplay.Enable();
                else controls.Gameplay.Disable();
            }
        }

        public void OnMovement(InputAction.CallbackContext context)
        {
            if (!context.started) return;
            Vector2 value = context.ReadValue<Vector2>();
            Vector2Int movement = new Vector2Int((int) value.x, (int) value.y);
            OnMovementPerformed?.Invoke(movement);
        }
    }
}