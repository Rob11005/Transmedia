using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SprintState : StandState
{
    Vector3 direction;
    public SprintState(Player player, PlayerStateMachine playerStateMachine) : base(player, playerStateMachine)
    {

    }

    public override void EnterState() 
    {
        base.EnterState();
        Debug.Log("Entering Sprint State");        
    }

    public override void ExitState() 
    {
        base.ExitState();
        Debug.Log("Exiting Sprint State");
    }

    public override void FrameUpdate() 
    {
        base.FrameUpdate();
    }

    public override void PhysicsUpdate() 
    {
        base.PhysicsUpdate();
        if(player.sprint.action.IsPressed())
        {
            //Debug.Log("Sprinting");
            player.moveDirection = player.move.action.ReadValue<Vector2>();
            direction = new Vector3(player.moveDirection.x,0, player.moveDirection.y);
            direction = player.transform.TransformDirection(direction);
            player.rb.MovePosition(player.transform.position + direction * player.playerValue.sprintRatio * player.playerValue.playerSpeed * Time.fixedDeltaTime);
        }
        else
        {
            playerStateMachine.ChangeState(player.standWalkState);
        }
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
