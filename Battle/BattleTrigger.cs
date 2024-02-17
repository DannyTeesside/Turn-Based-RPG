using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        //other.GetComponent<PlayerStateMachine>().EnterCutsceneState();

        GameObject stateMachine = GameObject.FindGameObjectWithTag("GlobalStateMachine");
        stateMachine.GetComponent<GlobalStateMachine>().EnterBattleState();
        Destroy(gameObject);
    }
}
