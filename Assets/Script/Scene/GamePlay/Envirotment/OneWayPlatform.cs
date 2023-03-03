using Script.Scene.GamePlay.Player;
using UnityEngine;

namespace Script.Scene.GamePlay.Envirotment
{
    public class OneWayPlatform : MonoBehaviour
    {
        [SerializeField] private PlayerController _playerController;
        private PlatformEffector2D _platformEffector2D;
        private bool oncoll;

        private void Awake()
        {
            _platformEffector2D = GetComponent<PlatformEffector2D>();
        }

        private void OnCollisionEnter2D(Collision2D col)
        {
            if (col.collider.CompareTag("Player"))
            {
                _playerController = col.gameObject.GetComponent<PlayerController>();
            }
        }

        private void Update()
        {
            if (_playerController == null)
            {
                return;
            }
            if (_playerController.FallTrough)
            {
                _platformEffector2D.rotationalOffset = 180;
            }
        }

        private void OnCollisionExit2D(Collision2D other)
        {
            if (other.collider.CompareTag("Player"))
            {
                oncoll = true;
                if (oncoll)
                {
                    oncoll = false;
                    Invoke("Resett", 0.1f);
                }
            }
        }

        private void Resett()
        {
            if (_playerController != null && _playerController.FallTrough)
            {
                _platformEffector2D.rotationalOffset = 0;
                _playerController.FallTrough = false;
                _playerController = null;
            }
        }
    }
    
}
