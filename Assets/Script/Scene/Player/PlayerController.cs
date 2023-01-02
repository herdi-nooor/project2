using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using LightFight.Global;

namespace LightFight.Player
{
    public class PlayerController : MonoBehaviour

    { 
        [HideInInspector] public bool IsGrounded;
        [HideInInspector] public bool FallTrough;
        public DataCharacter DataCharater;
        private float _moveSpeed = 3f;
        private float _jumpForce = 5f;
        private Vector2 _moveDirect;
        private bool _facingRight = true;
        private bool _isJump;
        private Rigidbody2D rg;

        private void Awake() {
            _moveSpeed = DataCharater.Speed;
            _jumpForce = DataCharater.JumpForce;
        }

        private void Start()
        {
            rg = GetComponent<Rigidbody2D>();
            _moveDirect.x = 1f;

        }

        private void FixedUpdate()
        {
            MovePlayer();
            CheckPlayerFacing();
            DebugOnPLay.instance.Fall = FallTrough;
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

        private void OnCollisionStay2D(Collision2D other) {
            if (other.collider.CompareTag("Wall"))
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
            rg.velocity = new Vector2(_moveDirect.x * _moveSpeed , rg.velocity.y);
        }

        public void Move(Vector2 movedirect)
        {
            _moveDirect = movedirect;
        }

        public void Jump()
        {
            if (_isJump == false && IsGrounded)
            {
                rg.velocity =new Vector2(rg.velocity.x, _jumpForce);
                _isJump = true;
            }
            else if(IsGrounded)
            {
                _isJump = false;
            }
        }

        public void Down()
        {
            FallTrough = true;
        }

    }
}
