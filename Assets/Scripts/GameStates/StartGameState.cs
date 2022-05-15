using Game.StateMachine;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Game.GameStates
{
    public class StartGameState : State
    {
        private bool _sceneLoaded = false;
        
        public StartGameState()
        {
            DoneRequirement = new FlagRequirement(() => _sceneLoaded);
        }

        public override State GetNextState()
        {
            return new GameState();
        }

        public override void OnEnter()
        {
            base.OnEnter();
            
            // TODO: Extract scene name somewhere else
            var asyncOperation = SceneManager.LoadSceneAsync("Gameplay", LoadSceneMode.Additive);
            asyncOperation.completed += OnSceneLoaded;
        }

        private void OnSceneLoaded(AsyncOperation obj)
        {
            _sceneLoaded = true;
        }
    }
}