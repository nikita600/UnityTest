using Game;
using Units.Weapon.Projectile;
using UnityEngine;

namespace Units.Weapon
{
    public sealed class ProjectileWeaponController : WeaponController
    {
        [SerializeField]
        private CameraController _cameraController = null;
        
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

            Vector3 forceDirection;
            var muzzlePosition = _muzzleTransform.position;
            if (_cameraController != null)
            {
                var viewCenterWorldPosition = _cameraController.ViewCenterWorldPosition;
                forceDirection = viewCenterWorldPosition - muzzlePosition;
                forceDirection /= forceDirection.magnitude;
            }
            else
            {
                forceDirection = _muzzleTransform.forward;
            }

            var projectileInstance = Instantiate(_projectilePrefab);
            projectileInstance.transform.position = muzzlePosition;
            projectileInstance.Fire(forceDirection * _projectileSpeed, () =>
            {
                Destroy(projectileInstance.gameObject);
            });

            _lastFireTime = Time.time;
        }
    }
}