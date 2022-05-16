using Units.Weapon.Projectile;
using UnityEngine;

namespace Units.Weapon
{
    public sealed class ProjectileWeaponController : WeaponController
    {
        [SerializeField]
        private Transform _muzzleTransform = null;
        
        [SerializeField]
        private ProjectileController _projectilePrefab = null;

        [SerializeField]
        private float _projectileSpeed = 100f;
        
        [SerializeField]
        private int _projectilesPerSecond = 3;

        private float _lastFireTime = 0f;
        private float _shootCooldown = 0f;

        private void Awake()
        {
            _shootCooldown = 1f / _projectilesPerSecond;
        }

        public override void Fire()
        {
            var currentTime = Time.time;
            if (currentTime - _lastFireTime < _shootCooldown)
            {
                return;
            }
            
            var projectileInstance = Instantiate(_projectilePrefab);
            projectileInstance.transform.position = _muzzleTransform.position;
            projectileInstance.Fire(_muzzleTransform.forward * _projectileSpeed, () =>
            {
                Destroy(projectileInstance.gameObject);
            });

            _lastFireTime = Time.time;
        }
    }
}