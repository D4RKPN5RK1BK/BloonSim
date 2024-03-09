using System;
using UnityEngine;

namespace Assets.Scripts.Common
{
    public class PickupDetector : MonoBehaviour
    {
        private float detectionBuffer = 0.1f;
        private float rayDistance = 6.0f;

        private float collisionDetected { get; set; }

        public Action<GameObject> PickupFound;

        public Action PickupLost;

        private void Update()
        {
            if (collisionDetected < Time.time - detectionBuffer)
            {
                var ray = new Ray(transform.position, transform.forward);
                var collided = Physics.Raycast(ray, out var collision, 2, LayerMask.GetMask("Pickups"));

                if (collided)
                {
                    collisionDetected = Time.time;
                    PickupFound(collision.collider.gameObject);
                }
                else
                    PickupLost();
            }




        }


    }
}