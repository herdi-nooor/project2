using UnityEngine;

namespace Script.Scene.Player
{
    public class LightColliderChecker : MonoBehaviour
    {
        // Start is called before the first frame update
        private void OnTriggerEnter2D(Collider2D other) {
            Debug.Log(other);
        }
    }
}
