using Assets.Scripts.Character.Bloon.States;
using CoreLibrary.StateMachine;
using UnityEngine;

public class BloonController : MonoBehaviour, IStateContext<BloonStateFactory>
{
    public CharacterState<BloonStateFactory> CurrentState { get; set; }

    private void Start()
    {
        var stateFactory = new BloonStateFactory(gameObject, this);
        CurrentState = stateFactory.Deflate;
        CurrentState.EnterState();
    }

    private void FixedUpdate()
    {
        CurrentState.CheckSwitchState();
        CurrentState.HandleState();
    }
}
