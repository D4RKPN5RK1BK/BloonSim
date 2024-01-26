using CoreLibrary.Common;
using UnityEngine;

namespace CoreLibrary.Routing
{
    /// <summary>
    /// Бассейн через которого существа не будут вытекать
    /// </summary>
    [RequireComponent(typeof(NeuronComponent))]
    public class GroupPoolContainer : MonoBehaviour
    {
        private SphereCollider sphereCollider;

        private void Awake()
        {
            sphereCollider = GetComponent<SphereCollider>();
        }
    }
}