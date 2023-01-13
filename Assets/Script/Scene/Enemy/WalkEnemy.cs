using System;
using LightFight.Global;
using LightFight.Message;
using UnityEngine;
using Random = UnityEngine.Random;


namespace LightFight.Enemy
{
    public class WalkEnemy : BaseEnemy, IDamageable
    {
        public int CurrentHp { get; set; }
        public int MaxHp { get; private set; }

        #region Pubsub
        private void OnEnable()
        {
            EventManager.StartListening("HitEnemy", Damege);
        }
        private void OnDisable()
        {
            EventManager.StopListening("HitEnemy", Damege);
        }
        #endregion

        private void Awake()
        {
            _moveSpeed = DataEnemy.MoveSpeed;
            _facingRight = DataEnemy.FacingRight;
            _typeEnemy = DataEnemy.TypeEnemy;

            if (_facingRight == false ){
                _moveDirect = new Vector2(1, 0);
            }else{
                _moveDirect = new Vector2(-1, 0);
                transform.Rotate(0.0f, 180.0f, 0.0f);
            }
            
            Debug.Log(DataEnemy.MoveSpeed);

            _rg = GetComponent<Rigidbody2D>();
            MaxHp = base.DataEnemy.MaxHp;
        }
        private void Start()
        {
            CurrentHp = MaxHp;
        }

        private void Update()
        {
            if (CurrentHp < 1) Debug.Log("enemy die");
            OnEdge();
            int r = Random.Range(0, 150) ;
            if (r == 3 && onFlip == false)
            {
                StartCoroutine(FlipOnRun());
            }
        }
        protected void FixedUpdate()
        {
            Move();
        }

        public void Damege(object data)
        {
            HitEnemyMessage hit = (HitEnemyMessage)data;
            CurrentHp -= hit.Damage;
        }
        
    }
}
