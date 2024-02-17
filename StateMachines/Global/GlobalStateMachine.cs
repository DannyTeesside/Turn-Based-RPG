using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GlobalStateMachine : StateMachine
{

    [field: SerializeField] public AudioSource AudioSource { get; private set; }
    [field: SerializeField] public BattleManager BattleManager { get; private set; }


    public event Action StartFreeRoam;
    public event Action StartBattle;
    public event Action StartCutscene;


    // Start is called before the first frame update
    void Start()
    {
        EnterFreeRoamState();
    }

    public void EnterBattleState()
    {
        SwitchState(new GlobalBattleState(this));
        StartBattle?.Invoke();
    }

    public void EnterFreeRoamState()
    {
        SwitchState(new GlobalFreeRoamState(this));
        StartFreeRoam?.Invoke();
    }
    
    public void EnterCutscene()
    {
        StartCutscene?.Invoke();
    }
}
