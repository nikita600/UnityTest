using System;
using System.Collections.Generic;
using Game.InputSystem.Commands;
using UnityEngine;

namespace Game.InputSystem
{
    public sealed class InputListener : MonoBehaviour, IInputListener
    {
        public event Action Fire;
        public event Action<Vector2> Move;
        public event Action<Vector2> Look;

        private readonly List<InputCommand> _inputCommands = new List<InputCommand>();

        private void Awake()
        {
            _inputCommands.Clear();
            _inputCommands.Add(new FireInputCommand(this));
            _inputCommands.Add(new MoveInputCommand(this));
            _inputCommands.Add(new LookInputCommand(this));
        }

        private void LateUpdate()
        {
            for (int i = 0, size = _inputCommands.Count; i < size; i++)
            {
                var inputCommand = _inputCommands[i];
                inputCommand.Execute();
            }
        }

        internal void ExecuteFire()
        {
            Fire?.Invoke();
        }

        internal void ExecuteMove(Vector2 direction)
        {
            Move?.Invoke(direction);
        }

        internal void ExecuteLook(Vector2 direction)
        {
            Look?.Invoke(direction);
        }
    }
}

