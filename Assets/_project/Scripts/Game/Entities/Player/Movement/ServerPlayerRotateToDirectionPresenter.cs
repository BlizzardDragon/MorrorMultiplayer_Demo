using UnityEngine;
using VampireSquid.Common.CompositeRoot;

namespace _project.Scripts.Game.Entities.Player.Movement
{
    public class ServerPlayerRotateToDirectionPresenter : IFixedUpdateLoop
    {
        private readonly IRotateToDirection _rotateToDirection;
        private readonly IPlayerMoveInputSender _moveInputSender;

        private Vector2 _currentDirection;

        public ServerPlayerRotateToDirectionPresenter(IRotateToDirection rotateToDirection,
            IPlayerMoveInputSender moveInputSender)
        {
            _rotateToDirection = rotateToDirection;
            _moveInputSender = moveInputSender;
        }

        public void OnEnable()
        {
            _moveInputSender.MoveInputReceived += OnMoveInputReceived;
        }

        public void OnDisable()
        {
            _moveInputSender.MoveInputReceived -= OnMoveInputReceived;
        }

        private void OnMoveInputReceived(Vector2 direction)
        {
            _currentDirection = direction;
        }

        public void OnFixedUpdate(float deltaTime)
        {
            _rotateToDirection.Rotate(_currentDirection.normalized);
        }
    }
}