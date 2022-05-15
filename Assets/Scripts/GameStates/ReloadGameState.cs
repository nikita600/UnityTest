using Game.StateMachine;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Game.GameStates
{
    public class ReloadGameState : State
    {
        private bool _sceneUnloaded = false;
        
        public ReloadGameState()
        {
            DoneRequirement = new FlagRequirement(() => _sceneUnloaded);
        }
        
        public override State GetNextState()
        {
            return new StartGameState();
        }

        public override void OnEnter()
        {
            base.OnEnter();

            // TODO: Extract scene name somewhere else
            var asyncOperation = SceneManager.UnloadSceneAsync("Gameplay");
            asyncOperation.completed += OnSceneUnloaded;
        }

        private void OnSceneUnloaded(AsyncOperation asyncOperation)
        {
            asyncOperation.completed -= OnSceneUnloaded;
            _sceneUnloaded = true;
        }
    }
}