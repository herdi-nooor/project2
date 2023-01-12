using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LightFight.Enemy
{
    public class BaseEnemy : MonoBehaviour
    {
        [SerializeField] private float _moveSpeed;
        [SerializeField] private Vector2 _moveDirect;
        private Rigidbody2D  _rg;
        public Camera m_camera;

        private float spTmp;
        private bool onFlip;

        [SerializeField] private bool _facingRight = false;


        private void Start() {
            _rg = GetComponent<Rigidbody2D>();
        }

        void FixedUpdate()
        {
            _rg.velocity = new Vector2(_moveSpeed * _moveDirect.x * Time.deltaTime, _rg.velocity.y);
        }

        private void Update() 
        {
            OnEdge();
            int r = Random.Range(0, 150) ;
            if (r == 3 && onFlip == false)
            {
                StartCoroutine(FlipOnRun());
            }
        }

        private void Flip(){
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
    
        private IEnumerator FlipOnEdge()
        {
            onFlip = true;
            spTmp = _moveSpeed;
            _moveSpeed = 0.0f;
            
            Flip();

            yield return new WaitForSeconds(1); 
            transform.Rotate(0.0f, 180.0f, 0.0f);

            yield return new WaitForSeconds(1.5f);
            _moveSpeed = spTmp;

            yield return new WaitForSeconds(0.5f);
            onFlip = false;
        }

        private IEnumerator FlipOnRun()
        {
            onFlip = true;
            spTmp = _moveSpeed;
            _moveSpeed = 0.0f;

            Flip();
            
            yield return new WaitForSeconds(0.5f); 
            transform.Rotate(0.0f, 180.0f, 0.0f);

            yield return new WaitForSeconds(1f);
            _moveSpeed = spTmp;

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
