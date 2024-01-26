using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace CoreLibrary.Common
{
    /// <summary>
    /// Позволяет группировать объекты, объекты являются двусвязными
    /// и могут свбодно получить информацию друг о друге
    /// </summary>
    public class NeuronComponent : MonoBehaviour, IEnumerable<NeuronComponent>
    {   
        private List<NeuronComponent> Items { get; set; } = new();

        private bool _isLocked;

        public bool IsLocked => _isLocked;

        /// <summary>
        /// Ивент для обработки добавления объекта
        /// </summary>
        public Action<NeuronComponent> LinkConnection { get; set; }

        /// <summary>
        /// Ивент для обработки разрыва связи с объектом
        /// </summary>
        public Action<NeuronComponent> LinkDisconection { get; set; }

        /// <summary>
        /// Добавляет связь между компонентами
        /// </summary>
        /// <param name="subscriber"></param>
        public void Add(NeuronComponent subscriber)
        {
            if (IsLocked || subscriber.IsLocked || Items.Contains(subscriber))
                return;

            Items.Add(subscriber);
            LinkConnection?.Invoke(subscriber);

            if (!subscriber.Items.Contains(this))
                subscriber.Add(this);
        }

        /// <summary>
        /// Удаляет связь межде компонентами
        /// </summary>
        /// <param name="subscriber"></param>
        public void Remove(NeuronComponent subscriber)
        {
            if (IsLocked || subscriber.IsLocked)
                return;

            Items.Remove(subscriber);
            LinkDisconection?.Invoke(subscriber);

            if (subscriber.Items.Contains(this))
                subscriber.Remove(this);
        }

        /// <summary>
        /// <para>Добавляет связи с компонентами указанными в списке если связей еще нет</para>
        /// <para>Удаляет связь со всеми компонентами не указанными в списке</para>
        /// </summary>
        /// <param name="items">Новый набор компонентов</param>
        public void Rearrange(NeuronComponent[] items)
        {
            Clear();

            for (var i = 0; i < items.Count(); i++)
                Add(items[i]);
        }

        public void Clear()
        {
            while(Items.Any())
                Remove(Items[0]);
        }

        /// <summary>
        /// Возвращает все элементы с которыми в данный момент установлена связь
        /// </summary>
        /// <returns> Связанные элементы в формате List</returns>
        public List<NeuronComponent> All() => Items;

        public void Lock()
        {
            _isLocked = true;
        }

        public void Unlock()
        {
            _isLocked = false;
        }

        public IEnumerator<NeuronComponent> GetEnumerator()
        {
            return Items.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return Items.GetEnumerator();
        }
    }
}
