namespace CoreLibrary.StateMachine
{
    public interface IStateContext<TFactory>
    {
        CharacterState<TFactory> CurrentState { get; set; }
    }
}
