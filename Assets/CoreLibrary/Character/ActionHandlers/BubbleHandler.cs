using UnityEngine;

namespace CoreLibrary.Character
{
    [DisallowMultipleComponent]
    internal class BubbleHandler : BaseActionHandler
    {
        public float bubbleDuration = 3.0f;
        public float bubbleDashForce = 10.0f;

        public bool RequireBubbleDestroy { get; set; }
        public float BubbleEndTime { get; set; }


        public virtual void BreakBubble()
        {
            RequireBubbleDestroy = true;
        }

        public virtual void Bubble()
        {
            RequireBubbleDestroy = false;
            BubbleEndTime = Time.time + bubbleDuration;
            Trigger();
        }
    }
}
