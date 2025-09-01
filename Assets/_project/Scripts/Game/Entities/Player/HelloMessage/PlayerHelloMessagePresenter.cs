using _project.Scripts.Game.Configs.Player;
using _project.Scripts.Game.Input;

namespace _project.Scripts.Game.Entities.Player.HelloMessage
{
    public class PlayerHelloMessagePresenter
    {
        private readonly IPlayerHelloMessageSender _helloMessageSender;
        private readonly IPlayerNameSync _playerNameSync;
        private readonly IInputService _inputService;
        private readonly PlayerConfig _config;

        public PlayerHelloMessagePresenter(IPlayerHelloMessageSender helloMessageSender, IPlayerNameSync playerNameSync,
            IInputService inputService, PlayerConfig config)
        {
            _helloMessageSender = helloMessageSender;
            _playerNameSync = playerNameSync;
            _inputService = inputService;
            _config = config;
        }

        public void OnEnable()
        {
            _inputService.SpaceKeyDown += OnSpaceKeyDown;
        }

        public void OnDisable()
        {
            _inputService.SpaceKeyDown -= OnSpaceKeyDown;
        }

        private void OnSpaceKeyDown()
        {
            _helloMessageSender.CmdSendMessage(_config.MessageText + _playerNameSync.Name);
        }
    }
}