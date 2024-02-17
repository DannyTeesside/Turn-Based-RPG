using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG.Shops
{
    public class Shopper : MonoBehaviour
    {

        Shop activeshop = null;
        GlobalStateMachine stateMachineScript;

        public event Action activeShopChange;

        private void Start()
        {
            stateMachineScript = GameObject.Find("StateMachine").GetComponent<GlobalStateMachine>();
        }

        public void SetActiveShop(Shop shop)
        {
            if (activeshop != null)
            {
                activeshop.SetShopper(null);
            }
            activeshop = shop;
            if (activeshop != null)
            {
                activeshop.SetShopper(this);
            }
            if (activeShopChange != null)
            {
                activeShopChange();
                stateMachineScript.EnterCutscene();
            }
            if (activeshop == null)
            {
                stateMachineScript.EnterFreeRoamState();
            }
        }

        public Shop GetActiveShop()
        {
            return activeshop;
        }
    }
}
