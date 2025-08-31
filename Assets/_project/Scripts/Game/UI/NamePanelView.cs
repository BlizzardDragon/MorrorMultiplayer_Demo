using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace _project.Scripts.Game.UI
{
    public class NamePanelView : MonoBehaviour
    {
        [field: SerializeField] public TMP_InputField InputField { get; private set; }
        [field: SerializeField] public Button StartButton { get; private set; }

        public void ShowPanel()
        {
            gameObject.SetActive(true);
        }

        public void HidePanel()
        {
            gameObject.SetActive(false);
        }
    }
}