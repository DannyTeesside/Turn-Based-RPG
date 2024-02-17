using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroBattleStateMachine : MonoBehaviour
{

    BattleManager battleManager;

    

    public CharacterStats characterStats;

    

    [SerializeField] TurnState currentState;

    Vector3 startPosition;

    enum TurnState
    {
        Processing,
        AddToList,
        Waiting,
        //ChooseAction,
        //Selecting,
        Action,
        //Win,
        Dead
    }

    


    private void OnEnable()
    {
        
        currentState = TurnState.Processing;
        startPosition = transform.position;
        
        
        battleManager = GameObject.FindGameObjectWithTag("GlobalStateMachine").GetComponent<BattleManager>();
    }


    // Update is called once per frame
    void Update()
    {
        switch (currentState)
        {
            case (TurnState.Processing):
               
                currentState = TurnState.AddToList;
                break;

            case (TurnState.AddToList):
                //battleManager.heroesToManage.Add(this.gameObject);
                currentState = TurnState.Waiting;
                break;

            case (TurnState.Waiting):

                break;

            //case (TurnState.ChooseAction):
                
            //    break;

            //case (TurnState.Selecting):

            //    break;

            case (TurnState.Action):

                break;

            

            //case (TurnState.Win):

            //    break;

            case (TurnState.Dead):

                break;
        }
    }

    
}
