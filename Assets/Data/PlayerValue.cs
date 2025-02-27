using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/PlayerValue", order = 1)]
public class PlayerValue : ScriptableObject
{
    public float playerSpeed = 5;
    public float walkRatio = 1;
    public float crouchRatio = 0.5f;
    public float sprintRatio = 2;
    public float JumpHeight = 3;

    public float JumpSprintForce = 4;

    public float JumpWalkForce = 2;
}
