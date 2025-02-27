using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsJumpingState : StandState
{
    public IsJumpingState(Player player, PlayerStateMachine playerStateMachine) : base(player, playerStateMachine)
    {

    }

    public override void EnterState() 
    {
        base.EnterState();
        Debug.Log("Entering IsJumping State");
        player.rb.AddForce(Vector3.up * player.playerValue.JumpHeight, ForceMode.Impulse);  
    }

    public override void ExitState() 
    {
        base.ExitState();
        Debug.Log("Exiting IsJumping State");
    }

    public override void FrameUpdate() 
    {
        base.FrameUpdate();
        if(player.IsGrounded == true)
        {
            playerStateMachine.ChangeState(player.standIdleState);
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
