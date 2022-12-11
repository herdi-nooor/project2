using System;
using UnityEngine;
using Inputs = UnityEngine.Input;
using TouchPhases = UnityEngine.TouchPhase;
using Touchs = UnityEngine.Touch;

namespace LightFight.Player.Input
{
    public class PlayerInputHandler : MonoBehaviour
    {
        [SerializeField] private bool _debugging;
        private PlayerController _pc;
        private Vector2 _input;
        private String _inputD;
        private Touchs _theTouch;
        private Vector2 _touchStartPosition, _touchEndPosition;
        
        private void Start()
        {
            _pc = GetComponent<PlayerController>();
        }
        
        private void Update()
        {
            Getinput();
        }

        private void Getinput()
        {
            if (Inputs.touchCount > 0)
            {
                _theTouch = Inputs.GetTouch(0);
                if (_theTouch.phase == TouchPhases.Began)
                {
                    _touchStartPosition = _theTouch.position;
                }
                else if (_theTouch.phase == TouchPhases.Moved || _theTouch.phase == TouchPhases.Ended)
                {
                    _touchEndPosition = _theTouch.position;
                    float x = _touchStartPosition.x - _touchEndPosition.x;
                    float y = _touchStartPosition.y - _touchEndPosition.y;
                    _input.Set(x, y);
                    if (Mathf.Abs(x) == 0 && Mathf.Abs(y) == 0)
                    {
                        _inputD = "tapped";
                    }
                    else if (Mathf.Abs(x) > Mathf.Abs(y))
                    {
                        _inputD = x > 0 ? "left" : "right";
                        if (x > 0)
                        {
                            _pc.Move(new Vector2(-1, 0));
                        }
                        else
                        {
                            _pc.Move(new Vector2(1, 0));
                        }
                    }

                    else
                    {
                        _inputD = y > 0 ? "down" : "up";
                        if (y > 0 && y < 20)
                        {
                            _pc.Down();
                        }
                        else if (y < 0 && y > -20)
                        {
                            _pc.Jump();
                            Debug.Log("jump");
                        }
                    }
                }
            }
                        
        }

        #region DebugGUI
        
        void OnGUI()
        {
            // for showing debugging information for mechanic move and grabber
            if (!_debugging) { return; }
            GUI.Label(new Rect(10, 10, 100, 200), "Debugging Info:");
            GUI.contentColor = Color.white;
            GUI.Label(new Rect(10, 40, 500, 200), $"input: {_inputD}");
            GUI.Label(new Rect(10, 55, 500, 200), $" direct input x: {_input.x}\n direct input y : {_input.y}");
        }
        
        #endregion
    }
}
