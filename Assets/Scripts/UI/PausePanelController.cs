using CoreLibrary.Common;
using UnityEngine;

namespace Assets.Scripts.UI
{
    public class PausePanelController : MonoBehaviour
    {
        private GameObject panel;
        private CommonController _commonController;

        private void Awake()
        {
            panel = transform.Find("Panel").gameObject;

        }

        private void Start()
        {
            _commonController = CommonController.Instance;

            panel.SetActive(_commonController.InPause);

            _commonController.OnPauseToggle += () => { panel.SetActive(true); };
            _commonController.OnResumeToggle += () => { panel.SetActive(false); };
        }
    }
}