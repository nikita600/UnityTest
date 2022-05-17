using Units.Health;
using UnityEngine;

namespace Level
{
    public sealed class DeathCollider : ColliderController
    {
        private void OnCollisionEnter(Collision other)
        {
            var otherCollider = other.collider;
            if (!_colliderTagSettings.IsPlayerCollider(otherCollider) 
                && !_colliderTagSettings.IsEnemyCollider(otherCollider))
            {
                return;
            }
            
            var healthContainer = other.gameObject.GetComponent<IHealthContainer>();
            if (healthContainer != null)
            {
                healthContainer.Health.Death();
            }
        }
    }
}