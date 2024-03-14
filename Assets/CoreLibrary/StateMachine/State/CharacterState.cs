using UnityEngine;

namespace CoreLibrary.StateMachine
{
    /// <summary>
    /// <para>����� �������� �� ��������� ��������� ���������. � ����� ������ ��� ��������� ����� �� ������������� �� ������ �����</para>
    /// <para>����� �� ����� ��� � ���� ����� �������, �� ����� � ����� ������ ����� �� ���� ���������</para>
    /// </summary>
    /// <typeparam name="TModel"></typeparam>
    /// <typeparam name="TFactory"></typeparam>
    public abstract class CharacterState<TFactory>
    {
        /// <summary>
        /// <para>�������� � ���� ��� ����������� ������ ������� ��� ��������� ��� ���������.</para>
        /// </summary>
        protected readonly GameObject Model;
        
        /// <summary>
        /// �������� ���������� �� �� ��� �������������� ������, 
        /// � ����� ����������� ������� �� �������� ��� ����� ������ ����� ��������
        /// </summary>
        protected readonly TFactory Factory;

        /// <summary>
        /// ���������� �������. ��������� ��������������� � Character �������.
        /// </summary>
        private readonly IStateContext<TFactory> Handler;

        protected CharacterState(GameObject model, IStateContext<TFactory> handler, TFactory factory)
        {
            Model = model;
            Handler = handler;
            Factory = factory;
        }

        /// <summary>
        /// ��������� ��������� � ������ ���������. 
        /// <para>���������, ���������� ��� ���������� ����� �������� ������� � ���������� ����� �������������� ��� ��������� ���������.</para>
        /// </summary>
        public abstract void EnterState();

        /// <summary>
        /// ��������� ������ �� �������� ���������.
        /// </summary>
        public abstract void ExitState();

        /// <summary>
        /// ��������� ���������
        /// <para>��������� �������� ������ ���������. ��������, ���������� ���������� �� ���������</para>
        /// </summary>
        public abstract void HandleState();

        /// <summary>
        /// ������� ��� ���������� ������ � �������, �������� AddForce. ������� ��� ���� ����� ������ �� � FixedUpdate
        /// </summary>
        public virtual void FixedHandleState() { }

        /// <summary>
        /// ��������� �� �� ��� ��������� ���������� ��������, 
        /// � ��������� ��� � ����������� �� ����������� �������
        /// </summary>
        public abstract void CheckSwitchState();

        /// <summary>
        /// ������ ��������� ��������� �� �����
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