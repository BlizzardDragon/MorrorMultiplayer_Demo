using Mirror;
using UnityEngine;

namespace _project.Scripts.Game.Entities.Player.HelloMessage
{
    public interface IPlayerHelloMessageSender
    {
        void CmdSendMessage(string message);
    }

    public class PlayerHelloMessageSender : NetworkBehaviour, IPlayerHelloMessageSender
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