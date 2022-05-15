using UnityEngine;

namespace Game.Units.Movement
{
    public sealed class RigidbodyMovementController : MovementController
    {
        [SerializeField]
        private Rigidbody _rigidbody = null;

        [SerializeField]
        private float _movementSpeed = 100f;

        private bool _updateMovement = false;
        private Vector3 _movementDirection = new Vector3();

        private void FixedUpdate()
        {
            if (!_updateMovement)
            {
                return;
            }

            var direction = transform.TransformDirection(_movementDirection);
            _rigidbody.velocity = direction * _movementSpeed * Time.fixedDeltaTime;
            _updateMovement = false;
        }

        public override void Move(Vector3 direction)
        {
            _movementDirection = direction;
            _updateMovement = true;
        }
    }
}