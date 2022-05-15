using UnityEngine;

namespace Game.InputSystem.Commands
{
    public sealed class FireInputCommand : InputCommand
    {
        public FireInputCommand(InputListener inputListener) : base(inputListener)
        {
        }

        public override void Execute()
        {
            if (Input.GetMouseButtonDown(0))
            {
                InputListener.ExecuteFire();
            }
        }
    }
}