using Assets.Scripts.UI.Enum;
using UnityEngine;

namespace Assets.Scripts.UI
{
    public class MenuSwitcher : MonoBehaviour
    {
        public Animator background;
        public Animator mainPage;
        public Animator settings;

        private readonly int Left = Animator.StringToHash(nameof(Left));
        private readonly int Right = Animator.StringToHash(nameof(Right));
        private readonly int Center = Animator.StringToHash(nameof(Center));
        private readonly int Main = Animator.StringToHash(nameof(Main));
        private readonly int Settings = Animator.StringToHash(nameof(Settings));

        private void Start()
        {
            mainPage.SetTrigger(Center);
            settings.SetTrigger(Right);
        }

        public void Switch(MenuPage page)
        {
            switch (page)
            {
                case MenuPage.Main:
                    background.SetTrigger(Main);
                    mainPage.SetTrigger(Center);
                    settings.SetTrigger(Right);
                    break;
                case MenuPage.Settings:
                    background.SetTrigger(Settings);
                    mainPage.SetTrigger(Left);
                    settings.SetTrigger(Center);
                    break;
            }
        }
    }
}