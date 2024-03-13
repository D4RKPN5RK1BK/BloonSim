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

        private float smoothTime = 0.2f;
        private float maxSpeed = 30f;

        private Vector3 current;
        private Vector3 currentVelocity;

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
            var target = _character.transform.TransformDirection(new Vector3(offset.x, 0, offset.y));

            // это еще интереснее
            current = Vector3.SmoothDamp(current, target * _walkHandler.walkModel.maxForce, ref currentVelocity, 0.1f);

            _characterController.Move(Time.deltaTime * current);
        }

        private void SwitchToJump() => SwitchState(Factory.Jump);
    }
}