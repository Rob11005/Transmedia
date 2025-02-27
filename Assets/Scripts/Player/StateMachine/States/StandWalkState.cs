using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class StandWalkState : StandState
{
    Vector3 direction;

    public StandWalkState(Player player, PlayerStateMachine playerStateMachine) : base(player, playerStateMachine)
    {

    }

    public override void EnterState() 
    {
        base.EnterState();
        Debug.Log("Entering Walk State");
    }

    public override void ExitState() 
    {
        base.ExitState();
        Debug.Log("Exiting Walk State");
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
            //Debug.Log(player.sprint.action);
            //Debug.Log("SprintButtonPressed");
            playerStateMachine.ChangeState(player.sprintState);
        }       
        else if(player.move.action.ReadValue<Vector2>() == Vector2.zero)
        {
            playerStateMachine.ChangeState(player.standIdleState);
        }
        else
        {
            player.moveDirection = player.move.action.ReadValue<Vector2>();
            direction = new Vector3(player.moveDirection.x,0, player.moveDirection.y);
            direction = player.transform.TransformDirection(direction);
            player.rb.MovePosition(player.transform.position + direction * player.playerValue.walkRatio * player.playerValue.playerSpeed * Time.fixedDeltaTime);
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
