using _project.Scripts.Game.Configs.Player;
using UnityEngine;

namespace _project.Scripts.Game.Entities.Player.Movement
{
    public class PlayerRotateToDirection : IRotateToDirection
    {
        private readonly Rigidbody _rigidbody;
        private readonly PlayerConfig _config;

        public PlayerRotateToDirection(Rigidbody rigidbody, PlayerConfig config)
        {
            _rigidbody = rigidbody;
            _config = config;
        }

        public void Rotate(Vector2 direction)
        {
            if (direction == Vector2.zero) return;

            var targetRotation =
                Quaternion.LookRotation(new Vector3(direction.x, 0, direction.y), Vector3.up);

            var rotation = Quaternion.Lerp(_rigidbody.rotation, targetRotation, _config.RotationSpeed);
            _rigidbody.MoveRotation(rotation);
        }
    }
}