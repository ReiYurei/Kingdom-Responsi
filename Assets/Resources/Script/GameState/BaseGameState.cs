using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseGameState
{
    public abstract void OnEnterState(StateManager state);
    public abstract void OnUpdateState(StateManager state);
    public abstract void OnExitState(StateManager state);
}
