using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckoutController : MonoBehaviour
{
    public void Checkout()
    {
        while(PlayerSingleton.inventory.Count != 0)
        {
            PlayerSingleton.inventory.RemoveAt(PlayerSingleton.inventory.Count - 1);
        }

        PlayerSingleton.cartTotal = 0;
        PlayerSingleton.totalItems = 0;
    }
}
