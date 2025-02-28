using System.Collections;
using System.Collections.Generic;
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
        public ScanState scanState{get; set;}
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

    public Rigidbody rb;
    public Volume volume;
    public LayerMask scanLayer;
    Color scanColor;
    

    #endregion

    #region Action references

    public InputActionReference chip;
    public InputActionReference move;
    public InputActionReference jump;

    public InputActionReference sprint;

    #endregion 

    #region other variables
        public PlayerValue playerValue; 
        public Vector3 moveDirection;

        [SerializeField]
        public bool IsGrounded;
        public bool inChip = false;
        public bool isScanning = false;
        public float jumpForwardForce;
        
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
        playerState = new PlayerState(this,StateMachine );
    }

    private void Start()
    {
        StateMachine.Initialize(standIdleState);
    }

    private void Update()
    {
        StateMachine.currentPlayerState.FrameUpdate();
        //Debug.Log(move.action.ReadValue<Vector2>());
    }

    private void FixedUpdate()
    {
        StateMachine.currentPlayerState.PhysicsUpdate();
    }

    public void StartScanning()
    {
        StartCoroutine(Scanning());
    }

    IEnumerator Scanning()
    {
        Collider[] scanCollider = Physics.OverlapSphere(transform.position, 50, scanLayer);

        foreach(Collider scanableObjects in scanCollider)
        {
            scanColor = scanableObjects.gameObject.GetComponent<MeshRenderer>().material.color;
            scanableObjects.gameObject.GetComponent<MeshRenderer>().material.color = Color.red;

            yield return new WaitForSeconds(5);

            scanableObjects.gameObject.GetComponent<MeshRenderer>().material.color = scanColor;
        }
        isScanning = false;
    }
}
