using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG.Shops
{
    public class ShopItem
    {
        ItemObject item;
        float price;
        int quantityInTransaction;
        bool soldOut;

        public ShopItem(ItemObject item, bool soldOut, float price, int quantityInTransaction)
        {
            this.item = item;
            this.soldOut = soldOut;
            this.price = price;
            this.quantityInTransaction = quantityInTransaction;


        }

        public string GetName()
        {
            return item.GetItemName();
        }

        public float GetPrice()
        {
            return price;
        }

        public bool IsSoldOut()
        {
            return soldOut;
        }

        

        public ItemObject GetItemObject()
        {
            return item;
        }

        public int GetQuantityInTransaction()
        {
            return quantityInTransaction;
        }
    }
}
