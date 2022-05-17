using Units.Health;
using UnityEngine;
using Utilities;

namespace Game
{
    public abstract class UnitController : MonoBehaviour, IHealthContainer
    {
        [SerializeField]
        protected ColliderTagSettings _colliderTagSettings = null;
        
        [SerializeField]
        private HealthSettings _baseHealthSettings = null;
        
        public Health Health { get; } = new Health();

        protected virtual void OnEnable()
        {
            _baseHealthSettings.ApplyTo(Health);
            
            Health.Dead += OnDead;
        }

        protected virtual void OnDisable()
        {
            Health.Dead -= OnDead;
        }

        protected void OnCollisionEnter(Collision other)
        {
            if (_colliderTagSettings.IsProjectileCollider(other.collider))
            {
                DoDamage(other.gameObject);
            }
        }

        private void OnDead()
        {
            enabled = false;

            OnDeadInternal();
        }

        protected virtual void OnDeadInternal()
        {
        }

        private void DoDamage(GameObject projectile)
        {
            var damageContainer = projectile.GetComponent<IDamageContainer>();
            if (damageContainer != null)
            {
                Health.Damage(damageContainer.Damage);
            }
        }
    }
}