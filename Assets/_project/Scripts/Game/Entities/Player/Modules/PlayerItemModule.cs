using _project.Scripts.Game.Entities.Player.Item;
using _project.Scripts.Game.Input;
using Entity.Core;
using UnityEngine;
using VampireSquid.Common.Connections;

namespace _project.Scripts.Game.Entities.Player.Modules
{
    public class PlayerItemModule : EntityModuleCompositeRootBase
    {
        [SerializeField] private PlayerItemSpawner _itemSpawner;

        private ClientPlayerItemSpawnPresenter _clientPlayerItemSpawnPresenter;

        public override void Create(IEntity entity)
        {
            if (entity.Presence.IsLocal())
            {
                var inputService = Get<IInputService>();

                _clientPlayerItemSpawnPresenter = new ClientPlayerItemSpawnPresenter(inputService, _itemSpawner);
            }
        }

        public override void Initialize()
        {
            _clientPlayerItemSpawnPresenter?.OnEnable();
        }

        protected override void OnBeforeDestroy()
        {
            _clientPlayerItemSpawnPresenter?.OnDisable();
        }
    }
}