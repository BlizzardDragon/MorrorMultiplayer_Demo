using Mirror;
using UnityEngine;

namespace _project.Scripts.Game.Entities.Player.Message
{
    public interface IPlayerMessageSender
    {
        void CmdSendMessage(string message);
    }

    public class PlayerMessageSender : NetworkBehaviour, IPlayerMessageSender
    {
        [Command]
        public void CmdSendMessage(string message)
        {
            RpcReceiveMessage(message);
        }

        [ClientRpc]
        private void RpcReceiveMessage(string message)
        {
            Debug.Log($"{message}");
        }
    }
}