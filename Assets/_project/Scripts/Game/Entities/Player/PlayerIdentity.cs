using System;
using Mirror;

namespace _project.Scripts.Game.Entities.Player
{
    public interface IPlayerIdentity
    {
        string Name { get; }

        event Action<string> NameChanged;

        void SetName(string name);
    }

    public class PlayerIdentity : NetworkBehaviour, IPlayerIdentity
    {
        [field: SyncVar(hook = nameof(OnNameChanged))]
        public string Name { get; private set; }

        public event Action<string> NameChanged;

        public void SetName(string name)
        {
            Name = name;
        }
        
        private void OnNameChanged(string oldName, string newName)
        {
            NameChanged?.Invoke(newName);
        }
    }
}