using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionState : BaseGameState
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
