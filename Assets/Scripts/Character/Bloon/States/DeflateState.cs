using CoreLibrary.StateMachine;
using UnityEngine;

namespace Assets.Scripts.Character.Bloon.States
{
    public class DeflateState : CharacterState<BloonStateFactory>
    {
        private Rigidbody rigitbody;

        public DeflateState(GameObject model, IStateContext<BloonStateFactory> handler, BloonStateFactory factory) : base(model, handler, factory)
        {
            rigitbody = model.GetComponent<Rigidbody>();
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
            var random = new Vector3(Random.Range(-0.2f, 0.2f), Random.Range(-0.2f, 0.2f), Random.Range(-0.2f, 0.2f));
            rigitbody.AddForce((Model.transform.up + random) / 2);
        }
    }
}
