using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSingleton : MonoBehaviour
{
    private static PlayerSingleton currInstance;
    public static double cartTotal;
    public static int totalItems;
    public static ArrayList inventory;

    public static PlayerSingleton Instance
    {
        get
        {
            return currInstance;
        }
    }
    public void Awake()
    {
        if(currInstance != null && currInstance != this)
        {
            Destroy(this.gameObject);
        }//END if 
        else
        {
            Debug.Log("Created");
            cartTotal = 0.0;
            totalItems = 0;
            inventory = new ArrayList();
            currInstance = this;
            DontDestroyOnLoad(currInstance);
        }//END else
    }//END Awake
}
