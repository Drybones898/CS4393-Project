using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SearchSingleton : MonoBehaviour
{
    private static SearchSingleton currInstance;
    public static string lastSearch;

    public static SearchSingleton Instance
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
            lastSearch = "";
            currInstance = this;
            DontDestroyOnLoad(currInstance);
        }//END else
    }//END Awake
}
