using CoreLibrary.Common;
using UnityEngine;

namespace CoreLibrary.Character
{
    [DisallowMultipleComponent]
    [RequireComponent(typeof(GravityDataStorage))]
    public class WalkHandler : MonoBehaviour
    {
        public WalkModel walkModel;
        public WalkModel runModel;

        public Vector3 CurrentDirection { get; set; }

        public WalkModel CurrentModel { get; private set; }

        public bool RequireRun { get; private set; }

        public Vector2 WalkDirection { get; private set; }

        private void Awake()
        {
            CurrentModel = walkModel;
        }

        public virtual void Walk(Vector2 direction)
        {
            WalkDirection = direction;
        }

        public void StartRun()
        {
            RequireRun = true;
            CurrentModel = runModel;
        }

        public void StopRun()
        {
            RequireRun = false;
            CurrentModel = walkModel;
        }
    }
}