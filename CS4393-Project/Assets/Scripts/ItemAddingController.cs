using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemAddingController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject playerStatusController;
    [SerializeField] GameObject inventoryStatusController;
    [SerializeField] string itemName;
    [SerializeField] double itemCost;
    public void addToCart()
    {
        playerStatusController.GetComponent<PlayerStatusController>().itemPickedUp(itemName, itemCost);
    }
}
