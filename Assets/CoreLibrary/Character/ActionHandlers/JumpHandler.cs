using System;
using UnityEngine;

namespace CoreLibrary.Character
{
    [DisallowMultipleComponent]
    [RequireComponent(typeof(GravityDataStorage))]
    public class JumpHandler : BaseActionHandler
    {
        public float jumpBuffer;
        public float jumpForce;

        [Range(0f, 1f)]
        public float jumpControlScale;

        public float JumpBufferEnd { get; private set; }
        public bool JumpRequired { get; set; }
        public bool ContinueJumpRequired { get; set; }

        public void ContinueJump()
        {
            ContinueJumpRequired = true;
        }

        public void Jump()
        {
            JumpBufferEnd = Time.time + jumpBuffer;
            JumpRequired = true;
            Trigger();
        }
    }
}