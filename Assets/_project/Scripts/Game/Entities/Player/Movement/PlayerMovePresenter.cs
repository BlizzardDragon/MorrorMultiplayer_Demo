using _project.Scripts.Game.Input;
using UnityEngine;
using VampireSquid.Common.CompositeRoot;

namespace _project.Scripts.Game.Entities.Player.Movement
{
    public class PlayerMovePresenter : IUpdateLoop
    {
        private readonly IMover _mover;
        private readonly IInputService _inputService;
        private readonly IGameManager _gameManager;

        public PlayerMovePresenter(IMover mover, IInputService inputService, IGameManager gameManager)
        {
            _inputService = inputService;
            _mover = mover;
            _gameManager = gameManager;
        }

        public void OnUpdate(float deltaTime)
        {
            if (_gameManager.CurrentGameStatus != GameStatus.Play) return;

            _mover.Move(new Vector2(_inputService.HorizontalAxis, _inputService.VerticalAxis), deltaTime);
        }
    }
}