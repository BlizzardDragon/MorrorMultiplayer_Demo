using Mirror;
using UnityEngine;

namespace _project.Scripts.Game.Entities.Player.Item
{
    public interface IPlayerItemSpawner
    {
        void CmdSpawnItem();
    }

    public class PlayerItemSpawner : NetworkBehaviour, IPlayerItemSpawner
    {
        [SerializeField] private GameObject _itemPrefab;
        [SerializeField] private Transform _spawnSource;

        [Command]
        public void CmdSpawnItem()
        {
            var randomRotation =
                Quaternion.Euler(new Vector3(GetRandomAngle(), GetRandomAngle(), GetRandomAngle()));

            var item = GameObject.Instantiate(_itemPrefab, _spawnSource.position, randomRotation);
            NetworkServer.Spawn(item);

            float GetRandomAngle() => Random.Range(0f, 360f);
        }
    }
}