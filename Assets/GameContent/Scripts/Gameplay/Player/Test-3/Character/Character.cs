using UnityEngine;
using Zenject;

[RequireComponent(typeof(Rigidbody))]
public class Character : MonoBehaviour
{
    [SerializeField] private CharacterConfig _config;
    [SerializeField] private GroundChecker _groundChecker;

    private IInput _input;
    private MovementStateMachine _stateMachine;
    private Rigidbody _rigidbody;

    public IInput Input => _input;
    public Rigidbody Rigidbody => _rigidbody;
    public GroundChecker GroundChecker => _groundChecker;
    public CharacterConfig Config => _config;

    [Inject]
    private void Construct(IInput input) //TODO: move init StateMachine
    {
        _input = input;

        _rigidbody = GetComponent<Rigidbody>();
        _stateMachine = new MovementStateMachine(this);
    }

    private void Update()
    {
        _stateMachine.HandleInput();
        _stateMachine.Update();
    }

    private void FixedUpdate() => _stateMachine.FixedUpdate();
}