using CoreLibrary.StateMachine;
using UnityEngine;

namespace Assets.Scripts.Character.Bloon.States
{
    public class DropState : CharacterState<BloonStateFactory>
    {
        private readonly GameObject deflateModel;
        private readonly GameObject normalModel;
        private readonly BloonReseter bloonReseter;


        public DropState(GameObject model, IStateContext<BloonStateFactory> handler, BloonStateFactory factory) : base(model, handler, factory)
        {
            deflateModel = model.transform.Find("DeflateModel").gameObject;
            normalModel = model.transform.Find("Model").gameObject;

            bloonReseter = model.GetComponent<BloonReseter>();
        }

        public override void CheckSwitchState()
        {
        }

        public override void EnterState()
        {
            normalModel.SetActive(false);
            deflateModel.SetActive(true);

            bloonReseter.Trigger += ResetSwitch;
        }

        public override void ExitState()
        {
            bloonReseter.Trigger -= ResetSwitch;
        }

        public override void HandleState()
        {
        }

        private void ResetSwitch() => SwitchState(Factory.Deflate);
    }
}
