using Unity.VisualScripting;
using UnityEngine;
using VampireSquid.Common.CompositeRoot;

namespace _project.Scripts.Game.Entities.Player.Name
{
    public class PlayerNameFollower : IInitializable, IUpdateLoop
    {
        private readonly Transform _targetSource;
        private readonly Transform _nameSource;

        public PlayerNameFollower(Transform targetSource, Transform nameSource)
        {
            _targetSource = targetSource;
            _nameSource = nameSource;
        }

        public void Initialize()
        {
            _nameSource.rotation = Quaternion.LookRotation(Vector3.down, Vector3.forward);
            _nameSource.parent = null;
        }

        public void OnUpdate(float deltaTime)
        {
            _nameSource.position = _targetSource.position;
        }
    }
}