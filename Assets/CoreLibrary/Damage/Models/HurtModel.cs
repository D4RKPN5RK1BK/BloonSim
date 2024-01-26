using System;
using UnityEngine;

namespace CoreLibrary.Damage
{
    /// <summary>
    /// Содержит инормацию о полученном уроне
    /// </summary>
    [Serializable]
    public class HurtModel
    {
        /// <summary>
        /// Сопротивление отбрасыванию
        /// </summary>
        [Range(0, 10)]
        public int knockbackResistance = 0;

        [Min(0)]
        public float invicibilityTime = 1.0f;

        public float InvincibilityEndTime { get; set; }
    }
}