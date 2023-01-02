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

        [SerializeField] private bool _facingRight = false;


        private void Start() {
            _rg = GetComponent<Rigidbody2D>();
        }

        void FixedUpdate()
        {
                _rg.velocity = new Vector2(_moveSpeed * _moveDirect.x * Time.deltaTime, _rg.velocity.y);
        }

        private void OnCollisionEnter2D(Collision2D other) {
            if (other.collider.CompareTag("Wall"))
            {
                Flip();
            }
        }
    
         private void Flip()
        {
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
            transform.Rotate(0.0f, 180.0f, 0.0f);
        }

        public void OnEdge()
        {
            float frustrumPositionUp = Camera.main.ViewportToWorldPoint(new Vector2(0, 1)).y;
            float frustrumPositiondown = Camera.main.ViewportToWorldPoint(new Vector2(0 , 0)).y;

            if ((transform.position.y > frustrumPositionUp) || (transform.position.y < frustrumPositiondown))
            {
                //DestroyBullet(gameObject);
            }
        }

    }
    
}
