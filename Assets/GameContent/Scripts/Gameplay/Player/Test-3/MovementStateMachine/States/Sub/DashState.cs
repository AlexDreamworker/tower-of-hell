using System.Collections;
using UnityEngine;

//TODO: Move to BASE_STATE?
public class DashState : IState
{
    private readonly IStateSwitcher _stateSwitcher;
    private readonly StateMachineData _data;
    private readonly Character _character;
    private readonly DashStateConfig _config;
    
    //!!!>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
    private MonoBehaviour CoroutineProxy => _character; //TODO: ??? Check course work!
    private Vector3 _startPosition;
    public float _dashDistance = 5f; //TODO: move to config
    //!!!>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>

    public DashState(IStateSwitcher stateSwitcher, StateMachineData data, Character character)
    {
        _stateSwitcher = stateSwitcher;
        _data = data;
        _character = character;
        _config = character.Config.DashStateConfig;
    }

    private Rigidbody Rigidbody => _character.Rigidbody;
    private Transform Transform => _character.transform;

    public void Enter()
    {
        Debug.Log("<color=purple>DASH</color>"); //TODO: debug!

        //Rigidbody.drag = _config.Drag;

        _startPosition = Rigidbody.position;

        //Dash();
        CoroutineProxy.StartCoroutine(DashRoutine());
    }

    public void Exit() { }

    public void HandleInput() { }

    public void Update()
    {
        Debug.Log(Rigidbody.velocity);

        // if (_data.DashCooldownTimer > 0)
        //     _data.DashCooldownTimer -= Time.deltaTime;
    }

    public void FixedUpdate() { }

    // private void Dash() 
    // {
    //     if (_data.DashCooldownTimer > 0)
    //         return;
    //     else 
    //         _data.DashCooldownTimer = _config.Cooldown;

    //     Rigidbody.velocity = Vector3.zero; //TODO: need this?
    //     Rigidbody.AddForce(Transform.forward * _config.Force, ForceMode.Impulse);
    // }

    private IEnumerator DashRoutine()
    {
        //Debug.Log("Start Coroutine!");

        // Запоминаем начальную позицию
        _startPosition = Transform.position;

        // Применяем рывок
        Rigidbody.AddForce(Transform.forward * 50f, ForceMode.Impulse);

        // Ждем, пока персонаж не достигнет нужного расстояния
        //TODO: Fix the BUG where the character hits a wall and never reaches the distance!
        yield return new WaitUntil(() => Vector3.Distance(_startPosition, Transform.position) >= _dashDistance);

        //Debug.Log("Distance reached!");

        // Останавливаем персонажа
        Rigidbody.velocity = Vector3.zero;

        // Переходим в другое состояние или выполняем другие действия
        //TODO: Check the ground and switch state FALL or IDLE
        _stateSwitcher.SwitchState<FallState>();
    }
}
