using Assets.Scripts.Character.States;
using CoreLibrary.StateMachine;
using UnityEngine;

public class StateMachineCharacter : MonoBehaviour, IStateContext<DefaultCharacterFactory>
{
    public CharacterState<DefaultCharacterFactory> CurrentState { get; set; }

    protected void Start()
    {
        var stateFactory = new DefaultCharacterFactory(gameObject, this);
        CurrentState = stateFactory.Stand;
        CurrentState.EnterState();
    }

    private void Update()
    {
        CurrentState.CheckSwitchState();
        CurrentState.HandleState();
    }
}
