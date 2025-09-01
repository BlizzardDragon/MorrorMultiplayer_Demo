using System;
using _project.Scripts.Game.Entities.Player.View;
using Unity.VisualScripting;
using UnityEngine;

namespace _project.Scripts.Game.Entities.Player.Name
{
    public class RemotePlayerNamePresenter : IInitializable, IDisposable
    {
        private readonly IPlayerIdentity _identity;
        private readonly PlayerNameView _nameView;

        public RemotePlayerNamePresenter(IPlayerIdentity identity, PlayerNameView nameView)
        {
            _identity = identity;
            _nameView = nameView;
        }

        public void Initialize()
        {
            _nameView.RenderName(_identity.Name);
        }

        public void OnEnable()
        {
            _identity.NameChanged += OnNameChanged;
        }

        public void OnDisable()
        {
            _identity.NameChanged -= OnNameChanged;
        }

        private void OnNameChanged(string name)
        {
            _nameView.RenderName(name);
        }

        public void Dispose()
        {
            GameObject.Destroy(_nameView.gameObject);
        }
    }
}