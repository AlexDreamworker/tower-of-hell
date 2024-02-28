using UnityEngine;

public class IdleState : GroundedState
{
    public IdleState(IStateSwitcher stateSwitcher, StateMachineData data, Character character) : base(stateSwitcher, data, character)
    {
    }
}