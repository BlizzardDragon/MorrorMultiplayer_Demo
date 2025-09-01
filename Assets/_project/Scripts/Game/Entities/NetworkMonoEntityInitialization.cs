using Entity.Core;
using Mirror;
using VampireSquid.Common.Connections;

namespace _project.Scripts.Game.Entities
{
    public class NetworkMonoEntityInitialization : NetworkBehaviour
    {
        private NetworkedPresence presence = NetworkedPresence.Undefined;
        private bool _initialized;

        public override void OnStartServer()
        {
            presence |= NetworkedPresence.Server;

            if (isLocalPlayer)
                presence |= NetworkedPresence.Host;

            TryInitialize();
        }

        public override void OnStartLocalPlayer()
        {
            presence |= NetworkedPresence.Local;
            TryInitialize();
        }

        public override void OnStartClient()
        {
            if (!isLocalPlayer)
                presence |= NetworkedPresence.Remote;

            TryInitialize();
        }

        private void TryInitialize()
        {
            if (_initialized)
                return;

            if (isServer && isClient)
            {
                if (presence.HasFlag(NetworkedPresence.Server) &&
                    presence.HasFlag(NetworkedPresence.Local))
                {
                    FinalizeInit();
                }
                else if (presence.HasFlag(NetworkedPresence.Server) &&
                         presence.HasFlag(NetworkedPresence.Remote))
                {
                    FinalizeInit();
                }
            }
            else
            {
                if (presence != NetworkedPresence.Undefined)
                    FinalizeInit();
            }
        }

        private void FinalizeInit()
        {
            _initialized = true;

            if (TryGetComponent<MonoEntity>(out var monoEntity))
            {
                monoEntity.Initialize(presence);
            }
        }
    }
}