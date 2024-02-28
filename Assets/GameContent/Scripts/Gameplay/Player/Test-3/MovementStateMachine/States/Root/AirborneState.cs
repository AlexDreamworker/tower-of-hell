using UnityEngine;

public abstract class AirborneState : MovementState
{
    protected AirborneState(IStateSwitcher stateSwitcher, StateMachineData data, Character character) 
        : base(stateSwitcher, data, character) { }
}