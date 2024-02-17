using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GlobalBaseState : State
{
    protected GlobalStateMachine stateMachine;

    public GlobalBaseState(GlobalStateMachine stateMachine)
    {
        this.stateMachine = stateMachine;
    }
}
