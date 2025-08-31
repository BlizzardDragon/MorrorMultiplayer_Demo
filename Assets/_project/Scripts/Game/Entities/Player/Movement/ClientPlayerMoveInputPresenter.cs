using _project.Scripts.Game.Input;
using UnityEngine;
using VampireSquid.Common.CompositeRoot;

namespace _project.Scripts.Game.Entities.Player.Movement
{
    public class ClientPlayerMoveInputPresenter : IUpdateLoop
    {
        private readonly IPlayerMoveInputSender _moveInputSender;
        private readonly IInputService _inputService;
        private readonly IGameManager _gameManager;

        public ClientPlayerMoveInputPresenter(IPlayerMoveInputSender moveInputSender, IInputService inputService,
            IGameManager gameManager)
        {
            _inputService = inputService;
            _moveInputSender = moveInputSender;
            _gameManager = gameManager;
        }

        public void OnUpdate(float _)
        {
            if (_gameManager.CurrentGameStatus != GameStatus.Play) return;

            _moveInputSender.CmdSendInput(
                new Vector2(_inputService.HorizontalAxisRaw, _inputService.VerticalAxisRaw));
        }
    }
}