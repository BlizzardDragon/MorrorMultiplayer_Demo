using _project.Scripts.Game.Configs.Player;
using UnityEngine;

namespace _project.Scripts.Game.Entities.Player.Movement
{
    public class PlayerMover : IMover
    {
        private readonly Transform _playerSource;
        private readonly PlayerConfig _config;
        
        public PlayerMover(Transform playerSource, PlayerConfig config)
        {
            _playerSource = playerSource;
            _config = config;
        }

        public void Move(Vector2 direction, float deltaTime)
        {
            var speed = _config.MoveSpeed * deltaTime;
            _playerSource.Translate(new Vector3(direction.x * speed, 0, direction.y * speed), Space.World);
        }
    }
}