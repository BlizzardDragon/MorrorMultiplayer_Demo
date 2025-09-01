using _project.Scripts.Game.Entities.Player.Name;
using _project.Scripts.Game.Entities.Player.View;
using Entity.Core;
using UnityEngine;
using VampireSquid.Common.Connections;

namespace _project.Scripts.Game.Entities.Player.Modules
{
    public class PlayerNameModule : EntityModuleCompositeRootBase
    {
        [SerializeField] private PlayerNameSync _nameSync;
        [SerializeField] private PlayerNameView _nameView;

        private PlayerNameFollower _nameFollower;
        private ClientPlayerNamePresenter _clientPlayerNamePresenter;
        private RemotePlayerNamePresenter _remotePlayerNamePresenter;

        public override void Create(IEntity entity)
        {
            var transformSource = entity.GetModule<Transform>();
            var identity = entity.GetModule<IPlayerIdentity>();

            entity.AddModule<IPlayerNameSync>(_nameSync);

            _nameFollower = new PlayerNameFollower(transformSource, _nameView.transform);

            if (entity.Presence.IsLocal())
            {
                _clientPlayerNamePresenter = new ClientPlayerNamePresenter(identity, _nameView);
            }
            else if (entity.Presence.IsRemote())
            {
                _remotePlayerNamePresenter = new RemotePlayerNamePresenter(identity, _nameView);
            }

            AddUpdatable(_nameFollower);
        }

        public override void Initialize()
        {
            _nameFollower.Initialize();
            _remotePlayerNamePresenter?.Initialize();
            _clientPlayerNamePresenter?.OnEnable();
            _remotePlayerNamePresenter?.OnEnable();
        }

        protected override void OnBeforeDestroy()
        {
            _clientPlayerNamePresenter?.OnDisable();
            _remotePlayerNamePresenter?.OnDisable();
        }
    }
}