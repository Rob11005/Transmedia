using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrouilleState : EnnemiState
{
    public PatrouilleState(Ennemi _ennemi, EnnemiStateMachine _stateMachine) : base(_ennemi, _stateMachine)
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
        //Si enemy voit joueur --> ChangeState(Chasing)
        //S'il est sur un checkPoint --> ChangeState(Check)
    }
    public virtual void PhysicsUpdate() 
    {
        base.PhysicsUpdate();
    }
}
