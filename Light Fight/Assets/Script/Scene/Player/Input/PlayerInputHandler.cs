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
            if(contex.performed && contex.ReadValue<Vector2>().x != 0) pc.Move(contex.ReadValue<Vector2>());
            if (contex.canceled);
        }

        public void OnUpDown(InputAction.CallbackContext contex)
        {
            if (contex.performed && contex.ReadValue<Vector2>().y > 0) pc.Jump();
            if (contex.performed && contex.ReadValue<Vector2>().y < 0) pc.Down();
            if (contex.canceled);
        }
    }
}
