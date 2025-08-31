using _project.Scripts.Game.Configs.Player;
using _project.Scripts.Game.UI;
using Cysharp.Threading.Tasks;
using UnityEngine;
using VampireSquid.Common.CompositeRoot;

namespace _project.Scripts.Game.Roots
{
    public class UIRoot : CompositeRootBase
    {
        [SerializeField] private NamePanelView _namePanelView;
        [SerializeField] private PlayerNameProvider _playerNameProvider;

        private NamePanelPresenter _namePanelPresenter;

        public override async UniTask InstallBindings()
        {
            var gameManager = GetGlobal<IGameManager>();

            _namePanelPresenter = new NamePanelPresenter(_namePanelView, gameManager, _playerNameProvider);
        }

        public override async UniTask Initialize()
        {
            _namePanelPresenter.Init();
            _namePanelPresenter.OnEnable();
        }

        public override void OnBeforeDestroyed()
        {
            _namePanelPresenter.OnDisable();
        }
    }
}