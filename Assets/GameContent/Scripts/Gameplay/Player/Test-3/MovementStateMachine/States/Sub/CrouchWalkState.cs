using UnityEngine;

public class CrouchWalkState : GroundedState
{
    public CrouchWalkState(IStateSwitcher stateSwitcher, StateMachineData data, Character character) 
        : base(stateSwitcher, data, character) { }
}