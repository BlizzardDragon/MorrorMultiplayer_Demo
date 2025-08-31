using _project.Scripts.Game.Configs.Player;
using _project.Scripts.Game.Input;

namespace _project.Scripts.Game.Entities.Player.Message
{
    public class PlayerMessagePresenter
    {
        private readonly IPlayerMessageSender _messageSender;
        private readonly IPlayerIdentity _playerIdentity;
        private readonly IInputService _inputService;
        private readonly PlayerConfig _config;

        public PlayerMessagePresenter(IPlayerMessageSender messageSender, IPlayerIdentity playerIdentity,
            IInputService inputService, PlayerConfig config)
        {
            _messageSender = messageSender;
            _playerIdentity = playerIdentity;
            _inputService = inputService;
            _config = config;
        }

        public void OnEnable()
        {
            _inputService.SpaceDown += OnSpaceDown;
        }

        public void OnDisable()
        {
            _inputService.SpaceDown -= OnSpaceDown;
        }

        private void OnSpaceDown()
        {
            _messageSender.CmdSendMessage(_config.MessageText + _playerIdentity.Name);
        }
    }
}