using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventoryDisplay : MonoBehaviour
{
    [SerializeField] InventorySingleton inventorySingleton;
    [SerializeField] GameObject canvas;
    [SerializeField] TextMeshProUGUI itemDesc;
    [SerializeField] TextMeshProUGUI itemName;
    [SerializeField] TextMeshProUGUI quantity;
    [SerializeField] TextMeshProUGUI rating;
    [SerializeField] TextMeshProUGUI price;

    public static Item item;


    void Start()
    {
        item = InventorySingleton.selectedItem;
        itemDesc.text = item.itemDesc;
        itemName.text = item.itemName;
        quantity.text = item.quantity.ToString() + " remaining";
        rating.text = "Rated " + item.rating.ToString() + " out of 5";
        price.text = "$" + item.price.ToString();
    }
}
