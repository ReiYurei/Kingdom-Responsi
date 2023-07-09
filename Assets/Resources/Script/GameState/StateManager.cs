using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class StateManager : MonoBehaviour
{
    

    BaseGameState currentState;

    public ActionState ActionState = new ActionState();
    public CutsceneState CutsceneState = new CutsceneState();
    public DeathState DeathState = new DeathState();

    public delegate void OnStateChangeHandler(BaseGameState state);
    public event OnStateChangeHandler OnStateChange;
    
    void Start()
    {

        var player = GameObject.FindWithTag("Player").GetComponent<PlayerController>();
        player.OnDeath += OnDeathState;
        SetState(ActionState);
        currentState.OnEnterState(this);

    }

    void Update()
    {
        currentState.OnUpdateState(this);

    }
    public void OnChangeState()
    {
        OnStateChange?.Invoke(currentState);
    }

    public void SetState(BaseGameState state)
    {
        currentState = state;
        currentState.OnEnterState(this);
    }


    public void OnDeathState(object sender, EventArgs e)
    {
        SetState(DeathState);
    }
}
