using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class IsJumpingState : StandState
{
    Vector3 direction;

    public IsJumpingState(Player player, PlayerStateMachine playerStateMachine) : base(player, playerStateMachine)
    {

    }

    public override void EnterState() 
    {
        base.EnterState();
        Debug.Log("Entering IsJumping State");
        player.rb.AddForce(player.jumpDirection, ForceMode.Impulse);  
    }

    public override void ExitState() 
    {
        base.ExitState();
        Debug.Log("Exiting IsJumping State");
        player.rb.velocity = Vector3.zero;
    }

    public override void FrameUpdate() 
    {
        base.FrameUpdate();
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
        if(player.IsGrounded == true && playerStateMachine.currentPlayerState == this)
        {
            playerStateMachine.ChangeState(player.standIdleState);
        }
    }
}
