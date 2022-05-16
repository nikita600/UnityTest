using System;
using UnityEngine;

namespace Units.Weapon.Projectile
{
    public class RigidbodyProjectileController : ProjectileController
    {
        [SerializeField]
        private Rigidbody _rigidbody = null;

        private Action _onDone = null;
        
        public override void Fire(Vector3 force, Action onDone)
        {
            _onDone = onDone;
            _rigidbody.AddForce(force, ForceMode.Impulse);
        }

        private void OnCollisionEnter(Collision other)
        {
            _onDone?.Invoke();
        }
    }
}