using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RPG.Shops;
using TMPro;


namespace RPG.UI.Shops
{
    public class ShopRow : MonoBehaviour
    {

        [SerializeField] TextMeshProUGUI nameField;
        [SerializeField] TextMeshProUGUI priceField;
        [SerializeField] TextMeshProUGUI quantityField;

        Shop currentShop = null;
        ShopItem item = null;

        public void Setup(Shop currentShop, ShopItem item)
        {
            this.currentShop = currentShop;
            this.item = item;
            nameField.text = item.GetName();
            priceField.text = $"£{item.GetPrice():N2}";
            quantityField.text = $"{item.GetQuantityInTransaction()}";

        }

        public void Add()
        {
            currentShop.AddToTransaction(item.GetItemObject(), 1);
        }

        public void Remove()
        {
            currentShop.AddToTransaction(item.GetItemObject(), -1);
        }
    }
}

