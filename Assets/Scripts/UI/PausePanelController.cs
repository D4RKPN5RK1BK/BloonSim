using CoreLibrary.Common;
using UnityEngine;

namespace Assets.Scripts.UI
{
    public class PausePanelController : MonoBehaviour
    {
        private readonly int Exit = Animator.StringToHash(nameof(Exit));
        private readonly int Enter = Animator.StringToHash(nameof(Enter));

        private CommonController _commonController;
        private Animator animator;

        private void Awake()
        {
            animator = GetComponent<Animator>();
        }

        private void Start()
        {
            _commonController = CommonController.Instance;

            if (_commonController.InPause)
                animator.SetTrigger(Enter);
            else
                animator.SetTrigger(Exit);

            _commonController.OnPauseToggle += () => { animator.SetTrigger(Enter); };
            _commonController.OnResumeToggle += () => { animator.SetTrigger(Exit); };
        }
    }
}