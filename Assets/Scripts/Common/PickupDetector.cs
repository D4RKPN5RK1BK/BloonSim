using System;
using UnityEngine;

namespace Assets.Scripts.Common
{
    public class PickupDetector : MonoBehaviour
    {
        private float detectionBuffer = 0.05f;
        private float rayDistance = 6.0f;

        public bool IsPickupFound { get; private set; }
        public  GameObject Pickup { get; private set; }

        private float collisionDetected { get; set; }

        public Action<GameObject> PickupFound = _ => { Debug.Log($"PickupFound"); };

        public Action PickupLost = () => { Debug.Log($"PickupLost"); };

        private void Update()
        {
            if (collisionDetected < Time.time - detectionBuffer)
            {
                var ray = new Ray(transform.position, transform.forward);
                var collided = Physics.Raycast(ray, out var collision, 2, LayerMask.GetMask("Pickups"));

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