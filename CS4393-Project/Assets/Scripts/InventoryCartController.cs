using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventoryCartController : MonoBehaviour
{
    [SerializeField] GameObject parent;
    public GameObject child;
    public TextMeshProUGUI label;
    public Item item;
    void Start()
    {
        int i = 0, j = 0;
        if (PlayerSingleton.cartTotal > 0.0)
        {


            foreach (Transform childTransform in parent.transform)
            {
                child = childTransform.gameObject;
                item = (Item)InventorySingleton.inventory[i];
                if (item == null)
                {
                    break;
                }

                foreach (Transform childTransform2 in child.transform)
                {
                    label = childTransform2.gameObject.GetComponent<TextMeshProUGUI>();
                    switch (j)
                    {
                        case 0:
                            //input image
                            break;
                        case 1:
                            label.text = item.itemName;
                            //Debug.Log(item.itemName);
                            break;
                        case 2:
                            label.text = "Rated " + item.rating.ToString() + " out of 5";
                            Debug.Log(item.itemName);
                            break;
                        case 3:
                            label.text = "$" + item.price.ToString();
                            break;
                        case 4:
                            //Input total amt
                            break;
                        case 6:
                            //Input amount in cart
                            break;
                        default:
                            break;
                    }
                    j++;
                }
                j = 0;
                i++;
                Debug.Log(i);
            }
        }
    }
}
