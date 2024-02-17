using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTestState : PlayerBaseState
{
    public PlayerTestState(PlayerStateMachine stateMachine) : base(stateMachine)
    {
    }

    public override void Enter()
    {
        stateMachine.InputReader.InteractEvent += Interact;
    }

    public override void Tick(float deltaTime)
    {
        Vector3 movement = new Vector3();
        movement.x = stateMachine.InputReader.MovementValue.x;
        movement.y = 0;
        movement.z = stateMachine.InputReader.MovementValue.y;
        stateMachine.Controller.Move(movement * stateMachine.RoamMovementSpeed * deltaTime);

        if (stateMachine.InputReader.MovementValue == Vector2.zero)
        {
            stateMachine.Animator.Play("Idle");
            return;
        }

        stateMachine.Animator.Play("Walking");

        if (movement.x == 0) { return; }

        stateMachine.transform.rotation = Quaternion.LookRotation(new Vector3(movement.x,0,0));
    }

    public override void Exit()
    {
        stateMachine.InputReader.InteractEvent -= Interact;
    }

    void Interact()
    {
        if (stateMachine.GetInteractableObject() != null && stateMachine.GetInteractableObject().TryGetComponent(out IInteractable interactedObject))
        {
            interactedObject.Interact();
            stateMachine.ClearInteractableObject();
        }
    }

    

}
