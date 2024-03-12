using Assets.Scripts.Common;
using CoreLibrary.Common;
using UnityEngine;

namespace Assets.Scripts.UI
{
    public class PickupTipController : MonoBehaviour
    {
        private readonly int Select = Animator.StringToHash(nameof(Select));
        private readonly int Deselect = Animator.StringToHash(nameof(Deselect));

        public PickupDetector source;

        private Animator animator;

        private bool active;
        private bool pauseHide;

        private void Awake()
        {
            animator = GetComponent<Animator>();
        }

        private void Start()
        {
            var commonController = CommonController.Instance;

            source.PickupFound += _ => { animator.SetTrigger(Select); active = true; };
            source.PickupLost += () => { animator.SetTrigger(Deselect); active = false; };

            commonController.OnPauseToggle += () =>
            {
                if (active)
                {
                    animator.SetTrigger(Deselect);
                    pauseHide = true;
                }
            };
            commonController.OnResumeToggle += () =>
            {
                if (pauseHide)
                {
                    animator.SetTrigger(Select);
                    pauseHide = false;
                }
            };
        }
    }
}