using System;
using Game.GameStates;
using Game.InputSystem;
using UnityEngine;

namespace Game
{
    public class Bootstrapper : MonoBehaviour
    {
        [SerializeField]
        private InputListener _inputListener = null;

        private StateMachine.StateMachine _stateMachine;
        
        private void Awake()
        {
            DontDestroyOnLoad(gameObject);
            
            Services.Setup();
            Services.Register<IInputListener>(_inputListener);

            _stateMachine = new StateMachine.StateMachine();
            _stateMachine.Setup(new StartGameState());
        }

        private void OnDestroy()
        {
            Services.Release();
        }

        private void LateUpdate()
        {
            _stateMachine?.Update();
        }
    }
}