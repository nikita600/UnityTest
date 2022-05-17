using Game.StateMachine;
using Game.UI;
using UnityEngine;

namespace Game.GameStates
{
    public class WinGameState : State
    {
        private const float Timeout = 3f;
        
        private float _startTime = 0f;
        private bool _isFinished = false;
        
        public WinGameState()
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

            var uiManager = Services.Get<IUiManager>();
            uiManager.ShowWinView();
            
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