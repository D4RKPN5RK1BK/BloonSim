using UnityEngine;

namespace Assets.Scripts.Common
{
    internal class CrossSceneDataController : MonoBehaviour
    {
        public string transactionName;

        public bool transactionRequire;
        public static CrossSceneDataController Instance { get; private set; }

        private void Awake()
        {
            if (Instance != null)
                Destroy(this);
            else
            {
                Instance = this;
                DontDestroyOnLoad(this);
            }
                
        }
    }
}
