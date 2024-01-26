using System;
using UnityEngine;

namespace CoreLibrary.Common
{
    [Serializable]
    public class CameraData
    {
        public float scaleSpeed = 1;

        [Space(10)]

        public float minDistance = 3.0f;

        public float maxDistance = 20.0f;

        [Space(10)]

        public float rotationAccelerationSpeed = 1;

        public float rotationStopSpeed = 20;

        [Space(10)]

        public bool cameraLock;
    }
}