using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandState : PlayerState
{
    public StandState(Player player, PlayerStateMachine playerStateMachine) : base(player, playerStateMachine)
    {

    }

    public override void EnterState() 
    {
        base.EnterState();        
    }

    public override void ExitState() 
    {
        base.ExitState();
    }

    public override void FrameUpdate() 
    {
        base.FrameUpdate();
        if(player.jump.action.triggered && player.IsGrounded == true)
        {
            //Debug.Log("Jump");
            playerStateMachine.ChangeState(player.isJumpingState);
        }

        if(player.chip.action.triggered && player.inChip == false)
        {
            playerStateMachine.ChangeState(player.chipState);
            player.inChip = true;
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
