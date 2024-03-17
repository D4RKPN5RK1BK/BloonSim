using CoreLibrary.Save;
using System.Linq;
using UnityEngine;

namespace Assets.Scripts.Save
{
    internal class CrossSceneDataController : MonoBehaviour
    {
        private const string SaveName = "default";

        private SaveFileHelper<SaveDataModel> saveHelper;

        public string transactionName;

        public bool transactionRequire;
        public static CrossSceneDataController Instance { get; private set; }

        public SaveDataModel Model { get; set; }

        private void Awake()
        {
            if (Instance != null)
                Destroy(this);
            else
            {
                Instance = this;
                DontDestroyOnLoad(this);
                saveHelper = new SaveFileHelper<SaveDataModel>();
                var saves = saveHelper.All();
                
                if (saves.Any(i => i.name == SaveName))
                {
                    Model = saveHelper.Load(SaveName);
                }
                else
                {
                    Debug.Log($"fail");
                    Model = new SaveDataModel()
                    {
                        name = SaveName
                    };
                }
            }
        }
    }
}
