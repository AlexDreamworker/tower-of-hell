using System.Collections.Generic;
using System.Linq;

public class MovementStateMachine : IStateSwitcher
{
    private List<IState> _states;
    private IState _currentState;

    public MovementStateMachine(Character character) 
    {
        StateMachineData data = new StateMachineData();

        _states = new List<IState>() 
        {
            //... states    
        };

        _currentState = _states[0];
        _currentState.Enter();
    }

    public void SwitchState<T>() where T : IState
    {
        IState state = _states.FirstOrDefault(state => state is T);

        _currentState?.Exit();
        _currentState = state;
        _currentState.Enter();
    }

    public void HandleInput() => _currentState.HandleInput();

    public void Update() => _currentState.Update();
}
