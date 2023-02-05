using UnityEngine;

namespace Script.Scene.Player
{
    public class LightColliderChecker : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D other) {
            Debug.Log(other);
        }
    }
}
