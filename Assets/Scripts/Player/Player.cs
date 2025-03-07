using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using Cinemachine.PostFX;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;

public class Player : MonoBehaviour
{
    #region State Machine Variables
        public PlayerStateMachine StateMachine { get; set; }
        public StandWalkState standWalkState { get; set; }
        public StandIdleState standIdleState{ get; set; }
        public PlayerState playerState{ get; set; }
        public SprintState sprintState { get; set; }
        public StandState standState{ get; set; }
        public IsJumpingState isJumpingState{ get; set; }
        public ChipState chipState{ get; set;}
        public HackingState hackingState{get; set;}
        public DoorHackingState doorHackingState {get; set;}

    #endregion

    #region Animation Triggers

    private void AnimationTriggerEvent(AnimationTriggerType triggerType)
    {

    }

    public enum AnimationTriggerType
    {
        PlayFootStepSound
    }

    #endregion

    #region Components

    public GameObject cursorCanva;
    public Rigidbody rb;
    public LayerMask scanLayer;
    public CinemachineVolumeSettings cinemachineVolume;
    public SelectHackingObject selectHacking;
    

    #endregion

    #region Action references

    public InputActionReference chip;
    public InputActionReference scan;
    public InputActionReference move;
    public InputActionReference jump;
    public InputActionReference sprint;
    public InputActionReference interact;

    #endregion 

    #region other variables
        public PlayerValue playerValue; 
        public Vector3 moveDirection;

        [SerializeField]
        public bool IsGrounded;
        public bool inChip = false;
        public bool canHack = false;
        public bool isHacking = false;
        public bool gameFinished = false;
        public float jumpForwardForce;
        public GameObject ScannableObjects;
        public Vector3 jumpDirection = Vector3.zero;
    #endregion


    private void Awake()
    {      
        StateMachine = new PlayerStateMachine();   
        standWalkState = new StandWalkState(this, StateMachine);
        standIdleState = new StandIdleState(this, StateMachine);
        isJumpingState = new IsJumpingState(this, StateMachine);
        sprintState = new SprintState(this, StateMachine);
        standState = new StandState(this, StateMachine);
        chipState = new ChipState(this, StateMachine);
        hackingState= new HackingState(this, StateMachine);
        playerState = new PlayerState(this,StateMachine );
        doorHackingState = new DoorHackingState(this, StateMachine);
    }

    private void Start()
    {
        StateMachine.Initialize(standIdleState);
        selectHacking = gameObject.GetComponent<SelectHackingObject>();
    }

    private void Update()
    {
        StateMachine.currentPlayerState.FrameUpdate();
        //Debug.Log(move.action.ReadValue<Vector2>());
        if(canHack == true)
        {
            cursorCanva.transform.GetChild(1).gameObject.SetActive(true);
        }
        else
        {
            cursorCanva.transform.GetChild(1).gameObject.SetActive(false);
        }
    }

    private void FixedUpdate()
    {
        StateMachine.currentPlayerState.PhysicsUpdate();
    }
}
