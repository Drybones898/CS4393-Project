using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine;
using TMPro;

public class ItemAddingController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] TMP_InputField inputField;
    public string input;
    public double itemCost = 0.0;
    public int itemsAdded = 1;
    public void addToCart()
    {
        input = inputField.text;
        try{
            itemsAdded = int.Parse(input);
        }catch(System.FormatException)
        {
            Debug.LogWarning("ERROR");
        }
        Debug.Log(InventorySingleton.selectedItem.itemName);
        itemCost = InventorySingleton.selectedItem.price;
        InventorySingleton.selectedItem.quantity -= itemsAdded;
        InventorySingleton.selectedItem.amtInCart += itemsAdded;
        PlayerSingleton.inventory.Add(InventorySingleton.selectedItem);
        PlayerSingleton.cartTotal += itemCost * itemsAdded;
        PlayerSingleton.totalItems += itemsAdded;
        

    }
}
