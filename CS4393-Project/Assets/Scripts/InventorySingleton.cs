using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventorySingleton : MonoBehaviour
{
    private static InventorySingleton currInstance;
    public static Item selectedItem;
    public static ArrayList inventory;

    public static void setSelectedItem(Item newItem)
    {
        selectedItem = newItem;
        Debug.Log(selectedItem.itemName);
    }//END

    public void populateInventory()
    {
        inventory.Add(new Item { itemName = "Milk", itemDesc = "Fresh milk", quantity = 10, rating = 4, price = 2.5, amtInCart = 0, category = "Drink" });
        inventory.Add(new Item { itemName = "Eggs", itemDesc = "Dozen eggs", quantity = 20, rating = 4, price = 3.0, amtInCart = 0, category = "Groceries" });
        inventory.Add(new Item { itemName = "Bread", itemDesc = "Whole wheat bread", quantity = 15, rating = 4, price = 2.0, amtInCart = 0, category = "Groceries" });
        inventory.Add(new Item { itemName = "Apples", itemDesc = "Red apples", quantity = 30, rating = 4, price = 1.0, amtInCart = 0, category = "Produce" });
        inventory.Add(new Item { itemName = "Bananas", itemDesc = "Ripe bananas", quantity = 25, rating = 4, price = 1.5, amtInCart = 0, category = "Produce" });
        inventory.Add(new Item { itemName = "Potatoes", itemDesc = "Fresh potatoes", quantity = 20, rating = 4, price = 1.0, amtInCart = 0, category = "Produce" });
        inventory.Add(new Item { itemName = "Onions", itemDesc = "Yellow onions", quantity = 25, rating = 4, price = 0.5, amtInCart = 0, category = "Produce" });
        inventory.Add(new Item { itemName = "Tomatoes", itemDesc = "Juicy tomatoes", quantity = 30, rating = 4, price = 1.2, amtInCart = 0, category = "Produce" });
        inventory.Add(new Item { itemName = "Carrots", itemDesc = "Fresh carrots", quantity = 20, rating = 4, price = 1.0, amtInCart = 0, category = "Produce" });
        inventory.Add(new Item { itemName = "Chicken", itemDesc = "Fresh chicken breast", quantity = 10, rating = 4, price = 5.0, amtInCart = 0, category = "Groceries" });
        inventory.Add(new Item { itemName = "Fish", itemDesc = "Salmon fillet", quantity = 10, rating = 4, price = 8.0, amtInCart = 0, category = "Groceries" });
        inventory.Add(new Item { itemName = "Beef", itemDesc = "Lean beef steak", quantity = 8, rating = 4, price = 9.0, amtInCart = 0, category = "Groceries" });
        inventory.Add(new Item { itemName = "Pasta", itemDesc = "Whole grain pasta", quantity = 15, rating = 4, price = 2.5, amtInCart = 0, category = "Groceries" });
        inventory.Add(new Item { itemName = "Rice", itemDesc = "Brown rice", quantity = 20, rating = 4, price = 1.5, amtInCart = 0, category = "Groceries" });
        inventory.Add(new Item { itemName = "Cereal", itemDesc = "Multigrain cereal", quantity = 10, rating = 4, price = 3.0, amtInCart = 0, category = "Groceries" });
        inventory.Add(new Item { itemName = "Yogurt", itemDesc = "Low-fat yogurt", quantity = 15, rating = 4, price = 2.0, amtInCart = 0, category = "Groceries" });
        inventory.Add(new Item { itemName = "Cheese", itemDesc = "Cheddar cheese", quantity = 12, rating = 4, price = 4.0, amtInCart = 0, category = "Groceries" });
        inventory.Add(new Item { itemName = "Butter", itemDesc = "Salted butter", quantity = 8, rating = 4, price = 2.0, amtInCart = 0, category = "Groceries" });
        inventory.Add(new Item { itemName = "Oil", itemDesc = "Olive oil", quantity = 10, rating = 4, price = 5.0, amtInCart = 0, category = "Groceries" });
        inventory.Add(new Item { itemName = "Sugar", itemDesc = "White sugar", quantity = 20, rating = 4, price = 1.0, amtInCart = 0, category = "Groceries" });
        inventory.Add(new Item { itemName = "Flour", itemDesc = "All-purpose flour", quantity = 15, rating = 4, price = 2.0, amtInCart = 0, category = "Groceries" });
        inventory.Add(new Item { itemName = "Salt", itemDesc = "Sea salt", quantity = 10, rating = 4, price = 1.0, amtInCart = 0, category = "Groceries" });
        inventory.Add(new Item { itemName = "Pepper", itemDesc = "Black pepper", quantity = 10, rating = 4, price = 1.0, amtInCart = 0, category = "Groceries" });
        inventory.Add(new Item { itemName = "Coffee", itemDesc = "Ground coffee", quantity = 12, rating = 4, price = 6.0, amtInCart = 0, category = "Drink" });
        inventory.Add(new Item { itemName = "Tea", itemDesc = "Green tea", quantity = 15, rating = 4, price = 3.0, amtInCart = 0, category = "Drink" });
        inventory.Add(new Item { itemName = "Juice", itemDesc = "Orange juice", quantity = 20, rating = 4, price = 2.0, amtInCart = 0, category = "Drink" });
        inventory.Add(new Item { itemName = "Soda", itemDesc = "Cola soda", quantity = 20, rating = 4, price = 1.5, amtInCart = 0, category = "Drink" });
        inventory.Add(new Item { itemName = "Water", itemDesc = "Bottled water", quantity = 30, rating = 4, price = 1.0, amtInCart = 0, category = "Drink" });
        inventory.Add(new Item { itemName = "Cookies", itemDesc = "Chocolate chip cookies", quantity = 15, rating = 4, price = 3.0, amtInCart = 0, category = "Snack" });
        inventory.Add(new Item { itemName = "Chips", itemDesc = "Potato chips", quantity = 20, rating = 4, price = 2.0, amtInCart = 0, category = "Snack" });
        inventory.Add(new Item { itemName = "Crackers", itemDesc = "Saltine crackers", quantity = 10, rating = 4, price = 1.5, amtInCart = 0, category = "Snack" });
        inventory.Add(new Item { itemName = "Nuts", itemDesc = "Mixed nuts", quantity = 12, rating = 4, price = 4.0, amtInCart = 0, category = "Snack" });
        inventory.Add(new Item { itemName = "Popcorn", itemDesc = "Microwave popcorn", quantity = 15, rating = 4, price = 2.5, amtInCart = 0, category = "Snack" });
        inventory.Add(new Item { itemName = "Chocolate", itemDesc = "Dark chocolate", quantity = 8, rating = 4, price = 3.0, amtInCart = 0, category = "Snack" });
        inventory.Add(new Item { itemName = "Candy", itemDesc = "Assorted candy", quantity = 20, rating = 4, price = 1.0, amtInCart = 0, category = "Snack" });
        inventory.Add(new Item { itemName = "Ice Cream", itemDesc = "Vanilla ice cream", quantity = 10, rating = 4, price = 4.0, amtInCart = 0, category = "Frozen" });
        inventory.Add(new Item { itemName = "Frozen Vegetables", itemDesc = "Mixed vegetables", quantity = 10, rating = 4, price = 2.0, amtInCart = 0, category = "Frozen" });
        inventory.Add(new Item { itemName = "Frozen Pizza", itemDesc = "Pepperoni pizza", quantity = 8, rating = 4, price = 5.0, amtInCart = 0, category = "Frozen" });
        inventory.Add(new Item { itemName = "Frozen Fries", itemDesc = "Crinkle cut fries", quantity = 10, rating = 4, price = 2.0, amtInCart = 0, category = "Frozen" });
        inventory.Add(new Item { itemName = "Frozen Chicken Nuggets", itemDesc = "Breaded chicken nuggets", quantity = 8, rating = 4, price = 3.0, amtInCart = 0, category = "Frozen" });
        inventory.Add(new Item { itemName = "Frozen Burritos", itemDesc = "Beef and bean burritos", quantity = 10, rating = 4, price = 2.5, amtInCart = 0, category = "Frozen" });
        inventory.Add(new Item { itemName = "Frozen Waffles", itemDesc = "Buttermilk waffles", quantity = 12, rating = 4, price = 2.0, amtInCart = 0, category = "Frozen" });
        inventory.Add(new Item { itemName = "Canned Soup", itemDesc = "Chicken noodle soup", quantity = 15, rating = 4, price = 1.5, amtInCart = 0, category = "Groceries" });
        inventory.Add(new Item { itemName = "Canned Beans", itemDesc = "Kidney beans", quantity = 10, rating = 4, price = 1.0, amtInCart = 0, category = "Groceries" });
        inventory.Add(new Item { itemName = "Canned Tomatoes", itemDesc = "Diced tomatoes", quantity = 10, rating = 4, price = 1.0, amtInCart = 0, category = "Groceries" });
        inventory.Add(new Item { itemName = "Canned Tuna", itemDesc = "Chunk light tuna", quantity = 8, rating = 4, price = 2.0, amtInCart = 0, category = "Groceries" });
        inventory.Add(new Item { itemName = "Granola Bars", itemDesc = "Oat and honey bars", quantity = 12, rating = 4, price = 3.0, amtInCart = 0, category = "Snack" });
        inventory.Add(new Item { itemName = "Dried Pasta", itemDesc = "Spaghetti noodles", quantity = 15, rating = 4, price = 1.5, amtInCart = 0, category = "Groceries" });
        inventory.Add(new Item { itemName = "Dried Beans", itemDesc = "Black beans", quantity = 10, rating = 4, price = 1.0, amtInCart = 0, category = "Groceries" });
        inventory.Add(new Item { itemName = "Dried Fruits", itemDesc = "Mixed dried fruits", quantity = 10, rating = 4, price = 2.0, amtInCart = 0, category = "Groceries" });

    }//END

    public static InventorySingleton Instance
    {
        get
        {
            return currInstance;
        }
    }

    public void Awake()
    {
        if (currInstance != null && currInstance != this)
        {
            Destroy(this.gameObject);
        }//END if 
        else
        {
            Debug.Log("Created");
            inventory = new ArrayList();
            populateInventory();
            currInstance = this;
            DontDestroyOnLoad(currInstance);
        }//END else
    }//END Awake
}
