using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RemoveItemController : MonoBehaviour
{
    // Start is called before the first frame update
    public double itemCost = 0.0;
    public int itemsRemoved = 1;
    public string objectName;
    [SerializeField] TextMeshProUGUI objectNameBox;
    [SerializeField] GameObject itemPanel;

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
}
