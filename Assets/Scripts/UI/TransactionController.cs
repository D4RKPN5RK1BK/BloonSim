using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.UI
{
    public class TransactionController : MonoBehaviour
    {
        public static TransactionController Instance { get; private set; }

        public List<TransactionModel> transactions;

        private readonly IDictionary<string, TransactionUIHandler> _transactions = new Dictionary<string, TransactionUIHandler>();

        private void Awake()
        {
            if (Instance != null)
                Destroy(Instance);
            else
            {
                Instance = this;
                foreach (var t in transactions)
                {
                    var instance = Instantiate(t.transaction, transform);
                    var transaction = instance.GetComponent<TransactionUIHandler>();
                    _transactions.Add(t.tag, transaction);
                }
            }
        }

        public void StartTransaction(string tag)
        {
            var transaction = _transactions[tag];
            transaction.StartTransaction();
        }

        public void EndTransaction(string tag)
        {
            var transaction = _transactions[tag];
            transaction.EndTransaction();
        }
    }
}