using Assets.Scripts.Common;
using CoreLibrary.Common;
using UnityEngine;

namespace Assets.Scripts.Character.ActionHandlers
{
    public class PickupHandler : MonoBehaviour
    {
        private PoolController poolController;
        private PickupDetector pickupDetector;

        private void Start()
        {
            poolController = PoolController.Instance;
            pickupDetector = GetComponentInChildren<PickupDetector>();
        }

        public void ActivatePickup()
        {
            if (pickupDetector.IsPickupFound)
            {
                var bloon = pickupDetector.Pickup.GetComponentInParent<BloonController>();
                bloon.gameObject.SetActive(false);
                poolController.Return(PoolTags.Bloons, bloon.gameObject);
            }
        }
    }
}