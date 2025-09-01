using _project.Scripts.Game.Input;
using Entity.Core;
using UnityEngine;
using VampireSquid.Common.Connections;

namespace _project.Scripts.Game.Entities.Player.Modules
{
    public class PlayerItemModule : EntityModuleCompositeRootBase
    {
        [SerializeField] private GameObject _item;
        
        public override void Create(IEntity entity)
        {
            if (entity.Presence.IsLocal())
            {
                var inputService = Get<IInputService>();
                
            }
        }
    }
}