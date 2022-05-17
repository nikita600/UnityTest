using Game.InputSystem;
using Game.UI;
using Game.Units.Movement;
using Units.Weapon;
using UnityEngine;

namespace Game
{
    public class PlayerController : UnitController
    {
        [SerializeField]
        private CameraController _cameraController = null;

        [SerializeField]
        private MovementController _movementController = null;

        [SerializeField]
        private WeaponController _weaponController = null;

        private bool _isFalling = false;
        private IUiManager _uiManager = null;
        private IInputListener _inputListener = null;

        protected override void OnEnable()
        {
            base.OnEnable();

            _uiManager = Services.Get<IUiManager>();
            
            _inputListener = Services.Get<IInputListener>();
            _inputListener.Fire += OnFire;
            _inputListener.Look += OnLook;
            _inputListener.Move += OnMove;
        }

        protected override void OnDisable()
        {
            base.OnDisable();

            _inputListener.Fire -= OnFire;
            _inputListener.Look -= OnLook;
            _inputListener.Move -= OnMove;
            _inputListener = null;

            _uiManager = null;
        }

        private void FixedUpdate()
        {
            _isFalling = Physics.Raycast(transform.position, Vector3.down, out var hitInfo) 
                         && _colliderTagSettings.IsDeathCollider(hitInfo.collider);

            var viewPosition = _cameraController.CameraPosition;
            var viewDirection = _cameraController.ViewDirection;
            var isEnemyInCrosshair = Physics.Raycast(viewPosition, viewDirection, out var viewHitInfo) 
                                     && _colliderTagSettings.IsEnemyColliderTag(viewHitInfo.collider);
            
            _uiManager.SetCrosshairState(isEnemyInCrosshair);
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
    }
}