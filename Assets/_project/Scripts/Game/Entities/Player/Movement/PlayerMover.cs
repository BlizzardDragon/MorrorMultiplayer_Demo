using _project.Scripts.Game.Configs.Player;
using UnityEngine;

namespace _project.Scripts.Game.Entities.Player.Movement
{
    public class PlayerMover : IMover
    {
        private readonly Rigidbody _rigidbody;
        private readonly PlayerConfig _config;

        public PlayerMover(Rigidbody rigidbody, PlayerConfig config)
        {
            _rigidbody = rigidbody;
            _config = config;
        }

        public void Move(Vector2 direction)
        {
            var speed = _config.MoveSpeed;
            _rigidbody.linearVelocity = new Vector3(direction.x * speed, 0, direction.y * speed);
        }
    }
}