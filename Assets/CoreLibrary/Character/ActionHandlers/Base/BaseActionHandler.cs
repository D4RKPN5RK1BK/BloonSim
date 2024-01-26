using System;
using UnityEngine;

namespace CoreLibrary.Character
{
    public class BaseActionHandler : MonoBehaviour
    {
        public Action Trigger { get; set; } = () => { };
    }
}
