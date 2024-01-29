using CoreLibrary.Character;
using CoreLibrary.StateMachine;
using UnityEngine;

namespace Assets.Scripts.Character.States
{
    public class StandState : CharacterState<DefaultCharacterFactory>
    {
        private readonly WalkHandler _walkHandler;
        private readonly CharacterController _characterController;
        private readonly Transform _character;

        public StandState(GameObject model, IStateContext<DefaultCharacterFactory> handler, DefaultCharacterFactory factory) : base(model, handler, factory)
        {
            _characterController = model.GetComponent<CharacterController>();
            _walkHandler = model.GetComponent<WalkHandler>();
            _character = model.transform.Find("Character");
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
            var offset = _walkHandler.WalkDirection;
            var motion = offset.x * _character.right + offset.y * _character.forward;
            motion += new Vector3(0, -10, 0);
            _characterController.Move(Time.deltaTime * 10 * motion);
            //_rotateHandler.U
        }

        private void SwitchToJump() => SwitchState(Factory.Jump);
    }
}