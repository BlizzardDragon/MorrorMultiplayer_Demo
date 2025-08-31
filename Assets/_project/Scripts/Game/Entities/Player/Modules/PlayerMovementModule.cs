using _project.Scripts.Game.Configs.Player;
using _project.Scripts.Game.Entities.Player.Movement;
using _project.Scripts.Game.Input;
using Entity.Core;
using UnityEngine;
using VampireSquid.Common.Connections;

namespace _project.Scripts.Game.Entities.Player.Modules
{
    public class PlayerMovementModule : EntityModuleCompositeRootBase
    {
        [SerializeField] private PlayerMoveInputSender _moveInputSender;

        private ServerPlayerMovePresenter _serverPlayerMovePresenter;
        private ServerPlayerRotateToDirectionPresenter _serverPlayerRotateToDirectionPresenter;

        public override void Create(IEntity entity)
        {
            if (entity.Presence.IsLocal())
            {
                var inputManager = GetGlobal<IInputService>();
                var gameManager = GetGlobal<IGameManager>();

                var clientPlayerMoveInputPresenter =
                    new ClientPlayerMoveInputPresenter(_moveInputSender, inputManager, gameManager);

                AddUpdatable(clientPlayerMoveInputPresenter);
            }

            if (entity.Presence.OnServer())
            {
                var rb = entity.GetModule<Rigidbody>();
                var config = entity.GetModule<PlayerConfig>();

                var mover = new PlayerMover(rb, config);
                var rotateToDirection = new PlayerRotateToDirection(rb, config);

                _serverPlayerMovePresenter = new ServerPlayerMovePresenter(mover, _moveInputSender);
                _serverPlayerRotateToDirectionPresenter =
                    new ServerPlayerRotateToDirectionPresenter(rotateToDirection, _moveInputSender);

                AddFixedUpdatable(_serverPlayerMovePresenter);
                AddFixedUpdatable(_serverPlayerRotateToDirectionPresenter);
            }
        }

        public override void Initialize()
        {
            _serverPlayerMovePresenter?.OnEnable();
            _serverPlayerRotateToDirectionPresenter?.OnEnable();
        }

        protected override void OnBeforeDestroy()
        {
            _serverPlayerMovePresenter?.OnDisable();
            _serverPlayerRotateToDirectionPresenter?.OnDisable();
        }
    }
}