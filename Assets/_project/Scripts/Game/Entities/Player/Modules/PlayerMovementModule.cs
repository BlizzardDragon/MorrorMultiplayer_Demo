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
        private PlayerMovePresenter _movePresenter;

        public override void Create(IEntity entity)
        {
            if (entity.Presence.IsLocal())
            {
                var inputManager = GetGlobal<IInputService>();
                var gameManager = GetGlobal<IGameManager>();
                var transformSource = entity.GetModule<Transform>();
                var config = entity.GetModule<PlayerConfig>();

                var mover = new PlayerMover(transformSource, config);
                var rotateToDirection = new PlayerRotateToDirection(transformSource, config);

                var movePresenter = new PlayerMovePresenter(mover, inputManager, gameManager);
                var rotateToDirectionPresenter =
                    new PlayerRotateToDirectionPresenter(rotateToDirection, inputManager, gameManager);

                AddUpdatable(movePresenter);
                AddUpdatable(rotateToDirectionPresenter);
            }
        }
    }
}