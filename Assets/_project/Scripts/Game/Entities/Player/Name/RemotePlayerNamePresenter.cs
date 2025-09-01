using _project.Scripts.Game.Entities.Player.View;
using Unity.VisualScripting;

namespace _project.Scripts.Game.Entities.Player.Name
{
    public class RemotePlayerNamePresenter : IInitializable 
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
    }
}