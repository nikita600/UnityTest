using Game.StateMachine;
using UnityEngine;

namespace Game.GameStates
{
    public class FailGameState : State
    {
        private const float Timeout = 3f;
        
        private float _startTime = 0f;
        private bool _isFinished = false;
        
        public FailGameState()
        {
            DoneRequirement = new FlagRequirement(() => _isFinished);
        }

        public override State GetNextState()
        {
            return new ReloadGameState();
        }

        public override void OnEnter()
        {
            base.OnEnter();

            _startTime = Time.time;
        }

        public override void OnUpdate()
        {
            base.OnUpdate();

            if (Time.time - _startTime >= Timeout)
            {
                _isFinished = true;
            }
        }
    }
}