using UnityEngine;

namespace CoreLibrary.Character
{
    public class RotateHandler : MonoBehaviour
    {
        public float rotationForce = 1.0f;

        [Space(10)]

        public float acceliration = 10.0f;
        public float roationDrag = 10.0f;

        public Vector2 Rotation { get; set; }

        public virtual void Rotate(Vector2 rotation)
        {
            Rotation = rotation;
        }
    }
}

