using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace CoreLibrary.Common
{
    /// <summary>
    /// <para>Контроллер пулов объектов</para> 
    /// <para>Под пулами подразумеваются группы объектов которые могут быть использованы другими контроллерами</para>
    /// </summary>
    public class PoolController : MonoBehaviour
    {
        /// <summary>
        /// Объект для заполнения контроллера из инспектора 
        /// </summary>
        public List<Pool> pools;

        /// <summary>
        /// Сами пулы
        /// </summary>
        private Dictionary<string, Stack<GameObject>> _activePools;


        public static PoolController Instance { get; private set; }

        private void Awake()
        {
            if (Instance != null)
                Destroy(this);
            else
            {
                Instance = this;

                _activePools = new Dictionary<string, Stack<GameObject>>();
                foreach (var p in pools)
                {
                    _activePools.Add(p.Tag, new Stack<GameObject>());
                    for (var i = 0; i < p.StartQuantity; i++)
                    {
                        var temp = Instantiate(p.ObjectPrefab, transform);
                        temp.SetActive(false);
                        _activePools[p.Tag].Push(temp);
                    }
                }
            }
        }

        ///<summary>
        /// Берет элемент из пула елментов по укащаному тегу
        ///</summary>
        public GameObject Take(string poolTag)
        {
            var pool = _activePools[poolTag];
            if (!pool.Any())
                ExpandPool(poolTag);

            var temp = _activePools[poolTag].Pop();
            temp.SetActive(true);

            return temp;
        }

        ///<summary>
        /// Берет элементы из пула елментов по укащаному тегу
        ///</summary>
        public IEnumerable<GameObject> Take(string poolTag, int count)
        {
            var list = new List<GameObject>();
            var pool = _activePools[poolTag];

            if (count >= pool.Count)
                ExpandPool(poolTag);

            for (var i = 0; i < count; i++)
                list.Add(_activePools[poolTag].Pop());

            return list;
        }

        private void ExpandPool(string poolTag)
        {
            var poolFactory = pools.First(i => i.Tag == poolTag);
            var pool = _activePools[poolTag];

            for (var i = 0; i < poolFactory.StartQuantity; i++)
            {
                var temp = Instantiate(poolFactory.ObjectPrefab, transform);
                temp.SetActive(false);
                pool.Push(temp);
            }
        }


        ///<summary>
        /// Возвращает элемент в стек с указанным тегом
        ///</summary>
        public void Return(string poolTag, GameObject element)
        {
            _activePools[poolTag].Push(element);
        }

        ///<summary>
        /// Возвращает элементы в стек с указанным тегом
        ///</summary>
        public void Return(string poolTag, IEnumerable<GameObject> elements)
        {
            foreach (var e in elements)
                _activePools[poolTag].Push(e);
        }
    }
}

