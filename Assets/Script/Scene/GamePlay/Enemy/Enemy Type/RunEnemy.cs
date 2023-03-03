using Script.Global;
using Script.Message;
using Script.Scene.Global;
using UnityEngine;
using Random = UnityEngine.Random;


namespace Script.Scene.GamePlay.Enemy.Enemy_Type
{
    public class RunEnemy : BaseEnemy, IDamageable
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
            
            _rg = GetComponent<Rigidbody2D>();
            MaxHp = DataEnemy.MaxHp;
        }
        private void Start()
        {
            CurrentHp = MaxHp;
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
        protected void FixedUpdate()
        {
            Move();
        }

        public void Damege(object data)
        {
            HitEnemyMessage hit = (HitEnemyMessage)data;
            CurrentHp -= hit.Damage;
            if (CurrentHp <= 0)
            {
                hit.Enemy.gameObject.SetActive(false);
                CurrentHp = MaxHp;
            }
        }
        
    }
}
