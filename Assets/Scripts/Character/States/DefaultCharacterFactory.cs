using CoreLibrary.StateMachine;
using UnityEngine;

namespace Assets.Scripts.Character.States
{
    public class DefaultCharacterFactory
    {
        public JumpState Jump { get; set; }

        public StandState Stand { get; set; }

        public DefaultCharacterFactory(GameObject model, IStateContext<DefaultCharacterFactory> target) 
        { 
            Jump = new JumpState(model, target, this);
            Stand = new StandState(model, target, this);
        }
    }
}