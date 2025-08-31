using UnityEngine;

namespace _project.Scripts.Game.Configs.Player
{
    [CreateAssetMenu(
        fileName = "PlayerConfig",
        menuName = "Config/Player/PlayerConfig",
        order = 0)]
    public class PlayerConfig : ScriptableObject
    {
        [field: SerializeField] public float MoveSpeed { get; private set; } = 5;
        [field: SerializeField] public float RotationSpeed { get; private set; } = 10;
        [field: SerializeField] public string MessageText { get; private set; } = "Привет от ";
    }
}