using _project.Scripts.Game.Configs.Player;
using _project.Scripts.Game.Entities.Player.Message;
using _project.Scripts.Game.Input;
using Entity.Core;
using UnityEngine;
using VampireSquid.Common.Connections;

namespace _project.Scripts.Game.Entities.Player.Modules
{
    public class PlayerMessageModule : EntityModuleCompositeRootBase
    {
        [SerializeField] private PlayerMessageSender _messageSender;

        private PlayerMessagePresenter _messagePresenter;

        public override void Create(IEntity entity)
        {
            if (entity.Presence.IsLocal())
            {
                var inputService = GetGlobal<IInputService>();
                var playerIdentity = entity.GetModule<IPlayerNameSync>();
                var config = entity.GetModule<PlayerConfig>();

                _messagePresenter = new PlayerMessagePresenter(_messageSender, playerIdentity, inputService, config);
            }
        }

        public override void Initialize()
        {
            _messagePresenter?.OnEnable();
        }

        protected override void OnBeforeDestroy()
        {
            _messagePresenter?.OnDisable();
        }
    }
}