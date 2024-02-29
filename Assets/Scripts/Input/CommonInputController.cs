using CoreLibrary.Common;
using CoreLibrary.Input;

namespace Assets.Scripts.Input
{
    public class CommonInputController : InputControler<CommonInput>
    {
        private CommonController _commonController;

        private void Start()
        {
            ActionSet.InPause.Disable();

            _commonController = CommonController.Instance;

            _commonController.OnPauseToggle += () =>
            {
                ActionSet.InGame.Disable();
                ActionSet.InPause.Enable();
            };

            _commonController.OnResumeToggle += () =>
            {
                ActionSet.InPause.Disable();
                ActionSet.InGame.Enable();
            };

            ActionSet.InGame.Pause.performed += _ => { _commonController.Pause(); };
            ActionSet.InPause.Pause.performed += _ => { _commonController.Pause(); };
        }
    }
}