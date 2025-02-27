using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandIdleState : StandState
{
    public StandIdleState(Player player, PlayerStateMachine playerStateMachine) : base(player, playerStateMachine)
    {

    }

    public override void EnterState() 
    {
        base.EnterState();
        Debug.Log("Entering Idle State");
    }

    public override void ExitState() 
    {
        base.ExitState();
        Debug.Log("Exiting Idle State");
    }

    public override void FrameUpdate() 
    {
        base.FrameUpdate();
        //Debug.Log("Ici");
        //Debug.Log(player.move.action.ReadValue<Vector2>());
        if(player.move.action.ReadValue<Vector2>() != Vector2.zero)
        {
            Debug.Log("I change state");
            playerStateMachine.ChangeState(player.standWalkState);
        }
    }

    public override void PhysicsUpdate() 
    {
        base.PhysicsUpdate();
    }

    public override void AnimationTriggerEvent(Player.AnimationTriggerType triggerType) 
    {
        base.AnimationTriggerEvent(triggerType);
    }

    public override void DoCheck() 
    {
        base.DoCheck();
    }
}
