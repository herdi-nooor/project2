using Script.Scene.Global;
using UnityEngine;
using Inputs = UnityEngine.Input;
using TouchPhases = UnityEngine.TouchPhase;
using Touchs = UnityEngine.Touch;

namespace Script.Scene.GamePlay.Player.Input
{
    public class PlayerInputHandler : MonoBehaviour
    {
        private PlayerController _pc;
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
                    DebugOnPLay.instance._input.Set(x, y);
                    if (Mathf.Abs(x) == 0 && Mathf.Abs(y) == 0)
                    {
                        DebugOnPLay.instance._inputD = "tapped";
                    }
                    else if (Mathf.Abs(x) > Mathf.Abs(y))
                    {
                        DebugOnPLay.instance._inputD = x > 0 ? "left" : "right";
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
                        DebugOnPLay.instance._inputD = y > 0 ? "down" : "jump";
                        if (y > 0 && y < 80)
                        {
                            _pc.Down();
                        }
                        else if (y < 0 && y > -80)
                        {
                            _pc.Jump();
                        }
                    }
                }
            }
                        
        }

    }
}
