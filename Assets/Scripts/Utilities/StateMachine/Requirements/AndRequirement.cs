namespace Game.StateMachine
{
    public sealed class AndRequirement : Requirement
    {
        private readonly Requirement[] _requirements;

        public override bool IsValid
        {
            get
            {
                for (int i = 0, size = _requirements.Length; i < size; i++)
                {
                    var requirement = _requirements[i];
                    if (!requirement.IsValid)
                    {
                        return false;
                    }
                }

                return true;
            }
        }

        public AndRequirement(Requirement[] requirements)
        {
            _requirements = requirements;
        }
    }
}