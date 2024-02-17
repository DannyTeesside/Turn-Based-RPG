using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateMachine : StateMachine
{

    [field: SerializeField] public InputReader InputReader { get; private set; }
    [field: SerializeField] public CharacterController Controller { get; private set; }

    [field: SerializeField] public Animator Animator { get; private set; }

    [field: SerializeField] public float RoamMovementSpeed { get; private set; }

    GameObject globalStateMachine;

    Collider interactableObject = null;



    // Start is called before the first frame update
    void Awake()
    {
        globalStateMachine = GameObject.FindGameObjectWithTag("GlobalStateMachine");
        GlobalStateMachine globalStateMachineScript = globalStateMachine.GetComponent<GlobalStateMachine>();
        globalStateMachineScript.StartFreeRoam += EnterFreeRoamState;
        globalStateMachineScript.StartBattle += EnterBattleState;
        globalStateMachineScript.StartCutscene += EnterCutsceneState;
        //SwitchState(new PlayerTestState(this));
    }

    public void EnterFreeRoamState()
    {
        SwitchState(new PlayerTestState(this));
    }

    public void EnterCutsceneState()
    {
        SwitchState(new PlayerCutsceneState(this));
    }

    public void EnterBattleState()
    {
        SwitchState(new PlayerBattleState(this));
    }

    private void OnTriggerStay(Collider other)
    {
        if ((other.tag == "Interactable") && (interactableObject != other))
        {
            StoreInteractableObject(other);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        interactableObject = null;
    }

    void StoreInteractableObject(Collider interactable)
    {
        interactableObject = interactable;
    }

    public void ClearInteractableObject()
    {
        interactableObject = null;
    }


    public Collider GetInteractableObject()
    {
        return interactableObject;
    }
}
