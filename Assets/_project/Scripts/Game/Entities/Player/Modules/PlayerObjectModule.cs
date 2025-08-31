using _project.Scripts.Game.Configs.Player;
using _project.Scripts.Game.Entities.Modules;
using UnityEngine;

namespace _project.Scripts.Game.Entities.Player.Modules
{
    public class PlayerObjectModule : ObjectModule
    {
        [SerializeField] private PlayerIdentity _identity;
        [SerializeField] private PlayerConfig _config;
        
        public override void Create(IEntity entity)
        {
            base.Create(entity);

            entity.AddModule<IPlayerIdentity>(_identity);
            entity.AddModule(_config);
        }
    }
}