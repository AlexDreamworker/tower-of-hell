using System.Collections.Generic;
using System.Linq;

//TODO: Rename to CHARACTER_STATE_MACHINE
public class MovementStateMachine : IStateSwitcher
{
    private List<IState> _states;
    private IState _currentState;

    private bool _isInit;

    public void Initialize(List<IState> states) 
    {
        _states = states;

        _currentState = _states[0];
        _currentState.Enter();

        _isInit = true;
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

    public void HandleInput()
    {
        if (_isInit == false)
            return;

        _currentState.HandleInput();
    }

    public void Update()
    {
        if (_isInit == false)
            return;

        _currentState.Update();
    }

    public void FixedUpdate()
    {
        if (_isInit == false)
            return;

        _currentState.FixedUpdate();
    }
}
