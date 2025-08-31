using System;
using Mirror;
using UnityEngine;

namespace _project.Scripts.Game.Entities.Player.Movement
{
    public interface IPlayerMoveInputSender
    {
        event Action<Vector2> MoveInputReceived;

        void CmdSendInput(Vector2 direction);
    }

    public class PlayerMoveInputSender : NetworkBehaviour, IPlayerMoveInputSender
    {
        public event Action<Vector2> MoveInputReceived;

        [Command]
        public void CmdSendInput(Vector2 direction)
        {
            MoveInputReceived?.Invoke(direction);
        }
    }
}