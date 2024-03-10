using CoreLibrary.Common;
using UnityEngine;

namespace Assets.Scripts.UI
{
    public class CroosController : MonoBehaviour
    {
        private CommonController commonController;

        private GameObject panel;

        private void Start()
        {
            panel = gameObject.transform.Find("Panel").gameObject;

            commonController = CommonController.Instance;
            commonController.OnPauseToggle += () => { panel.SetActive(false); };
            commonController.OnResumeToggle += () => { panel.SetActive(true); };
        }
    }
}