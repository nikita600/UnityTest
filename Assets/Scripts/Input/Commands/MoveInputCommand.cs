using UnityEngine;

namespace Game.InputSystem.Commands
{
    public sealed class MoveInputCommand : InputCommand
    {
        public MoveInputCommand(InputListener inputListener) : base(inputListener)
        {
        }
        
        public override void Execute()
        {
            var changed = false;
            var direction = new Vector2();
            
            if (Input.GetKey(KeyCode.W))
            {
                direction.y = 1f;
                changed = true;
            }
            else if (Input.GetKey(KeyCode.S))
            {
                direction.y = -1f;
                changed = true;
            }

            if (Input.GetKey(KeyCode.A))
            {
                direction.x = -1f;
                changed = true;
            }
            else if (Input.GetKey(KeyCode.D))
            {
                direction.x = 1f;
                changed = true;
            }

            if (changed)
            {
                InputListener.ExecuteMove(direction);
            }
        }
    }
}