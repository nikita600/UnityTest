using System;
using Game.StateMachine;
using Game.UI;
using Level;
using Object = UnityEngine.Object;

namespace Game.GameStates
{
    public sealed class GameState : State
    {
        private IUnitManager _unitManager;
        private FinishCollider _finishCollider;
        private PlayerController _playerController;
        
        public GameState()
        {
            DoneRequirement = new FlagRequirement(IsFinished);
        }

        public override State GetNextState()
        {
            if (!IsPlayerDead() && IsPlayerOnFinish() && IsAllEnemiesDead())
            {
                return new WinGameState();
            }

            return new FailGameState();
        }

        public override void OnEnter()
        {
            base.OnEnter();

            var uiManager = Services.Get<IUiManager>();
            uiManager.SetCrosshairState(false);

            _unitManager = Services.Get<IUnitManager>();
            
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
            return IsPlayerDead() || IsPlayerOnFinish() && IsAllEnemiesDead();
        }

        private bool IsPlayerDead()
        {
            return _playerController != null && _playerController.Health.IsDead;
        }
        
        private bool IsPlayerOnFinish()
        {
            return _finishCollider != null && _finishCollider.PlayerEntered;
        }

        private bool IsAllEnemiesDead()
        {
            return _unitManager.GetUnitsCount<EnemyController>() == 0;
        }
    }
}