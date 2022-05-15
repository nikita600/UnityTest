using UnityEngine;

namespace Game.InputSystem.Commands
{
    public sealed class LookInputCommand : InputCommand
    {
        public LookInputCommand(InputListener inputListener) : base(inputListener)
        {
        }

        public override void Execute()
        {
            var xAxis = Input.GetAxis("Mouse X");
            var yAxis = Input.GetAxis("Mouse Y");
            
            var lookDirection = new Vector2(xAxis, yAxis);
            if (lookDirection != Vector2.zero)
            {
                InputListener.ExecuteLook(lookDirection);
            }
        }
    }
}