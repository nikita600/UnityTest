namespace Game.StateMachine
{
    public sealed class StateMachine
    {
        private State _state;
        
        public void Setup(State state)
        {
            ChangeState(state);
        }

        public void Update()
        {
            if (_state == null)
            {
                return;
            }
            
            _state.OnUpdate();

            if (_state.IsDone)
            {
                ChangeState(_state.GetNextState());
            }
        }

        private void ChangeState(State nextState)
        {
            _state?.OnExit();
            _state = nextState;
            _state?.OnEnter();
        }
    }
}