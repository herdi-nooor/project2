using LightFight.Global;
using LightFight.Message;
using UnityEngine;

namespace Script.Scene.Player
{
    public class PlayerController : MonoBehaviour

    { 
        [HideInInspector] public bool IsGrounded, FallTrough;
        public DataCharacter DataCharater;
        private float _moveSpeed = 3f, _jumpForce = 5f;
        private Vector2 _moveDirect;
        private Vector3 _lastPosition;
        private bool _facingRight = true, _isJump, isRun = true;
        private Rigidbody2D rg;
        private Animator anim;

        private void Awake() {
            _moveSpeed = DataCharater.Speed;
            _jumpForce = DataCharater.JumpForce;
        }

        private void Start()
        {
            rg = GetComponent<Rigidbody2D>();
            _moveDirect.x = 1f;
            anim = GameObject.Find("Player/GFX").GetComponent<Animator>();
        }

        private void FixedUpdate()
        {
            MovePlayer();
            CheckPlayerFacing();
            DebugOnPLay.instance.Fall = FallTrough;
        }

        private void Update()
        {
            UpdateAnimaions();
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

        private void UpdateAnimaions()
        {
            if (transform.position != _lastPosition)
            {
                isRun = true;
            }
            else
            {
                isRun = false;
            }

            _lastPosition = transform.position;
            anim.SetBool("inRun", isRun);
        }

        private void OnTriggerEnter2D(Collider2D other) {
            EventManager.TriggerEvent("HitEnemy", new HitEnemyMessage(1, other.gameObject));
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
