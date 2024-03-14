using System;
using UnityEngine;

namespace CoreLibrary.Common
{
    [Serializable]
    public record WalkModel
    {
        public float force = 10.0f;

        [Space(10)]

        public float smoothTime;

        [Space(10)]

        public float rotationSpeed = 10;

        [Space(10)]

        public float fallForce = 300f;

        [Range(0.0f, 1.0f)]
        public float airControlModifier;

        [NonSerialized]
        public Vector3 velocity;
    }
}
