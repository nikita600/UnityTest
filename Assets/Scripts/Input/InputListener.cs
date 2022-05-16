using System;
using System.Collections.Generic;
using Game.InputSystem.Commands;
using UnityEngine;

namespace Game.InputSystem
{
    public sealed class InputListener : IInputListener
    {
        public event Action Fire;
        public event Action<Vector2> Move;
        public event Action<Vector2> Look;

        private readonly InputCommand[] _inputCommands;

        public InputListener()
        {
            _inputCommands = new InputCommand[]
            {
                new FireInputCommand(this),
                new MoveInputCommand(this),
                new LookInputCommand(this)
            };
        }

        public void Update()
        {
            for (int i = 0, size = _inputCommands.Length; i < size; i++)
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

