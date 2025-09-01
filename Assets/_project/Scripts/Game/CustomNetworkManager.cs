using Mirror;
using UnityEngine;

public class CustomNetworkManager : NetworkManager
{
    [SerializeField] private bool AutoInitEntity;
    
    public override void OnServerAddPlayer(NetworkConnectionToClient conn)
    {
        if (conn.identity != null)
            return;

        Transform startPos = GetStartPosition();
        GameObject player = startPos != null
            ? Instantiate(playerPrefab, startPos.position, startPos.rotation)
            : Instantiate(playerPrefab, Vector3.zero, Quaternion.identity);

        NetworkServer.AddPlayerForConnection(conn, player);

        if (AutoInitEntity)
        {
            
        }
    }
}