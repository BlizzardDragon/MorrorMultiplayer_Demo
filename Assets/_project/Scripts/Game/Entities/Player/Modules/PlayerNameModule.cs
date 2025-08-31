using _project.Scripts.Game.Entities.Player.Name;
using _project.Scripts.Game.Entities.Player.View;
using Entity.Core;
using UnityEngine;

namespace _project.Scripts.Game.Entities.Player.Modules
{
    public class PlayerNameModule : EntityModuleCompositeRootBase
    {
        [SerializeField] private PlayerNameSync _nameSync;
        [SerializeField] private PlayerNameView _nameView;

        private PlayerNamePresenter _namePresenter;
        private PlayerNameFollower _nameFollower;

        public override void Create(IEntity entity)
        {
            var transformSource = entity.GetModule<Transform>();
            var identity = entity.GetModule<IPlayerIdentity>();

            entity.AddModule<IPlayerNameSync>(_nameSync);
            
            _namePresenter = new PlayerNamePresenter(identity, _nameView);
            _nameFollower = new PlayerNameFollower(transformSource, _nameView.transform);

            AddUpdatable(_nameFollower);
        }

        public override void Initialize()
        {
            _nameFollower.Initialize();
            _namePresenter.OnEnable();
        }

        protected override void OnBeforeDestroy()
        {
            _namePresenter.OnDisable();
        }
    }
}