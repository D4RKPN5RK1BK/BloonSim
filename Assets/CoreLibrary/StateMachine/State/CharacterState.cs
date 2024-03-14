using UnityEngine;

namespace CoreLibrary.StateMachine
{
    /// <summary>
    /// <para>Стейт отчечает за обработку состояния персонажа. А также каждый раз проверяет нужно ли переключиться на другой стейт</para>
    /// <para>Стейт не знает как в него можно попасть, но знает в какие стейты можно из него выбраться</para>
    /// </summary>
    /// <typeparam name="TModel"></typeparam>
    /// <typeparam name="TFactory"></typeparam>
    public abstract class CharacterState<TFactory>
    {
        /// <summary>
        /// <para>Содержит в себе все необходимые данные объекта для обработки его состояний.</para>
        /// </summary>
        protected readonly GameObject Model;
        
        /// <summary>
        /// Механизм отвечающий за то как интанциируются стейты, 
        /// а ткаже распологает списком по которому эти самые стейты можно получить
        /// </summary>
        protected readonly TFactory Factory;

        /// <summary>
        /// Обработчик стейтов. Цепляется непосредственно к Character объекту.
        /// </summary>
        private readonly IStateContext<TFactory> Handler;

        protected CharacterState(GameObject model, IStateContext<TFactory> handler, TFactory factory)
        {
            Model = model;
            Handler = handler;
            Factory = factory;
        }

        /// <summary>
        /// Обработка вхождения в данное состояние. 
        /// <para>Напримсер, обновление или добавление новых перенных которые в дальнейшем будут использоваться при обработке состояния.</para>
        /// </summary>
        public abstract void EnterState();

        /// <summary>
        /// Обработка выхода из текущего состояния.
        /// </summary>
        public abstract void ExitState();

        /// <summary>
        /// Обработка состояния
        /// <para>Выполняет основную логику состояния. Например, применение гравитации на персонажа</para>
        /// </summary>
        public abstract void HandleState();

        /// <summary>
        /// Функция для добавление физики к объекту, например AddForce. Создана для того чтобы сувать ее в FixedUpdate
        /// </summary>
        public virtual void FixedHandleState() { }

        /// <summary>
        /// Проверяет на то что состояние необходимо обновить, 
        /// и обновляет его в зависисости от прописаного условия
        /// </summary>
        public abstract void CheckSwitchState();

        /// <summary>
        /// Меняем состояние персонажа на новое
        /// </summary>
        /// <param name="state"></param>
        protected void SwitchState(CharacterState<TFactory> state)
        {
            ExitState();
            state.EnterState();
            Handler.CurrentState = state;
        }
    }
}