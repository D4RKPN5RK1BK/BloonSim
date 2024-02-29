using UnityEngine;

namespace Assets.Scripts.UI
{
    internal class BackgroundLayer : MonoBehaviour
    {

        private bool requireToMove;

        private RectTransform rectTransform;

        private Vector3 initialPosition;

        private Vector3 targetPosition;

        public void MoveLayer(Vector3 target, float seconds)
        {
            requireToMove = true;
        }

        private void Update()
        {
            if (!requireToMove)
                return;
        }
    }
}
