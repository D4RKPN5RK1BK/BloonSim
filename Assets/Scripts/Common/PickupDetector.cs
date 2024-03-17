using System;
using UnityEngine;

namespace Assets.Scripts.Common
{
    public class PickupDetector : MonoBehaviour
    {
        private float detectionBuffer = 0.05f;
        private float rayDistance = 3.0f;

        public bool IsPickupFound { get; private set; }
        public  GameObject Pickup { get; private set; }

        private float collisionDetected { get; set; }

        public Action<GameObject> PickupFound = _ => { };

        public Action PickupLost = () => { };

        private void Update()
        {
            if (collisionDetected < Time.time - detectionBuffer)
            {
                var ray = new Ray(transform.position, transform.forward);
                var collided = Physics.Raycast(ray, out var collision, rayDistance, LayerMask.GetMask("Pickups"));

                if (collided)
                {
                    var pick = collision.collider.gameObject;
                    if (pick != Pickup)
                    {
                        collisionDetected = Time.time;
                        Pickup = pick;
                    }

                    if (!IsPickupFound)
                    {
                        IsPickupFound = true;
                        PickupFound(pick);
                    }
                }
                else
                {
                    if (IsPickupFound)
                    {
                        Pickup = null;
                        IsPickupFound = false;
                        PickupLost();
                    }
                }
                    
            }
        }
    }
}