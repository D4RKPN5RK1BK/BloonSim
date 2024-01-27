using Cinemachine;
using CoreLibrary.Character;
using UnityEngine;

namespace Assets.Scripts.Character.ActionHandlers
{
    internal class POVHandler : RotateHandler
    {
        [Space(10)]
        public CinemachineVirtualCamera cameraTarget;

        private CinemachinePOV body;

        private Transform character;
        private Transform head;

        private float horizontalRotation;
        private float verticalRotation;

        private void Start()
        {
            character = transform.Find("Character");
            head = character.Find("Head");
            cameraTarget.Follow = head;
            body = cameraTarget.GetCinemachineComponent<CinemachinePOV>();
        }

        public override void Rotate(Vector2 rotation)
        {
            character.Rotate(0, rotation.x, 0);

            horizontalRotation += rotation.x;
            verticalRotation = ClampAngle(verticalRotation - rotation.y, -70, 70);

            character.localRotation = Quaternion.Euler(0, horizontalRotation, 0);
            head.localRotation = Quaternion.Euler(verticalRotation, 0, 0);
        }

        private float ClampAngle(float lfAngle, float lfMin, float lfMax)
        {
            if (lfAngle < -360f) lfAngle += 360f;
            if (lfAngle > 360f) lfAngle -= 360f;
            return Mathf.Clamp(lfAngle, lfMin, lfMax);
        }
    }
}
