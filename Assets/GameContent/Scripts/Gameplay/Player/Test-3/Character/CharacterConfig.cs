using UnityEngine;

[CreateAssetMenu(fileName = "CharacterConfig", menuName = "Configs/Character/CharacterConfig")]
public class CharacterConfig : ScriptableObject
{
    [field: SerializeField] public WalkStateConfig WalkStateConfig { get; private set; }
    //[SerializeField] private AirborneStateConfig _airbornStateConfig;
}
