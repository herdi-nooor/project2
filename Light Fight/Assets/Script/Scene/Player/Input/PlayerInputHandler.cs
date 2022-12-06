using System;
using UnityEngine;
using UnityEngine.InputSystem;
using Touch = UnityEngine.Touch;
using Input = UnityEngine.Input;

namespace LightFight.Player.Input
{
    public class PlayerInputHandler : MonoBehaviour
    {
        [SerializeField] private bool _debugging;
        private PlayerController _pc;
        private Vector2 _currentDirect;
        private Vector2 _input;
        private String _inputD;

        private void Start()
        {
            _pc = GetComponent<PlayerController>();
        }

        #region new input
        
        public void OnMove(InputAction.CallbackContext contex)
        {
            _input = contex.ReadValue<Vector2>();
            if (contex.performed && contex.ReadValue<Vector2>().x != 0)
            {
                _currentDirect = contex.ReadValue<Vector2>();
                _pc.Move(_currentDirect);
                _inputD = "left right";
            }
            if (contex.canceled);
        }

        public void OnUpDown(InputAction.CallbackContext contex)
        {
            _input = contex.ReadValue<Vector2>();
            _inputD = "up down";
            if (contex.performed && contex.ReadValue<Vector2>().y > 0) _pc.Jump();
            if (contex.performed && contex.ReadValue<Vector2>().y < 0) _pc.Down();
            if (contex.canceled);
        }

        #endregion

        #region old input

        private Touch _theTouch;
        private Vector2 _touchStartPosition, _touchEndPosition;
        
        private void Update()
        {
            Getinput();
        }

        private void Getinput()
        {
            if (Input.touchCount > 0)
            {
                _theTouch = Input.GetTouch(0);
                if (_theTouch.phase == TouchPhase.Began)
                {
                    _touchStartPosition == _theTouch.position;
                }
                else if (_theTouch.phase == TouchPhase.Move || _theTouch.phase == TouchPase.Ended)
                {
                    _touchEndPosition = _theTouch.position;
                    float x = _touchStartPosition.x - _touchEndPosition.x;
                    float y = _touchStartPosition.y - _touchEndPosition.y;
                    
                    if (Mathf.Abs(x) == 0 && Mathf.Abs(y) == 0)
                    {
                        _inputD = "tapped";
                    }
                    else if (Mathf.Abs(x) > Mathf.Abs(y))
                    {
                        _inputD = x > 0 ? "right" : "left";
                    }

                    else
                    {
                        _inputD = y > 0 ? "up" : "down";
                    }
                }
            }
                        
        }

        #endregion
        
        #region DebugGUI
        
        void OnGUI()
        {
            // for showing debugging information for mechanic move and grabber
            if (!_debugging) { return; }
            GUI.Label(new Rect(10, 10, 100, 200), "Debugging Info:");
            GUI.contentColor = Color.white;
            GUI.Label(new Rect(10, 25, 500, 200), $"curentdirection : {_currentDirect}");
            GUI.Label(new Rect(10, 40, 500, 200), $"input: {_input}");
            GUI.Label(new Rect(10, 40, 500, 200), $" direct input: {_inputD}");
        }
        
        #endregion
    }
}
