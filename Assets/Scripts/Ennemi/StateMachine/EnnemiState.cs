using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnnemiState 
{
    public EnnemiState (Ennemi _ennemi, EnnemiStateMachine _stateMachine)
    {
        _ennemi = ennemi;
        _stateMachine = stateMachine;
    }

    protected Ennemi ennemi;
    protected EnnemiStateMachine stateMachine;

    public virtual void EnterState() {}
    public virtual void ExitState() {}
    public virtual void FrameUpdate() {}
    public virtual void PhysicsUpdate() {}
}
