using _project.Scripts.Game.Entities.Player.View;

namespace _project.Scripts.Game.Entities.Player.Name
{
    public class ClientPlayerNamePresenter
    {
        private readonly IPlayerIdentity _identity;
        private readonly PlayerNameView _nameView;

        public ClientPlayerNamePresenter(IPlayerIdentity identity, PlayerNameView nameView)
        {
            _identity = identity;
            _nameView = nameView;
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