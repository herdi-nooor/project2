using UnityEngine;

namespace Script.Scene.GamePlay.Player
{
    public class GroundedCheck : MonoBehaviour
    {
        private PlayerController _player;
        [SerializeField] private float _groundCheckRadius;
        [SerializeField] private LayerMask _whatIsGround;

        private void Awake()
        {
            _player = transform.GetComponentInParent<PlayerController>();
        }

        private void FixedUpdate()
        {
            CheckSorounding();
        }

        private void CheckSorounding()
        {
            _player.IsGrounded = Physics2D.OverlapCircle(transform.position, _groundCheckRadius, _whatIsGround);
        }
        
        private void OnDrawGizmos()
        {
            Gizmos.DrawWireSphere(transform.position, _groundCheckRadius);
        }
    }
}