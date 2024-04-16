using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CheckoutController : MonoBehaviour
{
    [SerializeField] GameObject parent;
    public TMP_InputField inputField;
    public GameObject child;
    public TextMeshProUGUI label;
    public Item item;
    public RawImage image;

    public void Checkout()
    {
        while (PlayerSingleton.inventory.Count != 0)
        {
            PlayerSingleton.inventory.RemoveAt(PlayerSingleton.inventory.Count - 1);
        }

        PlayerSingleton.cartTotal = 0;
        PlayerSingleton.totalItems = 0;

        foreach (Transform childTransform in parent.transform)
        {
            child = childTransform.gameObject;

            child.SetActive(false);
            Debug.Log("Removed");
            continue;
        }
    }
}
