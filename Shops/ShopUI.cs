using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RPG.Shops;
using System;
using TMPro;
using UnityEngine.UI;

namespace RPG.UI.Shops
{
    public class ShopUI : MonoBehaviour
    {

        Shopper shopper = null;
        Shop currentShop = null;
        [SerializeField] Transform itemList;
        [SerializeField] ShopRow itemPrefab;
        [SerializeField] ShopRow soldOutPrefab;
        [SerializeField] TextMeshProUGUI totalField;
        [SerializeField] Button confirmButton;

        Color originalTotalTextColor;

        // Start is called before the first frame update
        void Start()
        {
            originalTotalTextColor = totalField.color;
            shopper = GameObject.FindGameObjectWithTag("Player").GetComponent<Shopper>();
            if (shopper == null) return;

            shopper.activeShopChange += ShopChanged;
            confirmButton.onClick.AddListener(ConfirmTransaction);
            ShopChanged();
        }

        void ShopChanged()
        {
            if (currentShop != null)
            {
                currentShop.onChange -= RefreshUI;
            }
            currentShop = shopper.GetActiveShop();
            gameObject.SetActive(currentShop != null);

            if (currentShop == null) return;

            currentShop.onChange += RefreshUI;

            RefreshUI();
        }

        private void RefreshUI()
        {
            foreach (Transform child in itemList)
            {
                Destroy(child.gameObject);

            }
            if (currentShop.GetFilteredItems() != null)
            { 
                foreach (ShopItem item in currentShop.GetFilteredItems())
                {
                    if ( item.IsSoldOut())
                    {
                        ShopRow newShopItem = Instantiate<ShopRow>(soldOutPrefab, itemList);
                        newShopItem.Setup(currentShop, item);
                    }
                    else
                    {
                        ShopRow newShopItem = Instantiate<ShopRow>(itemPrefab, itemList);
                        //newShopItem.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = item.GetName();
                        //newShopItem.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = "£" + item.GetPrice().ToString();
                        newShopItem.Setup(currentShop, item);
                        //itemPrefab.GetComponent<ItemButton>().item = item;
                    }


                }
            }
            totalField.text = $"Total: £{currentShop.GetTransactionTotal():N2}";
            totalField.color = currentShop.HasSufficientFunds() ? originalTotalTextColor : Color.red;
            confirmButton.interactable = currentShop.CanBuy();
        }

        public void Close()
        {
            shopper.SetActiveShop(null);
        }

        public void ConfirmTransaction()
        {
            currentShop.ConfirmTransaction();
        }

        private void Update()
        {
            //if (Input.GetButtonDown("Circle"))
            //{
            //    shopper.SetActiveShop(null);
                

            //}
        }
    }
}
