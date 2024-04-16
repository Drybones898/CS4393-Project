using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;
using System.Net;

public class RemoveItemController : MonoBehaviour
{
    // Start is called before the first frame update
    public double itemCost = 0.0;
    public int itemsRemoved = 1;
    public string objectName;
    [SerializeField] TextMeshProUGUI objectNameBox;
    [SerializeField] TextMeshProUGUI totalPriceBox;
    [SerializeField] GameObject itemPanel;
    [SerializeField] TMP_InputField amountField;

    void Update()
    {
        objectName = objectNameBox.text;
    }

    public void searchForItem()
    {
        foreach(Item item in InventorySingleton.inventory)
        {
            if(item.itemName == objectName)
            {
                InventorySingleton.setSelectedItem(item);
            }
        }
    }
    public void removeFromCart()
    {
        searchForItem();
        itemCost = InventorySingleton.selectedItem.price;
        PlayerSingleton.inventory.Remove(InventorySingleton.selectedItem);
        PlayerSingleton.cartTotal -= itemCost * InventorySingleton.selectedItem.amtInCart;
        PlayerSingleton.totalItems -= InventorySingleton.selectedItem.amtInCart;
        InventorySingleton.selectedItem.quantity += InventorySingleton.selectedItem.amtInCart;
        InventorySingleton.selectedItem.amtInCart = 0;
        itemPanel.SetActive(false);
    }

    public void editAmount()
    {
        searchForItem();
        itemCost = InventorySingleton.selectedItem.price;
        int previousAmount = InventorySingleton.selectedItem.amtInCart;
        int amount = int.Parse(amountField.text);
        if (int.Parse(amountField.text) < 0)
        {
            InventorySingleton.selectedItem.amtInCart = previousAmount;
            amountField.text = previousAmount.ToString();
        }
        else if (int.Parse(amountField.text) > InventorySingleton.selectedItem.quantity + previousAmount)
        {
            while (amount > InventorySingleton.selectedItem.quantity + previousAmount)
            {
                amount = amount - 1;
            }
            amountField.text = amount.ToString();
            InventorySingleton.selectedItem.amtInCart = amount;
        }
        else if (int.Parse(amountField.text) == 0)
        {
            PlayerSingleton.cartTotal -= itemCost * InventorySingleton.selectedItem.amtInCart;
            PlayerSingleton.totalItems -= InventorySingleton.selectedItem.amtInCart;
            InventorySingleton.selectedItem.quantity += InventorySingleton.selectedItem.amtInCart;
            InventorySingleton.selectedItem.amtInCart = 0;
        }
        else if (int.Parse(amountField.text) > InventorySingleton.selectedItem.amtInCart)
        {
            PlayerSingleton.cartTotal += itemCost * (int.Parse(amountField.text) - InventorySingleton.selectedItem.amtInCart);
            PlayerSingleton.totalItems += int.Parse(amountField.text) - InventorySingleton.selectedItem.amtInCart;
            InventorySingleton.selectedItem.quantity -= int.Parse(amountField.text) - InventorySingleton.selectedItem.amtInCart;
            InventorySingleton.selectedItem.amtInCart = int.Parse(amountField.text);
        }
        else
        {
            PlayerSingleton.cartTotal -= itemCost * (InventorySingleton.selectedItem.amtInCart - int.Parse(amountField.text));
            InventorySingleton.selectedItem.quantity += InventorySingleton.selectedItem.amtInCart - int.Parse(amountField.text);
            InventorySingleton.selectedItem.amtInCart = int.Parse(amountField.text);
        }

        totalPriceBox.text = "Total Price: $" + (amount * InventorySingleton.selectedItem.price).ToString();
    }

    /*
    public void completeCheckout() //!TODO!
    {
        foreach (Item item in PlayerSingleton.inventory)
        {
            PlayerSingleton.inventory.Remove(item);
        }
        PlayerSingleton.cartTotal = 0;
        PlayerSingleton.totalItems = 0;
        InventorySingleton.selectedItem.amtInCart = 0;
    }
    */
}
