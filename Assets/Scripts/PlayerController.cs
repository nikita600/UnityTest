using Game.InputSystem;
using UnityEngine;

namespace Game
{
    public class PlayerController : MonoBehaviour
    {
        private IInputListener _inputListener = null;

        private void Awake()
        {
            _inputListener = Services.Get<IInputListener>();
            _inputListener.Fire += OnFire;
            _inputListener.Look += OnLook;
            _inputListener.Move += OnMove;
        }

        private void OnDestroy()
        {
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
    }
}