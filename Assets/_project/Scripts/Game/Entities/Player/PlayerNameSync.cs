using System;
using Mirror;

namespace _project.Scripts.Game.Entities.Player
{
    public interface IPlayerNameSync
    {
        string Name { get; }

        event Action<string> NameChanged;

        void CmdSetName(string name);
    }

    public class PlayerNameSync : NetworkBehaviour, IPlayerNameSync
    {
        [field: SyncVar(hook = nameof(OnNameChanged))]
        public string Name { get; private set; }

        public event Action<string> NameChanged;
        
        [Command]
        public void CmdSetName(string name)
        {
            Name = name;
        }
        
        private void OnNameChanged(string oldName, string newName)
        {
            NameChanged?.Invoke(newName);
        }
    }
}