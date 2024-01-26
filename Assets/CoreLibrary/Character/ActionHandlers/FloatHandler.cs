using UnityEngine;

namespace CoreLibrary.Character
{
    [DisallowMultipleComponent]
    [RequireComponent(typeof(GravityDataStorage))]
    public class FloatHandler : BaseActionHandler
    {
        public float floatBuffer = 0.2f;

        public float floatRepeatBuffer = 0.15f;

        public float maxForce = 10.0f;

        public float speedup = 10.0f;

        [Space(10)]

        public float floatOffset = 0;

        public float FloatEndTime { get; set; }
        public float FloatBufferEndTime { get; set; }
        public float FloatHeight { get; set; }

        private float _floatRepeatLock { get; set; }

        private void Awake()
        {
            _floatRepeatLock = Mathf.Min(floatRepeatBuffer, 0.2f);
            _floatRepeatLock = Mathf.Max(_floatRepeatLock, 0);
        }

        public void Float(float height)
        {
            FloatHeight = height;

            if (FloatBufferEndTime > Time.time)
            {
                FloatEndTime = Time.time + floatBuffer;
                FloatBufferEndTime = Time.time + floatRepeatBuffer;
                Trigger();
            }
        }
    }
}