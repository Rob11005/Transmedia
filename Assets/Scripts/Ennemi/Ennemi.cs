using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Ennemi : MonoBehaviour
{
   public EnnemiStateMachine stateMachine;
   public PatrouilleState patrouilleState;
   public ChasingState chasingState;
   public InvestigateState investigateState;
   public CheckState checkState;

   public Rigidbody rb;

   private void Awake()
   {
        stateMachine = new EnnemiStateMachine();
        patrouilleState = new PatrouilleState(this, stateMachine);
        chasingState = new ChasingState(this, stateMachine);
        investigateState = new InvestigateState(this, stateMachine);
        checkState = new CheckState(this, stateMachine);
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
