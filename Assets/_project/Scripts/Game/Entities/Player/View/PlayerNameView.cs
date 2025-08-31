using TMPro;
using UnityEngine;

namespace _project.Scripts.Game.Entities.Player.View
{
    public class PlayerNameView : MonoBehaviour
    {
        [SerializeField] private TMP_Text _name;

        public void RenderName(string name)
        {
            _name.text = name;
        }
    }
}