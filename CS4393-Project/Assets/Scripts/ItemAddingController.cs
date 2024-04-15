using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace MyNamespace
{
    // Class to represent an item for filtering
    public class FilterItem
    {
        public string Name { get; private set; }
        public double Cost { get; private set; }
        public string Category { get; private set; }

        public FilterItem(string name, double cost, string category)
        {
            Name = name;
            Cost = cost;
            Category = category;
        }
    }
}

public class ItemAddingController : MonoBehaviour
{
    [SerializeField] TMP_InputField inputField;
    [SerializeField] Dropdown categoryDropdown;
    [SerializeField] GameObject itemPrefab;
    [SerializeField] Transform itemListParent;

    private List<MyNamespace.FilterItem> allItems = new List<MyNamespace.FilterItem>();
    private List<MyNamespace.FilterItem> filteredItems = new List<MyNamespace.FilterItem>();

    void Start()
    {
        // Example: Populate items list
        AddItem("Sword", 10.0, "Weapons");
        AddItem("Shield", 15.0, "Armor");
        AddItem("Potion", 5.0, "Consumables");
        AddItem("Scroll", 8.0, "Consumables");

        // Initialize UI with all items
        RefreshFilteredItems();
    }

    // Method to add an item
    private void AddItem(string itemName, double itemCost, string category)
    {
        allItems.Add(new MyNamespace.FilterItem(itemName, itemCost, category));
    }

    // Method to update UI with filtered items
    private void UpdateItemListUI()
    {
        // Clear existing UI items
        foreach (Transform child in itemListParent)
        {
            Destroy(child.gameObject);
        }

        // Instantiate UI elements for each filtered item
        foreach (MyNamespace.FilterItem item in filteredItems)
        {
            GameObject itemUI = Instantiate(itemPrefab, itemListParent);
            itemUI.GetComponent<ItemUI>().Initialize(item);
        }
    }

    // Method to refresh filtered items list based on search and category
    public void RefreshFilteredItems()
    {
        filteredItems.Clear();
        string searchKeyword = inputField.text.ToLower();
        string selectedCategory = categoryDropdown.options[categoryDropdown.value].text.ToLower();

        foreach (MyNamespace.FilterItem item in allItems)
        {
            if ((string.IsNullOrEmpty(searchKeyword) || item.Name.ToLower().Contains(searchKeyword)) &&
                (selectedCategory == "all" || item.Category.ToLower() == selectedCategory))
            {
                filteredItems.Add(item);
            }
        }

        // Update UI with filtered items
        UpdateItemListUI();
    }
}

// Class to handle the UI of each item
public class ItemUI : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI itemNameText;
    [SerializeField] TextMeshProUGUI itemCostText;

    private MyNamespace.FilterItem item;

    public void Initialize(MyNamespace.FilterItem item)
    {
        this.item = item;
        itemNameText.text = item.Name;
        itemCostText.text = "$" + item.Cost.ToString();
    }
}
