using System.Collections.Generic;

public class MovementStateMachineProvider
{
    public MovementStateMachineProvider(MovementStateMachine stateMachine, List<IState> states)
        => stateMachine.Initialize(states);
}