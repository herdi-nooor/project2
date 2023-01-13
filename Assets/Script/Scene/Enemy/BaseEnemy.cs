using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LightFight.Enemy
{
    public abstract class BaseEnemy : MonoBehaviour
    {
        public Camera m_camera;
        [HideInInspector] public float _moveSpeed = 0 , _speedTmp = 0;
        [HideInInspector] public Vector2 _moveDirect;
        [HideInInspector] public Rigidbody2D  _rg;
        [HideInInspector] public bool onFlip = false, _facingRight = false;
        [HideInInspector] public TypeEnemy _typeEnemy;
        public BaseDataEnemy DataEnemy;

        public void Move() 
        {
            _rg.velocity = new Vector2(_moveSpeed * _moveDirect.x * Time.deltaTime, _rg.velocity.y);
        }

        public void Flip(){
            if (_facingRight == false && _moveDirect.x > 0)
            {
                _moveDirect.x = -1;
                _facingRight = true;
            }
            else if (_facingRight == true && _moveDirect.x < 0)
            {
                _moveDirect.x = 1;
                _facingRight = false;
            }
        }
    
        public IEnumerator FlipOnEdge()
        {
            onFlip = true;
            _speedTmp = _moveSpeed;
            _moveSpeed = 0.0f;
            
            Flip();

            yield return new WaitForSeconds(1); 
            transform.Rotate(0.0f, 180.0f, 0.0f);

            yield return new WaitForSeconds(1.5f);
            _moveSpeed = _speedTmp;

            yield return new WaitForSeconds(0.5f);
            onFlip = false;
        }

        public IEnumerator FlipOnRun()
        {
            onFlip = true;
            _speedTmp = _moveSpeed;
            _moveSpeed = 0.0f;

            Flip();
            
            yield return new WaitForSeconds(0.5f); 
            transform.Rotate(0.0f, 180.0f, 0.0f);

            yield return new WaitForSeconds(1f);
            _moveSpeed = _speedTmp;

            onFlip = false;
        }

        public void OnEdge()
        {
            float frustrumPositionR = Camera.main.ViewportToWorldPoint(new Vector2(1, 0)).x - 0.4f;
            float frustrumPositionL = Camera.main.ViewportToWorldPoint(new Vector2(0 , 0)).x + 0.4f;

            if ((transform.position.x > frustrumPositionR) || (transform.position.x < frustrumPositionL))
            {
                if (onFlip == false) StartCoroutine(FlipOnEdge());
            }
        }

    }
    
}
