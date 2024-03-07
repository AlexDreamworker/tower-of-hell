using System.Collections.Generic;
using System.Linq;

//TODO: Rename to CHARACTER_STATE_MACHINE
public class MovementStateMachine : IStateSwitcher
{
    private List<IState> _states;
    private IState _currentState;

    //TODO: вынести инициализацию в другое место, передавать список состояний + первое состояние.
    public MovementStateMachine(Character character) 
    {
        MovementStateMachineData data = new MovementStateMachineData();

        _states = new List<IState>() 
        {
            new IdleState(this, data, character),
            new WalkingState(this, data, character),
            new RunningState(this, data, character),
            new FallingState(this, data, character),
            new JumpingState(this, data, character),
            new CrouchingState(this, data, character),
            new DuckingState(this, data, character),
            new DashState(this, data, character),
        };

        _currentState = _states[0];
        _currentState.Enter();
    }

    public void SwitchState<T>() where T : IState
    {
        IState state = _states.FirstOrDefault(state => state is T);

        //* do nothing if state NOT added
        //*----------------------------------
        if (state == null)
            return;
        //*----------------------------------

        _currentState?.Exit();
        _currentState = state;
        _currentState.Enter();
    }

    public void HandleInput() => _currentState.HandleInput();

    public void Update() => _currentState.Update();

    public void FixedUpdate() => _currentState.FixedUpdate();
}
