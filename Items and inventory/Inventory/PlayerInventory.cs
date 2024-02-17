using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{

    public InventoryObject inventory;

    //Save Function

    //Load Function

    private void OnApplicationQuit()
    {
        inventory.Container.Clear();
    }
}
