using Game.GameStates;
using Game.InputSystem;
using Game.UI;
using UnityEngine;

namespace Game
{
    public class Bootstrapper : MonoBehaviour
    {
        [SerializeField]
        private bool _cursorVisible = false;
        
        [SerializeField]
        private CursorLockMode _cursorLockMode = CursorLockMode.Locked;
        
        [SerializeField]
        private UiManager _uiManager = null;
        
        private InputListener _inputListener;
        private StateMachine.StateMachine _stateMachine;

        private void Awake()
        {
            DontDestroyOnLoad(gameObject);

            Cursor.visible = _cursorVisible;
            Cursor.lockState = _cursorLockMode;
            
            _inputListener = new InputListener();
            
            Services.Setup();
            Services.Register<IUiManager>(_uiManager);
            Services.Register<IInputListener>(_inputListener);
            Services.Register<IUnitManager>(new UnitManager());
            
            _stateMachine = new StateMachine.StateMachine();
            _stateMachine.Setup(new StartGameState());
        }

        private void OnDestroy()
        {
            Services.Release();
        }

        private void LateUpdate()
        {
            _inputListener.Update();
            _stateMachine.Update();
        }
    }
}