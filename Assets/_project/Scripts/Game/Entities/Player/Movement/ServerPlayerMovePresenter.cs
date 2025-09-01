using UnityEngine;
using VampireSquid.Common.CompositeRoot;

namespace _project.Scripts.Game.Entities.Player.Movement
{
    public class ServerPlayerMovePresenter : IFixedUpdateLoop
    {
        private readonly IMover _mover;
        private readonly IPlayerMoveInputSender _moveInputSender;

        private Vector2 _currentDirection;
        
        public ServerPlayerMovePresenter(IMover mover, IPlayerMoveInputSender moveInputSender)
        {
            _mover = mover;
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
            _mover.Move(_currentDirection.normalized * deltaTime);
        }
    }
}