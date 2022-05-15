using Units.Health;
using UnityEngine;

namespace Level
{
    public sealed class DeathCollider : MonoBehaviour
    {
        private void OnCollisionEnter(Collision other)
        {
            var healthContainer = other.gameObject.GetComponent<IHealthContainer>();
            if (healthContainer != null)
            {
                healthContainer.Health.Death();
            }
        }
    }
}