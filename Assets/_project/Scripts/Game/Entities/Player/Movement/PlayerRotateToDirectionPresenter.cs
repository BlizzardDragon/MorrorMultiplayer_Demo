using _project.Scripts.Game.Input;
using UnityEngine;
using VampireSquid.Common.CompositeRoot;

namespace _project.Scripts.Game.Entities.Player.Movement
{
    public class PlayerRotateToDirectionPresenter : IUpdateLoop
    {
        private readonly IRotateToDirection _rotateToDirection;
        private readonly IInputService _inputService;
        private readonly IGameManager _gameManager;

        public PlayerRotateToDirectionPresenter(IRotateToDirection rotateToDirection, IInputService inputService,
            IGameManager gameManager)
        {
            _rotateToDirection = rotateToDirection;
            _inputService = inputService;
            _gameManager = gameManager;
        }

        public void OnUpdate(float deltaTime)
        {
            if (_gameManager.CurrentGameStatus != GameStatus.Play) return;

            _rotateToDirection.Rotate(new Vector2(_inputService.HorizontalAxis, _inputService.VerticalAxis), deltaTime);
        }
    }
}