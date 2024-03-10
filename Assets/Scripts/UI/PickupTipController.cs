using Assets.Scripts.Common;
using UnityEngine;

namespace Assets.Scripts.UI
{
    public class PickupTipController : MonoBehaviour
    {
        private readonly int Select = Animator.StringToHash(nameof(Select));
        private readonly int Deselect = Animator.StringToHash(nameof(Deselect));

        public PickupDetector source;

        private Animator animator;

        private void Awake()
        {
            animator = GetComponent<Animator>();
        }

        private void Start()
        {
            source.PickupFound += _ => { animator.SetTrigger(Select); };
            source.PickupLost += () => { animator.SetTrigger(Deselect); };
        }
    }
}