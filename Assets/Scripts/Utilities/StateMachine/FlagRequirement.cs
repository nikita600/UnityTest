using System;

namespace Game.StateMachine
{
    public sealed class FlagRequirement : Requirement
    {
        private readonly Func<bool> _getFlagFunc;

        public override bool IsValid => _getFlagFunc();

        public FlagRequirement(Func<bool> getFlag)
        {
            _getFlagFunc = getFlag;
        }
    }
}