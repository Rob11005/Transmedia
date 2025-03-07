using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class ChipState : PlayerState
{
    public XrayScanner xrayScannerScript;
    public ChipState(Player player, PlayerStateMachine playerStateMachine) : base(player, playerStateMachine)
    {
        
    }
    
    public override void EnterState() 
    {
        base.EnterState();
        Debug.Log("ChipState Enter");

        player.selectHacking.enabled = true;
        player.cursorCanva.SetActive(true);
        player.cursorCanva.transform.GetChild(1).gameObject.SetActive(false);

        player.cinemachineVolume.enabled = true;
        foreach(XrayScanner xrayScanner in player.ScannableObjects.transform.GetComponentsInChildren<XrayScanner>())
        {
            xrayScannerScript = xrayScanner.GetComponent<XrayScanner>();
            xrayScanner.enabled = true;
        }
    }

    public override void ExitState() 
    {
        base.ExitState();
        Debug.Log("ChipState Exit");

        if(player.selectHacking.hackedObject != null)
        {
            player.selectHacking.hackedObject.GetComponent<Outline>().enabled = false;
        }

        player.selectHacking.enabled = false;
        player.cursorCanva.SetActive(false);

        player.cinemachineVolume.enabled = false;
        foreach(XrayScanner xrayScanner in player.ScannableObjects.transform.GetComponentsInChildren<XrayScanner>())
        {
            xrayScannerScript = xrayScanner.GetComponent<XrayScanner>();
            xrayScanner.enabled = false;
            xrayScannerScript.meshRenderer.material = xrayScannerScript.baseMaterial;
            xrayScannerScript.gameObject.layer = xrayScannerScript.baseLayer;
        }
    }

    public override void FrameUpdate()
    {
        base.FrameUpdate();
        if(player.selectHacking.hackedObject != null)
        {
            if(player.selectHacking.hackedObject.GetComponent<Outline>().enabled == true)
            {
                player.canHack = true;
            }
            else 
            {
                player.canHack = false;
            }
        }
        else 
        {
            player.canHack = false;
        }

        #region ExitConditions
        if(player.chip.action.triggered && player.inChip)
        {
            playerStateMachine.ChangeState(player.standIdleState);
            player.inChip = false;
        }

        if(player.move.action.IsPressed())
        {
            playerStateMachine.ChangeState(player.standIdleState);
            player.inChip = false;
        }

        if(player.interact.action.triggered && player.canHack)
        {
            playerStateMachine.ChangeState(player.hackingState);
        }
        #endregion
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
