using UnityEngine;

[CreateAssetMenu(fileName = "CharacterConfig", menuName = "Configs/Character/CharacterConfig")]
public class CharacterConfig : ScriptableObject
{
    [Space]
    [SerializeField] private GroundedStateConfig _groundedStateConfig;

    [Space]
    [SerializeField] private AirborneStateConfig _airborneStateConfig;

    [Space]
    [SerializeField] private DashStateConfig _dashStateConfig;

    public GroundedStateConfig GroundedStateConfig => _groundedStateConfig;
    public AirborneStateConfig AirborneStateConfig => _airborneStateConfig;
    public DashStateConfig DashStateConfig => _dashStateConfig;
}
