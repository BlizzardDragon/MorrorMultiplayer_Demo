using Entity.Core;
using UnityEngine;

namespace _project.Scripts.Game.Entities.Modules
{
    public class ObjectModule : EntityModuleCompositeRootBase
    {
        [SerializeField] private GameObject _source;

        public override void Create(IEntity entity)
        {
            entity.AddModule(_source);
            entity.AddModule(_source.transform);

            if (_source.TryGetComponent<Rigidbody>(out var rb))
            {
                entity.AddModule(rb);
            }
        }
    }
}