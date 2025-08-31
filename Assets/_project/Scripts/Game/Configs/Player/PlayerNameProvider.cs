using UnityEngine;

namespace _project.Scripts.Game.Configs.Player
{
    public interface IPlayerNameGenerator
    {
        string GenerateName();
    }

    [CreateAssetMenu(
        fileName = "PlayerNameProvider",
        menuName = "Config/Player/NameProvider",
        order = 0)]
    public class PlayerNameProvider : ScriptableObject, IPlayerNameGenerator
    {
        [SerializeField] private string[] _names;

        public string GenerateName()
        {
            return _names[Random.Range(0, _names.Length)];
        }
    }
}