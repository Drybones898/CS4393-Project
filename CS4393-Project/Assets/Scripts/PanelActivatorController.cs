using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PanelActivatorController : MonoBehaviour
{
    [SerializeField] GameObject parent;
    public TMP_InputField inputField;
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
            if (i >= PlayerSingleton.inventory.Count)
            {
                child.SetActive(false);
                Debug.Log("Removed");
                continue;
            }
            item = (Item)PlayerSingleton.inventory[i];
            

            foreach (Transform childTransform2 in child.transform)
            {
                
                if(j == 6)
                    inputField = childTransform2.gameObject.GetComponent<TMP_InputField>();
                else if (j == 7)
                    image = childTransform2.gameObject.GetComponent<RawImage>();
                else
                    label = childTransform2.gameObject.GetComponent<TextMeshProUGUI>();
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
                        label.text = "Total Price: $" + (item.amtInCart * item.price).ToString();
                        break;
                    case 6:
                        inputField.text = item.amtInCart.ToString();
                        break;
                    case 7:
                        //input image
                        image.texture = Resources.Load<Texture>("Images/" + item.itemName);
                        break;
                    case 8:
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
