using UnityEngine;

namespace CoreLibrary.Character
{
    [DisallowMultipleComponent]
    [RequireComponent(typeof(GravityDataStorage))]
    public class ThrowHandler : BaseActionHandler
    {
        public float defaultThrowForce = 1.0f;

        public Vector3 Direction { get; set; } = Vector3.zero;
        public float ThrowForce { get; set; }

        public void Throw(Vector3 direction, float force = 0)
        {
            ThrowForce = force == 0
                ? defaultThrowForce
                : force;

            Direction = direction;

            Trigger();
        }
    }
}