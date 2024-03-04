using UnityEngine;

namespace Assets.Scripts.UI
{
    [RequireComponent(typeof(Animator))]
    public class TransactionUIHandler : MonoBehaviour
    {
        private Animator _animator;

        private static readonly int Begin = Animator.StringToHash(nameof(Begin));
        private static readonly int End = Animator.StringToHash(nameof(End));

        private void Awake()
        {
            _animator = GetComponent<Animator>();
        }

        public void StartTransaction()
        {
            _animator.SetTrigger(Begin);
        }

        public void EndTransaction()
        {
            _animator.SetTrigger(End);
        }
    }
}