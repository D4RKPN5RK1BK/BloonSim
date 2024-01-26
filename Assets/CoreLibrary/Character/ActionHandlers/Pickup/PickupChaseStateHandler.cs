using UnityEngine;

namespace CoreLibrary.Character
{
    internal class PickupChaseStateHandler : MonoBehaviour
    {
        public bool ChasingRequired { get; set; }
        public GameObject ChasingTarget { get; set; }

        public void Chase(GameObject target)
        {
            ChasingRequired = true;
            ChasingTarget = target;
        }
    }
}
