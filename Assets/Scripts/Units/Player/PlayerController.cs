using Game.InputSystem;
using Units.Health;
using UnityEngine;

namespace Game
{
    public class PlayerController : MonoBehaviour, IHealthContainer
    {
        [SerializeField]
        private HealthSettings _baseHealthSettings = null;
        
        private Health _health = new Health();
        private IInputListener _inputListener = null;

        public Health Health => _health;

        private void OnEnable()
        {
            _baseHealthSettings.ApplyTo(_health);
            
            _health.Dead += OnDead;
            
            _inputListener = Services.Get<IInputListener>();
            _inputListener.Fire += OnFire;
            _inputListener.Look += OnLook;
            _inputListener.Move += OnMove;
        }

        private void OnDisable()
        {
            _health.Dead -= OnDead;
            
            _inputListener.Fire -= OnFire;
            _inputListener.Look -= OnLook;
            _inputListener.Move -= OnMove;
            _inputListener = null;
        }

        private void OnMove(Vector2 moveDirection)
        {
            Debug.LogError("Move: " + moveDirection.ToString("F4"));
        }

        private void OnLook(Vector3 lookDirection)
        {
            Debug.LogError("Look: " + lookDirection.ToString("F4"));
        }

        private void OnFire()
        {
            Debug.LogError("Fire");
        }
        
        private void OnDead()
        {
            gameObject.SetActive(false);
        }
    }
}