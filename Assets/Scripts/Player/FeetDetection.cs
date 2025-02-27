using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class FeetDetection : MonoBehaviour
{

    public Player player;

    void Update()
    {
        if(Physics.Raycast(transform.position,Vector3.down, 1f))
        {
            player.IsGrounded = true;
        }
        else
        {
            player.IsGrounded = false;
        }
        Debug.Log(player.IsGrounded);
    }  
}
