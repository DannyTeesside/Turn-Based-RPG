using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class HandleTurn
{
    public string actionCharacterName; //name of character who performed action

    public GameObject actionCharacterObject; //character who performed action

    public GameObject actionTargetObject;
}
