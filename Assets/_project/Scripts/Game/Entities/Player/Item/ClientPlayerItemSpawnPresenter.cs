using _project.Scripts.Game.Input;

namespace _project.Scripts.Game.Entities.Player.Item
{
    public class ClientPlayerItemSpawnPresenter
    {
        private readonly IInputService _inputService;
        private readonly IPlayerItemSpawner _itemSpawner;

        public ClientPlayerItemSpawnPresenter(IInputService inputService, IPlayerItemSpawner itemSpawner)
        {
            _inputService = inputService;
            _itemSpawner = itemSpawner;
        }

        public void OnEnable()
        {
            _inputService.FKeyDown += OnFKeyDown;
        }

        public void OnDisable()
        {
            _inputService.FKeyDown -= OnFKeyDown;
        }

        private void OnFKeyDown()
        {
            _itemSpawner.CmdSpawnItem();
        }
    }
}