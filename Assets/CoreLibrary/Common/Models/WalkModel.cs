using System;
using UnityEngine;

namespace CoreLibrary.Common
{
    [Serializable]
    public record WalkModel
    {
        public float maxForce = 10.0f;

        [Space(10)]

        public float speedup = 10f;
        public float drag = 10f;

        [Space(10)]

        public float rotationSpeed = 10;

        [Space(10)]

        public float fallForce = 300f;

        [Range(0.0f, 1.0f)]

        public float airControlModifier;
    }
}
