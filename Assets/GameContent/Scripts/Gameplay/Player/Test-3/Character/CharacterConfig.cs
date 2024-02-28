using UnityEngine;

[CreateAssetMenu(fileName = "CharacterConfig", menuName = "Configs/Character/CharacterConfig")]
public class CharacterConfig : ScriptableObject
{
    [SerializeField] private WalkStateConfig _runningStateConfig;
    [SerializeField] private AirborneStateConfig _airbornStateConfig;

    public WalkStateConfig RunningStateConfig => _runningStateConfig;
    public AirborneStateConfig AirbornStateConfig => _airbornStateConfig;
}
