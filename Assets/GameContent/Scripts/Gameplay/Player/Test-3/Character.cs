using UnityEngine;

public class Character : MonoBehaviour
{
    private MovementStateMachine _stateMachine;

    private void Awake()
    {
        _stateMachine = new MovementStateMachine(this);
    }

    private void Update()
    {
        _stateMachine.HandleInput();
        _stateMachine.Update();
    }
}
