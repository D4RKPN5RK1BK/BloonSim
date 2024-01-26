using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace CoreLibrary.Routing
{
    /// <summary>
    /// <para> Патрулирование по последовательности наборов точек </para>
    /// <para> После дохождения до последней точки, следующим обхектом становится первая точка. И так по кругу. </para>
    /// </summary>
    public class Patrolling : MonoBehaviour
    {
        /// <summary>
        /// Расположение точек потруля относительно объекта. Рукомендуется использовать GlobalPathPoints вместо них
        /// </summary>
        public List<Vector3> pathPoints = new();

        /// <summary>
        /// Глобальные координаты точек для патруля
        /// </summary>
        public IEnumerable<Vector3> GlobalPathPoints => pathPoints?.Select(i => i + transform.position);
    }
}

