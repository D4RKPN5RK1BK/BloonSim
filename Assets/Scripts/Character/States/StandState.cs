using CoreLibrary.Character;
using CoreLibrary.StateMachine;
using UnityEngine;

namespace Assets.Scripts.Character.States
{
    public class StandState : CharacterState<DefaultCharacterFactory>
    {
        private readonly WalkHandler _walkHandler;
        private readonly JumpHandler _jumpHandler;
        private readonly CharacterController _characterController;
        private readonly Transform _character;

        public StandState(GameObject model, IStateContext<DefaultCharacterFactory> handler, DefaultCharacterFactory factory) : base(model, handler, factory)
        {
            _characterController = model.GetComponent<CharacterController>();
            _walkHandler = model.GetComponent<WalkHandler>();
            _jumpHandler = model.GetComponent<JumpHandler>();
            _character = model.transform.Find("Character");
        }

        public override void CheckSwitchState()
        {

        }

        public override void EnterState()
        {
            _jumpHandler.Trigger += SwitchToJump;
        }

        public override void ExitState()
        {
            _jumpHandler.Trigger -= SwitchToJump;
        }

        public override void HandleState()
        {
            var offset = _walkHandler.WalkDirection;

            // это интересно
            var target = _character.transform.TransformDirection(new Vector3(offset.x, -5, offset.y));

            // это еще интереснее
            _walkHandler.CurrentDirection = Vector3.SmoothDamp(_walkHandler.CurrentDirection, target * _walkHandler.walkModel.force, ref _walkHandler.walkModel.velocity, _walkHandler.walkModel.smoothTime);

            _characterController.Move(Time.deltaTime * _walkHandler.CurrentDirection);
        }

        private void SwitchToJump() => SwitchState(Factory.Jump);
    }
}