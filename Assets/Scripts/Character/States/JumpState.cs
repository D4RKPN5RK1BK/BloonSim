using CoreLibrary.StateMachine;
using UnityEngine;

namespace Assets.Scripts.Character.States
{
    public class JumpState : CharacterState<DefaultCharacterFactory>
    {
        public JumpState(GameObject model, IStateContext<DefaultCharacterFactory> handler, DefaultCharacterFactory factory) : base(model, handler, factory)
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

        private void SwitchToStand() => SwitchState(Factory.Stand);
    }
}