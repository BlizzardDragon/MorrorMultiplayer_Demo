using _project.Scripts.Game.Configs.Player;
using _project.Scripts.Game.Input;

namespace _project.Scripts.Game.Entities.Player.Message
{
    public class PlayerMessagePresenter
    {
        private readonly IPlayerMessageSender _messageSender;
        private readonly IPlayerNameSync _playerNameSync;
        private readonly IInputService _inputService;
        private readonly PlayerConfig _config;

        public PlayerMessagePresenter(IPlayerMessageSender messageSender, IPlayerNameSync playerNameSync,
            IInputService inputService, PlayerConfig config)
        {
            _messageSender = messageSender;
            _playerNameSync = playerNameSync;
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
            _messageSender.CmdSendMessage(_config.MessageText + _playerNameSync.Name);
        }
    }
}