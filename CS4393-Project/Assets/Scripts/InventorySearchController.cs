using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using static UnityEngine.Rendering.DebugUI;

public class InventorySearchController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject parent;
    public GameObject child;
    public TextMeshProUGUI label;
    public Item item;
    public RawImage image;
    void Start()
    {
        int i = 0, j = 0;
        foreach (Transform childTransform in parent.transform)
        {
            child = childTransform.gameObject;
            item = (Item)InventorySingleton.inventory[i];
            if(item == null)
            {
                break;
            }

            foreach (Transform childTransform2 in child.transform)
            {
                if (j != 5)
                    label = childTransform2.gameObject.GetComponent<TextMeshProUGUI>();
                else if (j == 5)
                    image = childTransform2.gameObject.GetComponent<RawImage>();
                switch (j)
                {
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
                    label.text = item.quantity.ToString() + " remaining";
                    break;
                    case 5:
                    //input image
                    image.texture = Resources.Load<Texture>("Images/" + item.itemName);
                    label.text = item.itemName;
                    break;
                    case 6:
                    label.text = item.itemName;
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
