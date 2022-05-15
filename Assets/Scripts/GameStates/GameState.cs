using System;
using Game.StateMachine;
using Level;
using Object = UnityEngine.Object;

namespace Game.GameStates
{
    public sealed class GameState : State
    {
        private State _nextState;
        private FinishCollider _finishCollider;
        private PlayerController _playerController;
        
        public GameState()
        {
            DoneRequirement = new FlagRequirement(IsFinished);
        }

        public override State GetNextState()
        {
            if (_playerController != null 
                &&!_playerController.Health.IsDead
                && _finishCollider != null 
                && _finishCollider.PlayerEntered)
            {
                return new WinGameState();
            }

            return new FailGameState();
        }

        public override void OnEnter()
        {
            base.OnEnter();

            _finishCollider = Object.FindObjectOfType<FinishCollider>();
            if (_finishCollider == null)
            {
                throw new Exception($"{nameof(FinishCollider)} not found.");
            }
            
            _playerController = Object.FindObjectOfType<PlayerController>();
            if (_playerController == null)
            {
                throw new Exception($"{nameof(PlayerController)} not found.");
            }
        }

        private bool IsFinished()
        {
            return _finishCollider != null && _finishCollider.PlayerEntered ||
                   _playerController != null && _playerController.Health.IsDead;
        }
    }
}