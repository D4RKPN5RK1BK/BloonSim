using UnityEngine;

namespace CoreLibrary.Character
{
    public class DashHandler : BaseActionHandler
    {
        public float dashForce = 60;
        public float DashDuration = 0.5f;

        public float DashEndTime { get; private set; }
        public Vector3 Direction { get; private set; }

        public virtual void Dash(Vector3 direction)
        {
            DashEndTime = Time.time + DashDuration;
            Direction = direction.normalized;
            Trigger();
        }
    }
}