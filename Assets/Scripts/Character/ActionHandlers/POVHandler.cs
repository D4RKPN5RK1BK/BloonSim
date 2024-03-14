using Cinemachine;
using CoreLibrary.Character;
using UnityEngine;

namespace Assets.Scripts.Character.ActionHandlers
{
    internal class POVHandler : RotateHandler
    {
        [Space(10)]
        public CinemachineVirtualCamera cameraTarget;

        Vector2 current;
        Vector2 currentVeclocity;

        private Transform character;
        private Transform head;

        private void Start()
        {
            character = transform.Find("Character");
            head = character.Find("Head");
            cameraTarget.Follow = head;
        }

        public override void Rotate(Vector2 rotation)
        {
            if (rotation.y + current.y > 70f || rotation.y + current.y < -70f)
                rotation.y = 0;

            current = Vector2.SmoothDamp(current, current + rotation, ref currentVeclocity, 0.05f);

            character.localRotation = Quaternion.Euler(0, current.x, 0);
            head.localRotation = Quaternion.Euler(-current.y, 0, 0);
        }
    }
}
