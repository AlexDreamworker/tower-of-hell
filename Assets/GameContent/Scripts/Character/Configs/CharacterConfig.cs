using UnityEngine;

[CreateAssetMenu(fileName = "CharacterConfig", menuName = "Configs/Character/CharacterConfig")]
public class CharacterConfig : ScriptableObject
{
    [Space]
    [SerializeField] private CharacterCameraConfig _cameraConfig;

    [Space]
    [SerializeField] private CharacterStaminaConfig _staminaConfig;

    [Space]
    [SerializeField] private MovementStateConfig _movementStateConfig;

    [Space]
    [SerializeField] private GroundedStateConfig _groundedStateConfig;

    [Space]
    [SerializeField] private AirborneStateConfig _airborneStateConfig;

    [Space]
    [SerializeField] private DashStateConfig _dashStateConfig;

    public CharacterCameraConfig CameraConfig => _cameraConfig;
    public CharacterStaminaConfig StaminaConfig => _staminaConfig;
    public MovementStateConfig MovementStateConfig => _movementStateConfig;
    public GroundedStateConfig GroundedStateConfig => _groundedStateConfig;
    public AirborneStateConfig AirborneStateConfig => _airborneStateConfig;
    public DashStateConfig DashStateConfig => _dashStateConfig;
}
