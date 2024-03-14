using CoreLibrary.Character;
using CoreLibrary.StateMachine;
using UnityEngine;

namespace Assets.Scripts.Character.States
{
    public class JumpState : CharacterState<DefaultCharacterFactory>
    {
        private readonly CharacterController _characterController;
        private readonly JumpHandler _jumpHandler;
        private readonly WalkHandler _walkHandler;
        private readonly GravityDataStorage _gravityData;
        private readonly Transform _character;

        private float startTime;

        private float verticalVelocity;

        public JumpState(GameObject model, IStateContext<DefaultCharacterFactory> context, DefaultCharacterFactory factory) : base(model, context, factory)
        {
            _characterController = model.GetComponent<CharacterController>();
            _jumpHandler = model.GetComponent<JumpHandler>();
            _walkHandler = model.GetComponent<WalkHandler>();
            _gravityData = model.GetComponent<GravityDataStorage>();
            _character = model.transform.Find("Character");
        }

        public override void CheckSwitchState()
        {
            if (_characterController.isGrounded && Time.time > startTime + 0.1f)
                SwitchState(Factory.Stand);
        }

        public override void EnterState()
        {
            startTime = Time.time;

            // the square root of H * -2 * G = how much velocity needed to reach desired height
            verticalVelocity = Mathf.Sqrt(_jumpHandler.jumpForce * 2f * _gravityData.gravityPressure);

            _jumpHandler.JumpRequired = false;
        }

        public override void ExitState()
        {
        }

        public override void HandleState()
        {
            var offset = _walkHandler.WalkDirection;

            // это интересно
            var target = _character.transform.TransformDirection(new Vector3(offset.x, -_gravityData.gravityPressure, offset.y));

            // это еще интереснее
            _walkHandler.CurrentDirection = Vector3.SmoothDamp(_walkHandler.CurrentDirection, target * _walkHandler.walkModel.force, ref _walkHandler.walkModel.velocity, _walkHandler.walkModel.smoothTime);

            verticalVelocity -= _gravityData.gravityPressure;

            _characterController.Move(Time.deltaTime * new Vector3(_walkHandler.CurrentDirection.x, verticalVelocity, _walkHandler.CurrentDirection.z));
        }
    }
}