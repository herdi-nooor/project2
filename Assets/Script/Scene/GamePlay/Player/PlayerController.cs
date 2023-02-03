using LightFight.Global;
using LightFight.Message;
using UnityEngine;

namespace Script.Scene.Player
{
    public class PlayerController : MonoBehaviour, IDataPersistence

    { 
        [HideInInspector] public bool IsGrounded, FallTrough;
        public DataCharacter DataCharater;
        private float _moveSpeed = 3f, _jumpForce = 5f;
        private Vector2 _moveDirect;
        private bool _facingRight = true, _isJump;
        private Rigidbody2D rg;

        private int point = 0;

        private void Awake() {
            _moveSpeed = DataCharater.Speed;
            _jumpForce = DataCharater.JumpForce;
        }

        private void Start()
        {
            rg = GetComponent<Rigidbody2D>();
            _moveDirect.x = 1f;
        }

        public void LoadData(GameData data)
        {
            this.point = data.point;
        }

        public void SaveData(ref GameData data)
        {
            data.point = this.point;
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

        private void OnTriggerEnter2D(Collider2D other) {
            Debug.Log(other.name);
            EventManager.TriggerEvent("HitEnemy", new HitEnemyMessage(1, other.gameObject));
            point += 2;
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
