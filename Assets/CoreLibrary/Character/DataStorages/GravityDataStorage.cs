using UnityEngine;

namespace CoreLibrary.Character
{
    public class GravityDataStorage : MonoBehaviour
    {
        [Min(0)]
        [Tooltip("Сила гравитация оказываемая на персонажа")]
        public float gravityPressure = 1.0f;
    }
}
