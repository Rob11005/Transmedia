using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class ChipState : PlayerState
{
    public ChipState(Player player, PlayerStateMachine playerStateMachine) : base(player, playerStateMachine)
    {
        
    }
    
    public override void EnterState() 
    {
        base.EnterState();
        Debug.Log("ChipState Enter");
        player.volume.profile = ScriptableObject.CreateInstance<VolumeProfile>();
        
        if(!player.volume.profile.TryGet(out ColorAdjustments colorAdjustments))
        {
            colorAdjustments = player.volume.profile.Add<ColorAdjustments>(true);
        }

        colorAdjustments.colorFilter.overrideState = true;
        colorAdjustments.colorFilter.value = Color.blue;
        colorAdjustments.contrast.value = 60;
    }

    public override void ExitState() 
    {
        base.ExitState();
        if(player.volume.profile.TryGet(out ColorAdjustments colorAdjustments))
        {
            colorAdjustments.colorFilter.overrideState = false;
        }
        
        Debug.Log("ChipState Exit");
    }

    public override void FrameUpdate()
    {
        base.FrameUpdate();

        if(player.chip.action.triggered && player.inChip)
        {
            playerStateMachine.ChangeState(player.standIdleState);
            player.inChip = false;
        }

        if(player.jump.action.triggered)
        {
            playerStateMachine.ChangeState(player.scanState);
            player.isScanning = true;
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }

    public override void DoCheck() 
    {
        base.DoCheck();
    }
}
