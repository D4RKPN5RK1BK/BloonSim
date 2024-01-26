using UnityEngine;
using UnityEngine.InputSystem;

namespace CoreLibrary.Input
{
    /// <summary>
    /// Базовый класс для всех компонентов которые отвечают за котроль игрока
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class InputControler<T> : MonoBehaviour where T : IInputActionCollection2, new()
    {
        /// <summary>
        /// объект для действий игрока
        /// </summary>
        protected T ActionSet;

        protected virtual void Awake()
        {
            ActionSet = new T();
        }
        
        protected virtual void OnEnable()
        {
            ActionSet.Enable();
        }

        protected virtual void OnDisable()
        {
            ActionSet.Disable();
        }
    }
}