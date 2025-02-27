using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class FeetDetection : MonoBehaviour
{

    public Player player;
    public IsJumpingState isJumpingState;

    void Start()
    {
        isJumpingState = player.isJumpingState;   
    }

    void OnCollisionEnter(Collision other)
    {
        //Debug.Log("Enter Collision");
        if (other.gameObject.tag == "Ground")
        {
            player.IsGrounded = true;
            isJumpingState.DoCheck();
            Debug.Log(player.IsGrounded);
        }
    }
    
    void OnCollisionExit(Collision other)
    {
        //Debug.Log("Exit Collision");
        if(other.gameObject.tag == "Ground")
        {
            player.IsGrounded = false;
            Debug.Log(player.IsGrounded);
        }
    }
}
