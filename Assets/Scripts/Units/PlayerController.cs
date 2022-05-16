using System;
using Game.InputSystem;
using Game.Units.Movement;
using Units.Health;
using UnityEngine;

namespace Game
{
    public class PlayerController : MonoBehaviour, IHealthContainer
    {
        [SerializeField]
        private HealthSettings _baseHealthSettings = null;

        [SerializeField]
        private CameraController _cameraController = null;

        [SerializeField]
        private MovementController _movementController = null;

        [SerializeField]
        private string _deathColliderTag = "DeathCollider";

        private bool _isFalling = false;
        private IInputListener _inputListener = null;
        
        public Health Health { get; } = new Health();

        private void OnEnable()
        {
            _baseHealthSettings.ApplyTo(Health);
            Health.Dead += OnDead;
            
            StartListenInput();
        }

        private void OnDisable()
        {
            Health.Dead -= OnDead;
            
            StopListenInput();
        }

        private void FixedUpdate()
        {
            if (Physics.Raycast(transform.position, Vector3.down, out RaycastHit hitInfo) 
                && hitInfo.collider.gameObject.tag.Equals(_deathColliderTag, StringComparison.Ordinal))
            {
                _isFalling = true;
            }
            else
            {
                _isFalling = false;
            }
        }

        private void StartListenInput()
        {
            _inputListener = Services.Get<IInputListener>();
            _inputListener.Fire += OnFire;
            _inputListener.Look += OnLook;
            _inputListener.Move += OnMove;
        }

        private void StopListenInput()
        {
            _inputListener.Fire -= OnFire;
            _inputListener.Look -= OnLook;
            _inputListener.Move -= OnMove;
            _inputListener = null;
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
            //Debug.Log("Fire");
        }
        
        private void OnDead()
        {
            gameObject.SetActive(false);
        }
    }
}