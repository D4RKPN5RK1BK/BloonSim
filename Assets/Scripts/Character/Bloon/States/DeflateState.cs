using CoreLibrary.StateMachine;
using UnityEngine;

namespace Assets.Scripts.Character.Bloon.States
{
    public class DeflateState : CharacterState<BloonStateFactory>
    {
        private GameObject deflateModel;
        private GameObject normalModel;

        private float duration = 4.0f;
        private readonly Rigidbody rigitbody;
        private float endOfState;

        private float force;

        public DeflateState(GameObject model, IStateContext<BloonStateFactory> handler, BloonStateFactory factory) : base(model, handler, factory)
        {
            rigitbody = model.GetComponent<Rigidbody>();

            deflateModel = model.transform.Find("DeflateModel").gameObject;
            normalModel = model.transform.Find("Model").gameObject;
        }

        public override void CheckSwitchState()
        {
            if (Time.time > endOfState)
            {
                SwitchState(Factory.Drop);
            }
        }

        public override void EnterState()
        {
            normalModel.SetActive(true);
            deflateModel.SetActive(false);

            normalModel.transform.localScale = Vector3.one;

            endOfState = Time.time + duration;
            force = 0.2f;
        }

        public override void ExitState()
        {
            
        }

        public override void HandleState()
        {
            var k = 1 -  ((endOfState - Time.time) / duration);
            var scaleK = 0.4f + (1 - k) * 0.6f;

            normalModel.transform.localScale = Vector3.one * scaleK;

            force = 0.2f + (k / 3);
            var random = new Vector3(Random.Range(-0.2f, 0.2f), Random.Range(-0.2f, 0.2f), Random.Range(-0.2f, 0.2f));
            rigitbody.AddForce((Model.transform.up + random) * force);
        }
    }
}
