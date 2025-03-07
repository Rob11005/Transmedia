using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.ProBuilder.Shapes;

public class DoorHackingState : HackingState
{
    DoorHacking door;
    PlayerCamera playerCamera;
    PlayerCamera camera;
    public DoorHackingState(Player player, PlayerStateMachine playerStateMachine) : base(player, playerStateMachine)
    {
        
    }

    public override void EnterState()
    {
        base.EnterState();
        Debug.Log("LA PORTE");
        door = player.selectHacking.hackedObject.GetComponent<DoorHacking>();
        playerCamera = player.transform.GetChild(0).GetComponent<PlayerCamera>();
        camera = player.transform.GetChild(1).GetComponent<PlayerCamera>();
        player.rb.rotation = Quaternion.Euler(0,0,0);
        door.MiniGame();
    }

    public override void ExitState()
    {
        base.ExitState();
        Debug.Log("LA PORTE PAS");
        playerCamera.enabled = true;
        camera.enabled = true;
        door.miniGameCanva.gameObject.SetActive(false);
        player.isHacking = false;
        player.inChip = false;
    }

    public override void FrameUpdate()
    {
        base.FrameUpdate();

        if(player.gameFinished)
        {
            playerStateMachine.ChangeState(player.standIdleState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
