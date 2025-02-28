using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScanState : ChipState	
{
    public ScanState(Player player, PlayerStateMachine playerStateMachine) : base(player, playerStateMachine)
    {

    }

    public override void EnterState()
    {
        base.EnterState();
        Debug.Log("Entering ScanState");
    }

    public override void ExitState()
    {
        base.ExitState();
        Debug.Log("Exit ScanState");
    }
    public override void FrameUpdate()
    {
        base.FrameUpdate();

        if(player.isScanning)
        player.StartScanning();

        if(!player.isScanning)
        {
            playerStateMachine.ChangeState(player.chipState);
        }
        
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
