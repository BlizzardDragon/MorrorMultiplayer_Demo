using Entity.Core;
using Mirror;
using UnityEngine;

namespace _project.Scripts.Game.Entities
{
    public class StopEntity : NetworkBehaviour
    {
        [SerializeField] private MonoEntity _monoEntity;

        public override void OnStopClient()
        {
            _monoEntity.enabled = false;
        }
    }
}