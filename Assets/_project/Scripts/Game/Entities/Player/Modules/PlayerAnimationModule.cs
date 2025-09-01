using _project.Scripts.Game.Entities.Player.View;
using Entity.Core;
using UnityEngine;
using VampireSquid.Common.Connections;

namespace _project.Scripts.Game.Entities.Player.Modules
{
    public class PlayerAnimationModule : EntityModuleCompositeRootBase
    {
        [SerializeField] private Animator _animator;

        public override void Create(IEntity entity)
        {
            if (entity.Presence.OnServer())
            {
                var rb = entity.GetModule<Rigidbody>();

                var animationController = new PlayerAnimationController(_animator, rb);

                AddUpdatable(animationController);
            }
        }
    }
}