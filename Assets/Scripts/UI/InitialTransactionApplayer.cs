using Assets.Scripts.Common;
using Assets.Scripts.Save;
using UnityEngine;

namespace Assets.Scripts.UI
{
    public class InitialTransactionApplayer : MonoBehaviour
    {
        private void Start()
        {
            if (!string.IsNullOrEmpty(CrossSceneDataController.Instance.transactionName) && CrossSceneDataController.Instance.transactionRequire)
                TransactionController.Instance.EndTransaction(CrossSceneDataController.Instance.transactionName);
        }
    }
}