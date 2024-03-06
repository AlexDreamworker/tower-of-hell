using System;
using UnityEngine;

public abstract class BaseState : IState
{
    protected readonly IStateSwitcher StateSwitcher;
    protected readonly MovementStateMachineData Data;

    private readonly Character _character;

    public BaseState(IStateSwitcher stateSwitcher, MovementStateMachineData data, Character character)
    {
        StateSwitcher = stateSwitcher;
        Data = data;
        _character = character;
    }

    protected IInputService Input => _character.Input;
    //protected ILogService Log => _character.Log; 
    protected Rigidbody Rigidbody => _character.Rigidbody;
    protected Transform Transform => _character.transform;

    public virtual void Enter() => AddInputActionCallbacks();

    public virtual void Exit() => RemoveInputActionCallbacks();

    public virtual void FixedUpdate() { }

    public virtual void HandleInput() { }

    public virtual void Update() { }

    protected virtual void AddInputActionCallbacks() { }

    protected virtual void RemoveInputActionCallbacks() { }

    //TODO: Why CHARACTER.LOG?
    protected void LogStateInfo(Type type, string color) 
        => _character.Log.Log(type.ToString(), color);
}