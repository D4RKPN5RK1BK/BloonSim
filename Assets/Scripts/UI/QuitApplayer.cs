using Assets.Scripts.Save;
using CoreLibrary.Save;
using UnityEngine;

namespace Assets.Scripts.UI
{
    public class QuitApplayer : MonoBehaviour
    {
        private CrossSceneDataController crossSceneDataController;
        private SaveFileHelper<SaveDataModel> saveFileHelper;

        private void Start()
        {
            crossSceneDataController = CrossSceneDataController.Instance;
            saveFileHelper = new SaveFileHelper<SaveDataModel>();
        }

        public void Quit()
        {
            saveFileHelper.Save(crossSceneDataController.Model);
            Debug.Log("Quit");
            Application.Quit();
        }
    }
}