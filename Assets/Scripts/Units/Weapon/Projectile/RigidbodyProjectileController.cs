using System;
using Game.Effects;
using UnityEngine;

namespace Units.Weapon.Projectile
{
    public class RigidbodyProjectileController : ProjectileController
    {
        [SerializeField]
        private Rigidbody _rigidbody = null;

        [SerializeField]
        private EffectController _doneEffect = null;
        
        private Action _onDone = null;
        
        public override void Fire(Vector3 force, Action onDone)
        {
            _onDone = onDone;
            _rigidbody.AddForce(force, ForceMode.Impulse);
        }

        private void OnCollisionEnter(Collision other)
        {
            _onDone?.Invoke();

            ShowDoneEffect(other);
        }

        private void ShowDoneEffect(Collision other)
        {
            if (_doneEffect == null)
            {
                return;
            }
            
            var effectInstance = Instantiate(_doneEffect, other.transform.position, Quaternion.identity);
            effectInstance.Show();
        }
    }
}