using Mirror;
using VampireSquid.Common.BeautifulLogs;
#if ODIN_INSPECTOR
using Sirenix.OdinInspector;
#endif

namespace VampireSquid.Common.Connections
{
    public class Connection : NetworkBehaviour
    {
#if ODIN_INSPECTOR
        [ReadOnly]
#endif
        public NetworkedPresence presence = NetworkedPresence.Server;

        [SyncVar(hook = nameof(OnIDChanged))]
        private string identification;

        [SyncVar]
        private bool runsHost;

        public string Identification => identification;
        public bool RunsHost => runsHost;

        public override void OnStartClient()
        {
            base.OnStartClient();

            var id = $"Client {netId}";
            BLog.LogImportant($"Connection started for ID: [{netId}] - {id}");

            if (isLocalPlayer)
            {
                CmdUpdateInfo(id, NetworkServer.active && isClient);
            }

            gameObject.name = id;
        }

        public override void OnStopClient()
        {
            base.OnStopClient();
            BLog.LogImportant($"Connection ended [ID: {netId}]");
        }

        public NetworkedPresence GetPresence()
        {
            var presence = NetworkedPresence.Undefined;

            if (isServer)
                presence |= NetworkedPresence.Server;

            if (isServer && isClient)
                presence |= NetworkedPresence.Host;

            if (isLocalPlayer)
                presence |= NetworkedPresence.Local;
            else
                presence |= NetworkedPresence.Remote;

            return presence;
        }

        [Command]
        private void CmdUpdateInfo(string id, bool isHost)
        {
            identification = id;
            runsHost = isHost;
        }

        private void OnIDChanged(string oldValue, string newValue)
        {
            gameObject.name = Identification;
        }
    }
}