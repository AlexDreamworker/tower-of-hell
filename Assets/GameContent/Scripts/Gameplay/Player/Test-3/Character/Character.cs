using UnityEngine;
using Zenject;

public class Character : MonoBehaviour
{
    //?[SerializeField] private CharacterConfig _config;
    [SerializeField] private GroundChecker _groundChecker;

    private IInput _input;
    private MovementStateMachine _stateMachine;
    private Rigidbody _rigidbody;

    public IInput Input => _input;
    public Rigidbody Rigidbody => _rigidbody;
    public GroundChecker GroundChecker => _groundChecker;
    //?public CharacterConfig Config => _config;

    [Inject]
    private void Construct(IInput input) 
    {
        _input = input;

        _rigidbody = GetComponent<Rigidbody>();
        _stateMachine = new MovementStateMachine(this);
    }

    // private void Awake()
    // {
    //     _stateMachine = new MovementStateMachine(this);
    // }

    private void Update()
    {
        _stateMachine.HandleInput();
        _stateMachine.Update();
    }
}