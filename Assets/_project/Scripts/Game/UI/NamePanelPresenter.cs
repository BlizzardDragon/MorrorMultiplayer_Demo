using System.Threading;
using _project.Scripts.Game.Configs;
using _project.Scripts.Game.Configs.Player;
using _project.Scripts.Game.Entities.Player.Name;
using Cysharp.Threading.Tasks;
using Mirror;

namespace _project.Scripts.Game.UI
{
    public class NamePanelPresenter
    {
        private readonly NamePanelView _namePanelView;
        private readonly IGameManager _gameManager;
        private readonly IPlayerNameGenerator _playerNameGenerator;

        private CancellationTokenSource _cts;

        public NamePanelPresenter(NamePanelView namePanelView, IGameManager gameManager,
            IPlayerNameGenerator playerNameGenerator)
        {
            _namePanelView = namePanelView;
            _gameManager = gameManager;
            _playerNameGenerator = playerNameGenerator;
        }

        public async void Init()
        {
            _cts = new CancellationTokenSource();

            _namePanelView.HidePanel();
            await UniTask.WaitWhile(() => NetworkClient.localPlayer == null, PlayerLoopTiming.Update, _cts.Token);
            _namePanelView.ShowPanel();
        }

        public void OnEnable()
        {
            _namePanelView.StartButton.onClick.AddListener(OnStartGame);
        }

        public void OnDisable()
        {
            _namePanelView.StartButton.onClick.RemoveListener(OnStartGame);
            _cts?.Cancel();
            _cts?.Dispose();
        }

        private void OnStartGame()
        {
            var localPlayer = NetworkClient.localPlayer;
            var entity = localPlayer.GetComponent<IEntity>();
            var playerNameSync = entity.GetModule<IPlayerNameSync>();

            _namePanelView.HidePanel();
            _gameManager.SetGameStatus(GameStatus.Play);

            var inputFieldText = _namePanelView.InputField.text;
            var name = inputFieldText == string.Empty ? _playerNameGenerator.GenerateName() : inputFieldText;
            playerNameSync.CmdSetName(name);
        }
    }
}