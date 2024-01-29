using CoreLibrary.StateMachine;
using System;
using UnityEngine;

namespace Assets.Scripts.Character.Bloon.States
{
    public class FloatState : CharacterState<BloonStateFactory>
    {
        public FloatState(GameObject model, IStateContext<BloonStateFactory> handler, BloonStateFactory factory) : base(model, handler, factory)
        {
        }

        public override void CheckSwitchState()
        {
            throw new NotImplementedException();
        }

        public override void EnterState()
        {
            throw new NotImplementedException();
        }

        public override void ExitState()
        {
            throw new NotImplementedException();
        }

        public override void HandleState()
        {
            throw new NotImplementedException();
        }
    }
}
