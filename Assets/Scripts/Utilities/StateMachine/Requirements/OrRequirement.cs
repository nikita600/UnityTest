namespace Game.StateMachine
{
    public class OrRequirement : Requirement
    {
        private readonly Requirement[] _requirements;

        public override bool IsValid
        {
            get
            {
                for (int i = 0, size = _requirements.Length; i < size; i++)
                {
                    var requirement = _requirements[i];
                    if (requirement.IsValid)
                    {
                        return true;
                    }
                }

                return false;
            }
        }
        
        public OrRequirement(Requirement[] requirements)
        {
            _requirements = requirements;
        }
    }
}