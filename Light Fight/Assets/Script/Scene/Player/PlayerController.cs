using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace LightFight.Player
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private float _moveSpeed = 3f;
        [SerializeField] private float _jumpForce = 5f;
        [SerializeField] private Vector2 _moveDirect;
        private bool _facingRight = true;
        private Rigidbody2D rg;

        private void Start()
        {
            rg = GetComponent<Rigidbody2D>();
        }

        private void Update()
        {
            MovePlayer();
            CheckPlayerFacing();
            Debug.Log($"move direct {_moveDirect}");
        }

        private void CheckPlayerFacing()
        {
            if (_facingRight && _moveDirect.x < 0)
            {
                Flip();
            }
            else if (!_facingRight && _moveDirect.x > 0)
            {
                Flip();
            }
        }

        private void Flip()
        {
            _facingRight = !_facingRight;
            transform.Rotate(0.0f, 180.0f, 0.0f);
        }

        private void MovePlayer()
        {
            rg.velocity = _moveDirect;
        }

        public void Move(Vector2 movedirect)
        {
            _moveDirect = new Vector2(_moveSpeed * movedirect.x, movedirect.y);
        }

        public void Jump(Vector2 movedirect)
        {
           _moveDirect = new Vector2(movedirect.x, movedirect.y * _jumpForce );
        }
    }
}
