using System.Collections.Generic;
using Game.InputSystem;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Game
{
    public class Bootstrapper : MonoBehaviour
    {
        [SerializeField]
        private InputListener _inputListener = null;

        [SerializeField]
        private string _gameplaySceneName = "Gameplay";
        
        private void Awake()
        {
            DontDestroyOnLoad(gameObject);
            
            Services.Setup();
            Services.Register<IInputListener>(_inputListener);

            LoadGameplayScene();
        }

        private void OnDestroy()
        {
            Services.Release();
        }
        
        private void LoadGameplayScene()
        {
            SceneManager.LoadScene(_gameplaySceneName, LoadSceneMode.Additive);
        }
    }
}