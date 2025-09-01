using System;
using _project.Scripts.Game.Entities.Player.View;
using UnityEngine;

namespace _project.Scripts.Game.Entities.Player.Name
{
    public class ClientPlayerNamePresenter : IDisposable
    {
        private readonly IPlayerNameSync _nameSync;
        private readonly PlayerNameView _nameView;

        public ClientPlayerNamePresenter(IPlayerNameSync nameSync, PlayerNameView nameView)
        {
            _nameSync = nameSync;
            _nameView = nameView;
        }

        public void OnEnable()
        {
            _nameSync.NameChanged += OnNameChanged;
        }

        public void OnDisable()
        {
            _nameSync.NameChanged -= OnNameChanged;
        }

        private void OnNameChanged(string name)
        {
            _nameView.RenderName(name);
        }

        public void Dispose()
        {
            if (_nameView)
            {
                GameObject.Destroy(_nameView.gameObject);
            }
        }
    }
}