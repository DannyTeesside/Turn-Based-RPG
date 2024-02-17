using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCutsceneState : PlayerBaseState
{

    public PlayerCutsceneState(PlayerStateMachine stateMachine) : base(stateMachine)
    {
    }

    public override void Enter()
    {
        stateMachine.Animator.Play("Idle");
    }

    public override void Tick(float deltaTime)
    {
        
    }

    public override void Exit()
    {
        
    }
}
