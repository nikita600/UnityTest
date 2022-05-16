using System;
using Game.InputSystem;
using Game.Units.Movement;
using Units.Health;
using Units.Weapon;
using UnityEngine;
using Utilities;

namespace Game
{
    public class PlayerController : MonoBehaviour, IHealthContainer
    {
        [SerializeField]
        private HealthSettings _baseHealthSettings = null;

        [SerializeField]
        private ColliderTagSettings _colliderTagSettings = null;
        
        [SerializeField]
        private CameraController _cameraController = null;

        [SerializeField]
        private MovementController _movementController = null;

        [SerializeField]
        private WeaponController _weaponController = null;

        private bool _isFalling = false;
        private IInputListener _inputListener = null;
        
        public Health Health { get; } = new Health();

        private void OnEnable()
        {
            _baseHealthSettings.ApplyTo(Health);
            Health.Dead += OnDead;
            
            _inputListener = Services.Get<IInputListener>();
            _inputListener.Fire += OnFire;
            _inputListener.Look += OnLook;
            _inputListener.Move += OnMove;
        }

        private void OnDisable()
        {
            Health.Dead -= OnDead;
            
            _inputListener.Fire -= OnFire;
            _inputListener.Look -= OnLook;
            _inputListener.Move -= OnMove;
            _inputListener = null;
        }

        private void FixedUpdate()
        {
            if (Physics.Raycast(transform.position, Vector3.down, out var hitInfo) 
                && hitInfo.collider.gameObject.tag.Equals(_colliderTagSettings.DeathColliderTag, StringComparison.Ordinal))
            {
                _isFalling = true;
            }
            else
            {
                _isFalling = false;
            }
        }

        private void OnMove(Vector2 moveDirection)
        {
            if (!_isFalling)
            {
                _movementController.Move(new Vector3(moveDirection.x, 0f, moveDirection.y));
            }
        }
        
        private void OnLook(Vector2 lookDirection)
        {
            _cameraController.Rotate(lookDirection);
        }

        private void OnFire()
        {
            _weaponController.Fire();
        }
        
        private void OnDead()
        {
            enabled = false;
        }
    }
}