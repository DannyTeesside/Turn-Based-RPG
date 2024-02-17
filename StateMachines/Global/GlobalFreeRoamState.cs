using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalFreeRoamState : GlobalBaseState
{
    public GlobalFreeRoamState(GlobalStateMachine stateMachine) : base(stateMachine)
    {
    }

    public override void Enter()
    {
        Debug.Log("Free roam Entered");

    }

    public override void Exit()
    {
        Debug.Log("Free roam exited");
    }

    public override void Tick(float deltaTime)
    {
        
    }
}
