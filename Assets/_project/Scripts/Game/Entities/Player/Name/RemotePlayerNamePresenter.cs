using System;
using _project.Scripts.Game.Entities.Player.View;
using Unity.VisualScripting;
using UnityEngine;

namespace _project.Scripts.Game.Entities.Player.Name
{
    public class RemotePlayerNamePresenter : IInitializable, IDisposable
    {
        private readonly IPlayerNameSync _nameSync;
        private readonly PlayerNameView _nameView;

        public RemotePlayerNamePresenter(IPlayerNameSync nameSync, PlayerNameView nameView)
        {
            _nameSync = nameSync;
            _nameView = nameView;
        }

        public void Initialize()
        {
            _nameView.RenderName(_nameSync.Name);
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