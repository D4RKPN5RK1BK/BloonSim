using System;
using System.Collections.Generic;
using UnityEngine;

namespace CoreLibrary.Common
{
    [Serializable]
    public class Pool
    {
        public string Tag;

        public GameObject ObjectPrefab;

        public int StartQuantity;

        public Stack<GameObject> Objects;
    }
}

