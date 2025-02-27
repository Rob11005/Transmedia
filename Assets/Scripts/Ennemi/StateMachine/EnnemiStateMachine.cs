using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnnemiStateMachine
{
    public EnnemiState _CurrentState {get; set;}

    public void Initialize(EnnemiState startingState)
    {
        _CurrentState = startingState;
        _CurrentState.EnterState();
    }
    public void ChangeState(EnnemiState newState)
    {
        _CurrentState.ExitState();
        _CurrentState = newState;
        _CurrentState.EnterState();
    }

}
