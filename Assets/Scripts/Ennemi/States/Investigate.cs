using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Investigate : EnnemiState
{
    public Investigate(Ennemi _ennemi, EnnemiStateMachine _stateMachine) : base(_ennemi, _stateMachine)
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
        //Si ne trouve pas au bout de X temps --> ChangeState(Patrouille)
        //Si trouve --> ChangeState(Chasing)
        //Si sur CheckPoint ou tous les X temps (à toi de voir comment tu veux gérer ça) --> ChangeState(Check)
    }
    public virtual void PhysicsUpdate() 
    {
        base.PhysicsUpdate();
    }
}
