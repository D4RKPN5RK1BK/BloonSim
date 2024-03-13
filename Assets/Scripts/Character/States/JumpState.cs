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

        private readonly bool canBeDestroyed;
        private readonly bool canDash;
        private readonly bool canBubble;

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
            if (_characterController.isGrounded)
                SwitchState(Factory.Stand);
        }

        public override void EnterState()
        {
            Debug.Log("JumpState enter");
            // the square root of H * -2 * G = how much velocity needed to reach desired height
            var upVelocity = Mathf.Sqrt(_jumpHandler.jumpForce * 2f * _gravityData.gravityPressure);
            _gravityData.Velocity = new Vector3(_gravityData.Velocity.x, upVelocity, _gravityData.Velocity.z);

            _jumpHandler.JumpRequired = false;
        }

        public override void ExitState()
        {
        }

        public override void HandleState()
        {
            _gravityData.Velocity -= _gravityData.gravityPressure * Time.deltaTime * Vector3.up;

            var offset = _walkHandler.WalkDirection;
            var motion = offset.x * _character.right + offset.y * _character.forward;
            _gravityData.Velocity += new Vector3(0, -10, 0);
            _characterController.Move(Time.deltaTime * 10 * _gravityData.Velocity);

            //_character.CharacterController.Move(_gravityData.Velocity * Time.deltaTime);
            //_character.RotateCharacter(_gravityData.Velocity, 10);
        }

        private void SwitchToStand() => SwitchState(Factory.Stand);
    }
}