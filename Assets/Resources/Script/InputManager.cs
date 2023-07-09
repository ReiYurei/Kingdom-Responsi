using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    public static InputManager Instance { get; private set; }
    public InputActionAsset Actions;


    StateManager StateManager;
    private void Awake()
    {

        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(this);
        }

        Actions = Resources.Load<InputActionAsset>("Controller/InputSystemAsset");
    }
    private void OnEnable()
    {
        StateManager = GameObject.FindWithTag("StateManager").GetComponent<StateManager>();
        StateManager.OnStateChange += OnChangeStateHandler;
        StateManager.SetState(StateManager.ActionState);

    }
    private void OnDisable()
    {
        StateManager.SetState(StateManager.CutsceneState);
    }

    void OnChangeStateHandler(BaseGameState state)
    {
        switch (state)
        {
            case ActionState:
                Actions.FindActionMap("Action").Enable();
                break;
            case CutsceneState:
                Actions.FindActionMap("Action").Disable();
                break;
            case DeathState:
                Actions.FindActionMap("Action").Disable();
                break;
            
        }
    }
}
