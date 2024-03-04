using Assets.Scripts.Common;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.UI
{
    public class SceneLoadApplayer : MonoBehaviour
    {
        public string sceneName;
        public float offset = 1.0f;

        private TransactionController _transactionController;

        private void Start()
        {
            _transactionController = TransactionController.Instance;
        }

        public void LoadScene()
        {
            SceneManager.LoadScene(sceneName);
        }

        public void LoadSceneWithTransaction()
        {
            StartCoroutine(LoadLevelEnumerator());
        }

        private IEnumerator LoadLevelEnumerator()
        {
            CrossSceneDataController.Instance.transactionRequire = true;
            CrossSceneDataController.Instance.transactionName = Transactions.Bubbles;

            _transactionController.StartTransaction(Transactions.Bubbles);
            yield return new WaitForSecondsRealtime(offset);
            SceneManager.LoadScene(sceneName);
        }
    }
}