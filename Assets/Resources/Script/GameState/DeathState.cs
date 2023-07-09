public class DeathState : BaseGameState
{
    public override void OnEnterState(StateManager state)
    {
        state.OnChangeState();
    }

    public override void OnExitState(StateManager state)
    {
    }

    public override void OnUpdateState(StateManager state)
    {
    }
}