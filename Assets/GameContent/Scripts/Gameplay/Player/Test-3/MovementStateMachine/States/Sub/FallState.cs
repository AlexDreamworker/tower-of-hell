using UnityEngine;

public class FallState : AirborneState
{
    public FallState(IStateSwitcher stateSwitcher, StateMachineData data, Character character) : base(stateSwitcher, data, character)
    {
    }
}
