using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;
using JetBrains.Annotations;
using System.Text.RegularExpressions;

public class InventorySearchController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject parent;
    public GameObject child;
    public TextMeshProUGUI label;
    public Item item;
    public RawImage image;
    public SearchSingleton SearchSingleton;

    [Header("Categories")]
    [SerializeField] public Toggle produceToggle;
    [SerializeField] public Toggle groceriesToggle;
    [SerializeField] public Toggle snacksToggle;
    [SerializeField] public Toggle frozenToggle;
    [SerializeField] public Toggle drinksToggle;

    [Header("Price Filter")]
    [SerializeField] public TMP_InputField lowerRange;
    [SerializeField] public TMP_InputField upperRange;

    [Header("Search Bar")]
    [SerializeField] public TMP_InputField searchField;
    [SerializeField] public Button searchButton;

    [Header("Other")]
    [SerializeField] public Toggle includeUnavailable;
    void Start()
    {
        produceToggle.onValueChanged.AddListener(delegate {
            renderItems();
        });
        groceriesToggle.onValueChanged.AddListener(delegate {
            renderItems();
        });
        snacksToggle.onValueChanged.AddListener(delegate {
            renderItems();
        });
        frozenToggle.onValueChanged.AddListener(delegate {
            renderItems();
        });
        drinksToggle.onValueChanged.AddListener(delegate {
            renderItems();
        });

        lowerRange.onValueChanged.AddListener(delegate
        {
            renderItems();
        });
        upperRange.onValueChanged.AddListener(delegate
        {
            renderItems();
        });

        includeUnavailable.onValueChanged.AddListener(delegate
        {
            renderItems();
        });

        searchButton.onClick.AddListener(delegate
        {
            SearchSingleton.lastSearch = searchField.text;
            renderItems();
        });

        if (SearchSingleton.lastSearch != "")
        {
            searchField.text = SearchSingleton.lastSearch;
        }
        

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
                return !isVisible;
            }
        } else if (item.category == "Snack")
        {
            if (!snacksToggle.isOn)
            {
                return !isVisible;
            }
        } else if (item.category == "Groceries")
        {
            if (!groceriesToggle.isOn)
            {
                return !isVisible;
            }
        } else if (item.category == "Drink")
        {
            if (!drinksToggle.isOn)
            {
                return !isVisible;
            }
        } else if (item.category == "Frozen")
        {
            if (!frozenToggle.isOn)
            {
                return !isVisible;
            }
        }

        if (item.price > int.Parse(upperRange.text))
        {
            return !isVisible;
        }

        if (item.price < int.Parse(lowerRange.text))
        {
            return !isVisible;
        }

        if (item.quantity == 0)
        {
            if (!includeUnavailable.isOn)
            {
                return !isVisible;
            }
        }

        var regExp = new Regex(SearchSingleton.lastSearch.ToLower());

        if (!regExp.Match(item.itemName.ToLower()).Success)
        {
            return !isVisible;
        }
        Debug.Log(item.itemName);
        Debug.Log(SearchSingleton.lastSearch);

        return isVisible;
    }
}
