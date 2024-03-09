using CoreLibrary.StateMachine;
using UnityEngine;

namespace Assets.Scripts.Character.Bloon.States
{
    public class BloonStateFactory
    {
        public DeflateState Deflate { get; set; }
        public HoldState Hold { get; set; }
        public FloatState Float { get; set; }
        public DropState Drop { get; set; }
        public FallState Fall { get; set; }

        public BloonStateFactory(GameObject model, IStateContext<BloonStateFactory> context) 
        {
            Deflate = new DeflateState(model, context, this);
            Fall = new FallState(model, context, this);
            Drop = new DropState(model, context, this);
            Hold = new HoldState(model, context, this);
            Float = new FloatState(model, context, this);
        }
    }
}
