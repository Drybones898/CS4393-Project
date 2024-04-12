using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatusController : MonoBehaviour
{
    public void itemPickedUp(string newItem, double itemCost)
    {
        PlayerSingleton.inventory.Add(newItem);
        PlayerSingleton.totalItems += 1;
        PlayerSingleton.cartTotal += itemCost;
    }//END itemPickedUp()
}
