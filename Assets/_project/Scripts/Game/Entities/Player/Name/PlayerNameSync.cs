using Mirror;
using UnityEngine;

namespace _project.Scripts.Game.Entities.Player.Name
{
    public interface IPlayerNameSync
    {
        void CmdSetName(string name);
    }

    public class PlayerNameSync : NetworkBehaviour, IPlayerNameSync
    {
        [SerializeField] private PlayerIdentity _identity;

        [Command]
        public void CmdSetName(string name)
        {
            _identity.SetName(name);
        }
    }
}