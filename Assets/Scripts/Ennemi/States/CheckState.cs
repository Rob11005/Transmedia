using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckState : EnnemiState
{
    public CheckState(Ennemi _ennemi, EnnemiStateMachine _stateMachine) : base(_ennemi, _stateMachine)
    {
        
    }

    protected Ennemi ennemi;
    protected EnnemiStateMachine stateMachine;

    public virtual void EnterState() 
    {
        base.EnterState();
    }
    public virtual void ExitState() 
    {
        base.ExitState();
    }
    public virtual void FrameUpdate() 
    {
        base.FrameUpdate();
        //X Temps de tournage de caméra pour regarder autour de lui puis --> ChangeState(Patrouille) 
    }
    public virtual void PhysicsUpdate() 
    {
        base.PhysicsUpdate();
    }
}
