using System;
using UnityEngine;

namespace CoreLibrary.Damage
{
    /// <summary>
    /// Содержит информацию о нанесенном уроне
    /// </summary>
    [Serializable]
    public class HitModel
    {
        /// <summary>
        /// Сила отбрасывания
        /// </summary>
        [Range(0, 10)]
        public int knockbackStrenght = 1;

        /// <summary>
        /// Наносимый урон
        /// </summary>
        public float damage = 1;

        /// <summary>
        /// Расположение источника урона
        /// </summary>
        public Vector3 SourcePosition { get; set; } = Vector3.zero;
    }
}