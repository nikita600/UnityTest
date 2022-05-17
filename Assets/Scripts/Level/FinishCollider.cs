using Game;
using UnityEngine;

namespace Level
{
    public sealed class FinishCollider : ColliderController
    {
        public bool PlayerEntered { get; private set; }
        
        private void OnCollisionEnter(Collision other)
        {
            if (!_colliderTagSettings.IsPlayerCollider(other.collider))
            {
                return;
            }
            
            var playerController = other.gameObject.GetComponent<PlayerController>();
            if (playerController != null)
            {
                PlayerEntered = true;
            }
        }
    }
}