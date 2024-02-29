using Assets.Scripts.UI.Enum;
using UnityEngine;

namespace Assets.Scripts.UI
{
    public class MenuTrigger : MonoBehaviour
    {
        public MenuPage menuPage;

        private MenuSwitcher menuSwitcher;

        private void Awake()
        {
            menuSwitcher = GetComponentInParent<MenuSwitcher>();
        }

        public void TriggerMenu()
        {
            menuSwitcher.Switch(menuPage);
        }
    }
}