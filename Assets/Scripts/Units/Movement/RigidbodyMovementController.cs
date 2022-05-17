using UnityEngine;

namespace Game.Units.Movement
{
    public sealed class RigidbodyMovementController : MovementController
    {
        [SerializeField]
        private Transform _pivot = null;

        [SerializeField]
        private Rigidbody _rigidbody = null;
        
        [SerializeField]
        private float _movementSpeed = 100f;

        private bool _updateMovement = false;
        private Vector3 _movementDirection = new Vector3();

        public override Vector3 Velocity => _rigidbody.velocity;
        
        private void Awake()
        {
            if (_pivot == null)
            {
                _pivot = transform;
            }
        }

        private void FixedUpdate()
        {
            if (!_updateMovement)
            {
                return;
            }
            
            var direction = _pivot.TransformDirection(_movementDirection);
            var velocity = direction * _movementSpeed * Time.fixedDeltaTime;
            velocity.y = 0f;

            _rigidbody.velocity = velocity;
            _updateMovement = false;
        }

        public override void Move(Vector3 direction)
        {
            _movementDirection = direction;
            _updateMovement = true;
        }
    }
}