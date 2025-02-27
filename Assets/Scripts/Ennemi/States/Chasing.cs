using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chasing : EnnemiState
{
    public Chasing(Ennemi _ennemi, EnnemiStateMachine _stateMachine) : base(_ennemi, _stateMachine)
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
        //Si ne voit plus le joueur --> ChangeState(Investigate)
    }
    public virtual void PhysicsUpdate() 
    {
        base.PhysicsUpdate();
    }
}
