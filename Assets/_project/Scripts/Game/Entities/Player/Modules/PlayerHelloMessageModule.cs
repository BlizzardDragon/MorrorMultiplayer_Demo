using _project.Scripts.Game.Configs.Player;
using _project.Scripts.Game.Entities.Player.HelloMessage;
using _project.Scripts.Game.Input;
using Entity.Core;
using UnityEngine;
using VampireSquid.Common.Connections;

namespace _project.Scripts.Game.Entities.Player.Modules
{
    public class PlayerHelloMessageModule : EntityModuleCompositeRootBase
    {
        [SerializeField] private PlayerHelloMessageSender _helloMessageSender;

        private PlayerHelloMessagePresenter _helloMessagePresenter;

        public override void Create(IEntity entity)
        {
            if (entity.Presence.IsLocal())
            {
                var inputService = GetGlobal<IInputService>();
                var playerIdentity = entity.GetModule<IPlayerNameSync>();
                var config = entity.GetModule<PlayerConfig>();

                _helloMessagePresenter =
                    new PlayerHelloMessagePresenter(_helloMessageSender, playerIdentity, inputService, config);
            }
        }

        public override void Initialize()
        {
            _helloMessagePresenter?.OnEnable();
        }

        protected override void OnBeforeDestroy()
        {
            _helloMessagePresenter?.OnDisable();
        }
    }
}