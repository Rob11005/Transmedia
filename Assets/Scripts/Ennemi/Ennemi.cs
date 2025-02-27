using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Ennemi : MonoBehaviour
{
   public EnnemiStateMachine stateMachine;
   public Patrouille patrouilleState;
   public Chasing chasingState;
   public Investigate investigateState;
   public Check checkState;

   public Rigidbody rb;

   private void Awake()
   {
        stateMachine = new EnnemiStateMachine();
        patrouilleState = new Patrouille(this, stateMachine);
        chasingState = new Chasing(this, stateMachine);
        investigateState = new Investigate(this, stateMachine);
        checkState = new Check(this, stateMachine);
   }

    private void Start()
    {
        stateMachine.Initialize(patrouilleState);
    }
   private void Update()
   {
        stateMachine._CurrentState.FrameUpdate();
   }

   private void FixedUpdate()
   {
    stateMachine._CurrentState.PhysicsUpdate();
   }
}
