namespace Game.StateMachine
{
    public abstract class State
    {
        protected Requirement DoneRequirement;

        public bool IsDone => DoneRequirement != null && DoneRequirement.IsValid;

        public abstract State GetNextState();

        public virtual void OnEnter()
        {
        }

        public virtual void OnUpdate()
        {
        }
        
        public virtual void OnExit()
        {
        }
    }
}