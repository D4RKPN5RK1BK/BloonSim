using CoreLibrary.StateMachine;
using System;
using UnityEngine;

namespace Assets.Scripts.Character.Bloon.States
{
    public class HoldState : CharacterState<BloonStateFactory>
    {
        public HoldState(GameObject model, IStateContext<BloonStateFactory> handler, BloonStateFactory factory) : base(model, handler, factory)
        {
        }

        public override void CheckSwitchState()
        {
        }

        public override void EnterState()
        {
        }

        public override void ExitState()
        {
        }

        public override void HandleState()
        {
        }
    }
}
