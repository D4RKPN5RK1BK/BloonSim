using Assets.Scripts.Common;
using CoreLibrary.Character;
using CoreLibrary.Common;
using UnityEngine;

namespace Assets.Scripts.Character.ActionHandlers
{
    [RequireComponent(typeof(BloonCounter))]
    public class PickupHandler : BaseActionHandler
    {
        private PoolController poolController;
        private PickupDetector pickupDetector;
        private BloonCounter bloonCounter;

        private void Awake()
        {
            bloonCounter = GetComponent<BloonCounter>();
        }

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
                bloonCounter.BloonCount++;
            }

            Trigger();
        }
    }
}