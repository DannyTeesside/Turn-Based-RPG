using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalBattleState : GlobalBaseState
{

    public GlobalBattleState(GlobalStateMachine stateMachine) : base(stateMachine)
    {
    }

   

    public override void Enter()
    {
        stateMachine.BattleManager.enabled = true;
    }


    public override void Tick(float deltaTime)
    {
        
    }

    public override void Exit()
    {
        stateMachine.BattleManager.enabled = false;
    }

    
}
