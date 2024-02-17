using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG.Shops
{
    public class Shop : MonoBehaviour , IInteractable
    {

        GlobalStateMachine stateMachineScript;


        bool interactOverlap = false;
        GameObject player;

        //Stock Config

        [SerializeField] StockItemConfig[] stockConfig;

        [System.Serializable]
        class StockItemConfig
        {
            public ItemObject item;
            public int initialStock;
            [Range(0, 60)] public float discountPercentage;
        }

        Dictionary<ItemObject, int> transaction = new Dictionary<ItemObject, int>();
        Dictionary<ItemObject, int> stock = new Dictionary<ItemObject, int>();
        Shopper currentShopper;
        

        public event Action onChange;

        private void Awake()
        {
            foreach (StockItemConfig config in stockConfig)
            {
                stock[config.item] = config.initialStock;
            }
        }

        public void SetShopper(Shopper shopper)
        {
            currentShopper = shopper;
        }


        InputReader playerInput;

        private void Start()
        {
            stateMachineScript = GameObject.Find("StateMachine").GetComponent<GlobalStateMachine>();
            player = GameObject.FindGameObjectWithTag("Player");
            playerInput = player.GetComponent<InputReader>();

            //playerInput.InteractEvent += Interact;
        }


        private void Update()
        {
            //Interact();
        }

        private void OnTriggerStay(Collider other)
        {
            if (other.gameObject.tag == "Interactable")

            {
                interactOverlap = true;
            }
            else
            {
                interactOverlap = false;
            }
        }

        public void Interact()
        {
            if (interactOverlap == false)
            {
                player.GetComponent<Shopper>().SetActiveShop(this);
            }
            

        }


        public IEnumerable<ShopItem> GetFilteredItems()
        {
            return GetAllItems();
        }

        public IEnumerable<ShopItem> GetAllItems()
        {
            foreach (StockItemConfig config in stockConfig)
            {
                float price = config.item.GetItemPrice() * (1 - (config.discountPercentage / 100));
                bool soldOut = SoldOut(config.item);
                int quantityInTransaction = 0;
                transaction.TryGetValue(config.item, out quantityInTransaction);
                yield return new ShopItem(config.item, soldOut, price, quantityInTransaction);
            }
        }

        

        public void FilterItems(ItemType itemType)
        {

        }

        public ItemType GetFilter()
        {
            return ItemType.Consumable;
        }

        public void SelectMode(bool isBuying)
        {

        }

        public bool IsBuyingMode()
        {
            return true;
        }

        public bool CanBuy()
        {
            if (IsTransactionEmpty() || !HasSufficientFunds()) return false;

            else return true;
        }

        public void ConfirmTransaction()
        {
            PlayerInventory shopperInventory = currentShopper.GetComponent<PlayerInventory>();
            Wallet shopperWallet = currentShopper.GetComponent<Wallet>();
            if (shopperInventory == null || shopperWallet == null) return;

            if (shopperWallet.GetBalance() < GetTransactionTotal()) return;
            shopperWallet.UpdateBalance(-GetTransactionTotal());
            foreach (ShopItem shopItem in GetAllItems())
            {
                ItemObject item = shopItem.GetItemObject();
                int quantity = shopItem.GetQuantityInTransaction();
                float price = shopItem.GetPrice();
                
                    
                if (quantity != 0)
                {
                    shopperInventory.inventory.AddItem(item, quantity);
                    AddToTransaction(item, -quantity);
                    stock[item] -= quantity;
                    SoldOut(item);
                }

            }
            onChange();
            
        }

        public float GetTransactionTotal()
        {
            float total = 0;
            foreach (ShopItem item in GetAllItems())
            {
                total += item.GetPrice() * item.GetQuantityInTransaction();
            }
            return total;
        }

        public void AddToTransaction(ItemObject item, int quantity)
        {
            PlayerInventory shopperInventory = currentShopper.GetComponent<PlayerInventory>();
            if (!transaction.ContainsKey(item))
            {
                transaction[item] = 0;
            }

            if ((transaction[item] + quantity) > (99 - shopperInventory.inventory.GetItemAmount(item)))
            {
                transaction[item] = 99 - shopperInventory.inventory.GetItemAmount(item) - 1;
            }

            //if ((transaction[item] + quantity) > 99)
            //{
            //    transaction[item] = 99;
            //}

            if (transaction[item] + quantity > stock[item] && item.IsLimited())
            {
                transaction[item] = stock[item];
            }
            
            else
            {
                transaction[item] += quantity;
            }
            

            if (transaction[item] <= 0)
            {
                transaction.Remove(item);
            }

            if (onChange != null)
            {
                onChange();
            }
        }

        bool SoldOut(ItemObject item)
        {
            if (stock[item] <= 0 && item.IsLimited())
            {
                return true;
            }
            else
            {
                return false;
            }
            
        }

        bool IsTransactionEmpty()
        {
            return transaction.Count == 0;
        }
            
        public bool HasSufficientFunds()
        {
            Wallet wallet = currentShopper.GetComponent<Wallet>();
            if (wallet == null) return false;

            return wallet.GetBalance() >= GetTransactionTotal();
        }





    }
}
