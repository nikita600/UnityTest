using System;

namespace Game.InputSystem.Commands
{
    public abstract class InputCommand
    {
        protected readonly InputListener InputListener;

        protected InputCommand(InputListener inputListener)
        {
            InputListener = inputListener;
        }

        public abstract void Execute();
    }
}