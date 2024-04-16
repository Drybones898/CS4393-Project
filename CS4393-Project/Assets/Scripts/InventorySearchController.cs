using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using static UnityEngine.Rendering.DebugUI;
using Unity.VisualScripting;

public class InventorySearchController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject parent;
    public GameObject child;
    public TextMeshProUGUI label;
    public Item item;
    public RawImage image;
    public UnityEngine.UI.Button button;

    [Header("Categories")]
    [SerializeField] public Toggle produceToggle;
    [SerializeField] public Toggle groceriesToggle;
    [SerializeField] public Toggle snacksToggle;
    [SerializeField] public Toggle frozenToggle;
    [SerializeField] public Toggle drinksToggle;

    [Header("Price Filter")]
    [SerializeField] public TMP_InputField lowerRange;
    [SerializeField] public TMP_InputField upperRange;

    [Header("Other")]
    [SerializeField] public Toggle includeUnavailable;
    void Start()
    {
        produceToggle.onValueChanged.AddListener(delegate {
            updateCategories();
        });
        groceriesToggle.onValueChanged.AddListener(delegate {
            updateCategories();
        });
        snacksToggle.onValueChanged.AddListener(delegate {
            updateCategories();
        });
        frozenToggle.onValueChanged.AddListener(delegate {
            updateCategories();
        });
        drinksToggle.onValueChanged.AddListener(delegate {
            updateCategories();
        });

        lowerRange.onValueChanged.AddListener(delegate
        {
            updateRange();
        });
        upperRange.onValueChanged.AddListener(delegate
        {
            updateRange();
        });

        includeUnavailable.onValueChanged.AddListener(delegate
        {
            updateUnavailable();
        });

        renderItems();
    }
    void renderItems()
    {
        int i = 0, j = 0;
        foreach (Transform childTransform in parent.transform)
        {
            child = childTransform.gameObject;
            if (i >= 50)
            {
                break;
            }
            item = (Item)InventorySingleton.inventory[i];
            if (item == null)
            {
                break;
            }

            if(!checkFilters(item))
            {
                child.SetActive(false);
                //i++;
            } else
            {
                child.SetActive(true);
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
            }
            i++;
        }
    }

    bool checkFilters(Item item)
    {
        bool isVisible = true;

        //ugly but the switch statement just wouldn't work.
        if (item.category == "Produce")
        {
            if (!produceToggle.isOn) {
                isVisible = false;
                Debug.Log(item.itemName + " fail produce");
                return isVisible;
            }
        } else if (item.category == "Snack")
        {
            if (!snacksToggle.isOn)
            {
                isVisible = false;
                Debug.Log(item.itemName + " fail snacks");
                return isVisible;
            }
        } else if (item.category == "Groceries")
        {
            if (!groceriesToggle.isOn)
            {
                isVisible = false;
                Debug.Log(item.itemName + " fail groceries");
                return isVisible;
            }
        } else if (item.category == "Drink")
        {
            if (!drinksToggle.isOn)
            {
                isVisible = false;
                Debug.Log(item.itemName + " fail drinks");
                return isVisible;
            }
        } else if (item.category == "Frozen")
        {
            if (!frozenToggle.isOn)
            {
                isVisible = false;
                Debug.Log(item.itemName + " fail frozen");
                return isVisible;
            }
        }

        if (item.price > int.Parse(upperRange.text))
        {
            isVisible = false;
            Debug.Log(item.itemName + " fail upper");
            return isVisible;
        }

        if (item.price < int.Parse(lowerRange.text))
        {
            isVisible = false;
            Debug.Log(item.itemName + " fail lower");
            return isVisible;
        }

        if (item.quantity == 0)
        {
            if (!includeUnavailable.isOn)
            {
                isVisible = false;
                Debug.Log(item.itemName + " fail unavailable");
                return isVisible;
            }
        }

        return isVisible;
    }

    void updateCategories()
    {
        renderItems();
        Debug.Log("Update Categories");
    }
    void updateRange()
    {
        renderItems();
        Debug.Log("Update Range");
    }
    void updateUnavailable()
    {
        renderItems();
        Debug.Log("Update Unavailable");
    }
}
