using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HackingState : ChipState
{
    public HackingState(Player player, PlayerStateMachine playerStateMachine) : base(player, playerStateMachine)
    {

    }

    public override void EnterState()
    {
        base.EnterState();
        Debug.Log("Enter HackingState");
    }

    public override void ExitState()
    {
        base.ExitState();
        Debug.Log("Exit HackingState");
    }

    public override void FrameUpdate()
    {
        base.FrameUpdate();
        if(player.selectHacking.hackedObject != null)
        {
            if(player.selectHacking.hackedObject.name == "Door" && !player.isHacking)
            {
                player.isHacking = true;
                playerStateMachine.ChangeState(player.doorHackingState);          
            }
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
