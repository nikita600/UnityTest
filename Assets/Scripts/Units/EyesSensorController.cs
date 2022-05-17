using UnityEngine;
using Utilities;

namespace Game
{
    public class EyesSensorController : MonoBehaviour
    {
        [SerializeField]
        private ColliderTagSettings _colliderTagSettings = null;

        [SerializeField]
        private bool _playerTarget = false;

        public bool IsTargetVisible { get; private set; } = false;

        private void OnTriggerEnter(Collider other)
        {
            IsTargetVisible = _playerTarget 
                ? _colliderTagSettings.IsPlayerCollider(other) 
                : _colliderTagSettings.IsEnemyCollider(other);
        }

        private void OnTriggerExit(Collider other)
        {
            IsTargetVisible = !(_playerTarget 
                ? _colliderTagSettings.IsPlayerCollider(other) 
                : _colliderTagSettings.IsEnemyCollider(other));
        }
    }
}