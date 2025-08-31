using _project.Scripts.Game.Configs.Player;
using UnityEngine;

namespace _project.Scripts.Game.Entities.Player.Movement
{
    public class PlayerRotateToDirection : IRotateToDirection
    {
        private readonly Transform _playerSource;
        private readonly PlayerConfig _config;

        public PlayerRotateToDirection(Transform playerSource, PlayerConfig config)
        {
            _playerSource = playerSource;
            _config = config;
        }

        public void Rotate(Vector2 direction, float deltaTime)
        {
            if (direction == Vector2.zero) return;

            var targetRotation =
                Quaternion.LookRotation(new Vector3(direction.x, 0, direction.y), Vector3.up);

            _playerSource.rotation =
                Quaternion.Lerp(_playerSource.rotation, targetRotation, _config.RotationSpeed * deltaTime);
        }
    }
}