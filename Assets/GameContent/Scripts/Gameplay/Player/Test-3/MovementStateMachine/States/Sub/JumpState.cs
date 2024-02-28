using UnityEngine;

public class JumpState : AirborneState
{
    public JumpState(IStateSwitcher stateSwitcher, StateMachineData data, Character character) 
        : base(stateSwitcher, data, character) { }
}