using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBattleState : PlayerBaseState
{
    public PlayerBattleState(PlayerStateMachine stateMachine) : base(stateMachine)
    {
    }

    

    

    public override void Enter()
    {
        stateMachine.Animator.Play("Idle");
        Debug.Log("Player Entered Battle");
    }

    public override void Tick(float deltaTime)
    {
        

    }

    public override void Exit()
    {

    }
}
