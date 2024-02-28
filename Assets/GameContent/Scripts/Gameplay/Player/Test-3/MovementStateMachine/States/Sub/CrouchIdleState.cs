using UnityEngine;

public class CrouchIdleState : GroundedState
{
    public CrouchIdleState(IStateSwitcher stateSwitcher, StateMachineData data, Character character) 
        : base(stateSwitcher, data, character) { }
}
