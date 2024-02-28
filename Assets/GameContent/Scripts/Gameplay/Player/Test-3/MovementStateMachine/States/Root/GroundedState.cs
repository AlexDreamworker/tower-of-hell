using UnityEngine;

public abstract class GroundedState : MovementState
{
    protected GroundedState(IStateSwitcher stateSwitcher, StateMachineData data, Character character) : base(stateSwitcher, data, character)
    {
    }
}
