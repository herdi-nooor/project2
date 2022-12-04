using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace LightFight.Player.Input
{
    public class PlayerInputHandler : MonoBehaviour
    {
        private PlayerController pc;
        private void Start()
        {
            pc = GetComponent<PlayerController>();
        }

        public void OnMove(InputAction.CallbackContext contex)
        {
            Debug.Log($"on move {contex.ReadValue<Vector2>()}");
            pc.Move(contex.ReadValue<Vector2>());
        }

        public void OnJump(InputAction.CallbackContext contex)
        {
            if (contex.started)
            {
                pc.Jump(new Vector2(0, 1));
            }

            if (contex.canceled)
            {
                pc.Jump(new Vector2(0 , 0));
            }
        }

        public void Down(InputAction.CallbackContext context)
        {
            Debug.Log($"Down {context.performed}");
        }
    }
}
