using UnityEngine;

public class WalkState : GroundedState
{
    public WalkState(IStateSwitcher stateSwitcher, StateMachineData data, Character character) : base(stateSwitcher, data, character)
    {
    }
}
